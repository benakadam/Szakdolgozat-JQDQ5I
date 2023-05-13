using AForge.Video.DirectShow;
using Projekt.Controller;
using Projekt.Exception;
using System.Configuration;
using System.Xml.Linq;

namespace Projekt.View;

public partial class SetupControl : MainControl
{
    CameraControl cameraCon;
    public delegate void CameraDelegate(bool restart = false);
    public event CameraDelegate StartCameraControl;
    FilterInfoCollection filterInfoCollection;
    private readonly string configPath = ConfigurationManager.AppSettings["ConfigPath"];
    private readonly string vectorPath = ConfigurationManager.AppSettings["VectorPath"];
    readonly SetupController _setupController = new SetupController();


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
        }
        MainView.Instance.cameraCon = cameraCon;
        MainView.Instance.Controls["CameraControl"].BringToFront();
        cameraCon.StartCamera();
        MainView.Instance.pnlImages.BringToFront();

        CalculateVectors();
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
            XDocument document = XDocument.Load(configPath);
            if (document.Root == null) return;

            txtPythonPath.Text = document.Root.Element("pythonPath")?.Value ?? "";
            txtSavePicturesPath.Text = document.Root.Element("savePicturesPath")?.Value ?? "";
            cboCameras.SelectedIndex = int.TryParse(document.Root.Element("selectedCameraIndex")?.Value, out int selectedIndex) ? selectedIndex : 0;
            txtLearningDirectoryPath.Text = document.Root.Element("learningDirectoryPath")?.Value ?? "";
            txtStationID.Text = document.Root.Element("stationID")?.Value ?? "";
        }
        catch (InvalidOperationException _)
        {
            if (File.Exists(configPath)) File.Delete(configPath);           
        }
        catch (FileNotFoundException _){ }

        SavePaths();

    }

    /// <summary>
    /// Mentési útvonal gomb esemnykezelője
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnSavePicturesPath_Click(object sender, EventArgs e) => txtSavePicturesPath.Text = GetPathFromDialoge();


    /// <summary>
    /// Python útvonal gomb eseménykezelője
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnPythonPath_Click(object sender, EventArgs e) => txtPythonPath.Text = GetPathFromDialoge();


    /// <summary>
    /// Tanító könyvtár gomb eseménykezelője
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnLearningDirectory_Click(object sender, EventArgs e)
    {
        string path = GetPathFromDialoge();
        if (path == "") return;
        string[] files = Directory.GetFiles(path);

        foreach (string file in files)
        {
            string extension = Path.GetExtension(file);

            if (extension != ".jpg" && extension != ".jpeg" && extension != ".png")
            {
                MessageBox.Show("A könyvtár nem csak képeket tartalmaz!");
                return;
            }
        }
        txtLearningDirectoryPath.Text = path;
    }

    /// <summary>
    /// Lekérdezi az útvonalat a dialógusból
    /// </summary>
    /// <returns></returns>
    private string GetPathFromDialoge()
    {
        using (var dialog = new FolderBrowserDialog())
        {
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.SelectedPath;
            }
            return "";
        }

    }

    /// <summary>
    /// Elmenti a beállításokat
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnSave_Click(object sender, EventArgs e)
    {
        XDocument document = new XDocument(
            new XElement("config",
                new XElement("pythonPath", txtPythonPath.Text),
                new XElement("savePicturesPath", txtSavePicturesPath.Text),
                new XElement("selectedCameraIndex", cboCameras.SelectedIndex),
                new XElement("learningDirectoryPath", txtLearningDirectoryPath.Text),
                new XElement("stationID", txtStationID.Text)
            )
        );

        using (StreamWriter writer = new StreamWriter(configPath))
        {
            writer.Write(document.ToString());
        }


        SavePaths();

        MainView.Instance.Controls["CameraControl"]?.Dispose();
        MainView.Instance.Controls["ResultControl"]?.Dispose();
    }

    private async Task CalculateVectors()
    {
        try
        {
            if (string.IsNullOrEmpty(txtLearningDirectoryPath.Text)) return;
            if (!File.Exists(vectorPath))
                await Task.Run(() => _setupController.CalculateVectors());
        } catch (PythonExecuteException ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    void SavePaths()
    {
        _setupController.RefreshAppSettings("PythonPath", txtPythonPath.Text);
        _setupController.RefreshAppSettings("ImagesSavePath", txtSavePicturesPath.Text);
        _setupController.RefreshAppSettings("LearningDirectoryPath", txtLearningDirectoryPath.Text);
    }




}
