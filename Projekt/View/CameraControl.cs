using AForge.Video;
using AForge.Video.DirectShow;
using Projekt.Controller;
using Projekt.Exception;
using System.Configuration;

namespace Projekt.View;

public partial class CameraControl : MainControl
{
    #region Variables
    readonly CameraController _cameraController = new CameraController();
    VideoCaptureDevice videoCaptureDevice;
    Image snapshot;
    public Panel pnlImages = MainView.Instance.pnlImages;
    public string selectedCamera;
    bool _isProcessing = false;
    private readonly string snapshotPath = ConfigurationManager.AppSettings["SnapshotPath"];
    private readonly string loadingImage = ConfigurationManager.AppSettings["LoadingImagePath"];
    private readonly string croppedImage = ConfigurationManager.AppSettings["CroppedImagePath"];
    private readonly string backgroundImage = ConfigurationManager.AppSettings["BackgroundImagePath"];
    private readonly string vectorPath = ConfigurationManager.AppSettings["VectorPath"];
    private readonly string queryImage = ConfigurationManager.AppSettings["QueryImagePath"];
    private readonly string learningDirectoryPath = ConfigurationManager.AppSettings["LearningDirectoryPath"];
    #endregion


    public CameraControl()
    {
        InitializeComponent();
        ApplyTheme(Controls, Width);
        btnProcessImage.BackColor = ColorTranslator.FromHtml(ConfigurationManager.AppSettings["MainColor"]);
        btnSave.BackColor = ColorTranslator.FromHtml(ConfigurationManager.AppSettings["MainColor"]);
    }


    /// <summary>
    /// A program bezárásakor hívódik meg és leállítja a kamerát.
    /// </summary>
    public void Dispose()
    {
        videoCaptureDevice?.SignalToStop();
        videoCaptureDevice = null;
    }


