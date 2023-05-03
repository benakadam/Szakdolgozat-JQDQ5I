using AForge.Video.DirectShow;
using System.Configuration;
using System.Text;
namespace Projekt.View;

public partial class SetupControl : MainControl
{
    CameraControl cameraCon;
    public delegate void CameraDelegate(bool restart = false);
    public event CameraDelegate StartCameraControl;
    FilterInfoCollection filterInfoCollection;
    private readonly string configPath = ConfigurationManager.AppSettings["ConfigPath"];


    public SetupControl()
    {
        InitializeComponent();
        ApplyTheme(Controls, Width);
    }

    /// <summary>
    /// Megnyitja a kamera oldalt, és elindítja a kamerát
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnCamera_Click(object sender, EventArgs e)
    {
        if (txtPythonPath.Text.Length < 1)
        {
            MessageBox.Show("Python útvonal megadása kötelező!");
            return;
        }
        if (txtSavePicturesPath.Text.Length < 1)
        {
            MessageBox.Show("Kép mentési útvonal megadása kötelező!");
            return;
        }
        if (!MainView.Instance.Controls.ContainsKey("CameraControl"))
        {
            cameraCon = new CameraControl();
            cameraCon.Dock = DockStyle.Fill;
            MainView.Instance.Controls.Add(cameraCon);
            cameraCon.selectedCamera = cboCameras.SelectedIndex == -1 ? null : filterInfoCollection[cboCameras.SelectedIndex].MonikerString;
            cameraCon._imagesPath = txtSavePicturesPath.Text;
            cameraCon._pythonPath = txtPythonPath.Text;
        }
        MainView.Instance.cameraCon = cameraCon;
        MainView.Instance.Controls["CameraControl"].BringToFront();
        cameraCon.StartCamera();
        MainView.Instance.pnlImages.BringToFront();
    }

    /// <summary>
    /// A form betöltésekor lefutó eseménykezelő
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SetupControl_Load(object sender, EventArgs e)
    {
        // Összegyűjti az elérhető webkamerákat
        filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        if (filterInfoCollection.Count > 0)
        {
            foreach (FilterInfo filterinfo in filterInfoCollection)
            {
                cboCameras.Items.Add(filterinfo.Name);
            }
            cboCameras.SelectedIndex = 0;
        }
        try
        {
            string[] lines = File.ReadAllLines(configPath);
            txtPythonPath.Text = lines[0];
            txtSavePicturesPath.Text = lines[1];
            cboCameras.SelectedIndex = int.Parse(lines[2]);
        }
        catch { }



    }

    /// <summary>
    /// Mentési útvonal gomb esemnykezelője
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnSavePicturesPath_Click(object sender, EventArgs e)
    {
        using (var dialog = new FolderBrowserDialog())
        {
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtSavePicturesPath.Text = dialog.SelectedPath;
            }
        }
    }

    /// <summary>
    /// Python útvonal gomb eseménykezelője
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnPythonPath_Click(object sender, EventArgs e)
    {
        using (var dialog = new FolderBrowserDialog())
        {
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtPythonPath.Text = dialog.SelectedPath;
            }
        }
    }

    /// <summary>
    /// Elmenti a beállításokat
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnSave_Click(object sender, EventArgs e)
    {
        StringBuilder save = new StringBuilder();
        save.AppendLine(txtPythonPath.Text);
        save.AppendLine(txtSavePicturesPath.Text);
        save.AppendLine(cboCameras.SelectedIndex.ToString());
        save.Append(txtStationID);

        using (StreamWriter writer = new StreamWriter(configPath))
        {
            writer.Write(save.ToString());
        }

        MainView.Instance.Controls["CameraControl"]?.Dispose();
        MainView.Instance.Controls["ResultControl"]?.Dispose();
    }
}
