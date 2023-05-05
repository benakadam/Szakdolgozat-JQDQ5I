using AForge.Video.DirectShow;
using Projekt.Controller;
using System.Configuration;
using System.Xml.Serialization;

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
            XmlSerializer serializer = new XmlSerializer(typeof(Config));
            Config config = new Config();
            using (StreamReader reader = new StreamReader(configPath))
            {
                config = (Config)serializer.Deserialize(reader);
            }

            txtPythonPath.Text = config.PythonPath;
            txtSavePicturesPath.Text = config.SavePicturesPath;
            cboCameras.SelectedIndex = config.SelectedCameraIndex;
            txtLearningDirectoryPath.Text = config.LearningDirectoryPath;
            txtStationID.Text = config.StationID;
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
        Config config = new Config()
        {
            PythonPath = txtPythonPath.Text,
            SavePicturesPath = txtSavePicturesPath.Text,
            SelectedCameraIndex = cboCameras.SelectedIndex,
            LearningDirectoryPath = txtLearningDirectoryPath.Text,
            StationID = txtStationID.Text
        };

        XmlSerializer serializer = new XmlSerializer(typeof(Config));

        using (StreamWriter writer = new StreamWriter(configPath))
        {
            serializer.Serialize(writer, config);
        }

        SavePaths();

        MainView.Instance.Controls["CameraControl"]?.Dispose();
        MainView.Instance.Controls["ResultControl"]?.Dispose();
    }

    private async Task CalculateVectors()
    {
        if (string.IsNullOrEmpty(txtLearningDirectoryPath.Text)) return;
        if (!File.Exists(vectorPath))
            await Task.Run(() => _setupController.CalculateVectors());
        
    }

    void SavePaths()
    {
        _setupController.RefreshAppSettings("PythonPath", txtPythonPath.Text);
        _setupController.RefreshAppSettings("ImagesSavePath", txtSavePicturesPath.Text);
        _setupController.RefreshAppSettings("LearningDirectoryPath", txtLearningDirectoryPath.Text);
    }




}