    /// <summary>
    /// A form betöltésekor elindítja a kamerát.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void CameraControl_Load(object sender, EventArgs e)
    {
        try
        {
            videoCaptureDevice = new VideoCaptureDevice();
            picboxCropped.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        catch (System.Exception ex)
        {
            MessageBox.Show("Hiba a kamera betöltése közben!\n" + ex.Message);
        }
    }


    /// <summary>
    /// Elindítja a kamerát, ha még nem fut.
    /// </summary>
    /// <param name="isRestart">újrainditsa-e ha már fut</param>
    public void StartCamera(bool isRestart = false)
    {
        if (videoCaptureDevice == null && isRestart)
            return;
        if (videoCaptureDevice != null && videoCaptureDevice.IsRunning && !isRestart)
            return;

        if (isRestart)
        {
            videoCaptureDevice?.SignalToStop();
        }

        if (selectedCamera == null)
        {
            string imagePath = @"..\..\..\Pictures\teszt.png";
            picboxCamera.SizeMode = PictureBoxSizeMode.StretchImage;
            picboxCamera.Image = new Bitmap(imagePath);
            btnTakePic.Visible = true;
            btnStart.Visible = false;
        }
        else
        {
            videoCaptureDevice = new VideoCaptureDevice(selectedCamera);
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
            btnStart.Visible = false;
            btnTakePic.Visible = true;
        }
    }

    /// <summary>
    /// Kamera újraindítás gomb eseménykezelője
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnStart_Click(object sender, EventArgs e)
    {
        StartCamera(true);
        btnProcessImage.Enabled = false;
    }

    /// <summary>
    /// Framenként cseréli a kamera képét
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="eventArgs"></param>
    private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
    {
        picboxCamera.Image = (Bitmap)eventArgs.Frame.Clone();
    }


    /// <summary>
    /// Készít egy képet (megállítja a kamerát)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnTakePic_Click(object sender, EventArgs e)
    {
        if (picboxCamera.Image != null)
        {
            snapshot = (Image)picboxCamera.Image.Clone();
            videoCaptureDevice.SignalToStop();
            picboxCamera.Image = snapshot;
            btnStart.Visible = true;
            btnTakePic.Visible = false;
            if (!_isProcessing)
                btnProcessImage.Enabled = true;
        }
    }


    /// <summary>
    /// Kép feldolgozás gomb eseménykezelője
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnProcessImage_Click(object sender, EventArgs e) => ProcessImage();


    /// <summary>
    /// Feldolgozza a képet
    /// </summary>
    /// <returns></returns>
    private async Task ProcessImage()
    {
        try
        {
            btnProcessImage.Enabled = false;
            _isProcessing = true;
            snapshot.Save(snapshotPath);
            picboxCropped.Image = Image.FromFile(loadingImage);

            await Task.Run(() => _cameraController.ImageProcess());

        }
        catch (PythonExecuteException ex)
        {
            MessageBox.Show(ex.Message);
            return;
        }
        using (var stream = new FileStream(croppedImage, FileMode.Open, FileAccess.Read, FileShare.None))
        using (var backImg = Image.FromFile(backgroundImage))
        using (var g = Graphics.FromImage(backImg))
        {
            Image resized = Image.FromStream(stream);

            //ha nem férne rá a háttérre lekicsinyíti
            if (resized.Width > backImg.Width || resized.Height > backImg.Height)
            {
                //Kiszámolja, hogy mennyivel lehet lekicsinyíteni hogy megmaradjonak az arányai
                double oldWidth = resized.Width;
                double oldHeight = resized.Height;

                var widthRatio = backImg.Width / oldWidth;
                var heightRatio = backImg.Height / oldHeight;

                var factor = Math.Min(widthRatio, heightRatio);
                var destRect = new Rectangle(0, 0, (int)(factor * oldWidth), (int)(factor * oldHeight));

                //újraméretezi a képet
                resized = _cameraController.ResizeImage(resized, destRect.Width, destRect.Height);
            }

            g.DrawImage(resized, ((backImg.Width - resized.Width) / 2), ((backImg.Height - resized.Height) / 2), resized.Width, resized.Height);
            picboxCropped.Image = (Image)backImg.Clone();

            btnProcessImage.Enabled = true;
            _isProcessing = false;
        }

    }



    /// <summary>
    /// Tovább lép a ResultView oldalra
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnSelectPic_Click(object sender, EventArgs e)
    {
        videoCaptureDevice?.SignalToStop();

        if (!MainView.Instance.Controls.ContainsKey("ResultControl"))
        {
            ResultControl control = new ResultControl();
            control.Dock = DockStyle.Fill;
            control.textbox.Text = "tüskevár";
            control.StartCameraControl += StartCamera;
            MainView.Instance.Controls.Add(control);
        }
        MainView.Instance.Controls["ResultControl"].BringToFront();
    }

    /// <summary>
    /// Visszalép a SetupView oldalra
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnBack_Click(object sender, EventArgs e)
    {
        MainView.Instance.Controls["SetupControl"].BringToFront();
        videoCaptureDevice?.SignalToStop();
    }


    /// <summary>
    /// A pnlImages Panelre helyezi a képet
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void btnSave_Click(object sender, EventArgs e)
    {
        if (picboxCropped.Image == null || _isProcessing) return;

        if (pnlImages.Controls.OfType<Panel>().Count() == 6)
        {
            MessageBox.Show("További képek mentéséhez törlésre van szükség!");
            return;
        }
        if (cboImageType.SelectedIndex == -1)
        {
            MessageBox.Show("Nincs típus kiválasztva!");
            return;
        }        

        PicturePanel pic = new PicturePanel(cboImageType.Text, picboxCropped.Image);
        pnlImages.Controls.Add(pic);
        cboImageType.SelectedIndex = -1;


        if (string.IsNullOrEmpty(learningDirectoryPath))
        {
            pic.Result.Text = "";
            return;
        }
        string result = "";
        File.Copy(croppedImage, queryImage, true);
        while (true)
        {
            if (File.Exists(vectorPath))
            {
                try
                {
                    result = await Task.Run(() => _cameraController.SearchSimilarPhoto());
                } catch (PythonExecuteException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                break;
            }
            await Task.Delay(100); 

        }
        pic.Result.Text = result.TrimEnd('\r', '\n');       

    }
}
