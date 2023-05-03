namespace Projekt.View;


/// <summary>
/// Az alkalmazás fő ablaka
/// </summary>
public partial class MainView : Form
{
    private static MainView instance;
    public CameraControl cameraCon;
    public SetupControl setupCon;
    public string guid;



    public static MainView Instance
    {
        get
        {
            if (instance == null)
                instance = new MainView();
            return instance;

        }
    }
    public MainView()
    {
        InitializeComponent();
        pnlImages.BackColor = ColorTranslator.FromHtml("#252A40");
        instance = this;
    }


    /// <summary>
    /// Példányosítja az elsőnek megjelenítendő oldalt
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void MainView_Load(object sender, EventArgs e)
    {
        SetupControl control = new SetupControl();
        control.Dock = DockStyle.Fill;
        Instance.Controls.Add(control);
        setupCon = control;
        Instance.Controls["SetupControl"].Show();
        Instance.Controls["SetupControl"].BringToFront();
    }


    /// <summary>
    /// Bezárja az alkalmazást
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void MainView_FormClosing(object sender, FormClosingEventArgs e)
    {
        cameraCon?.Dispose();
        Application.Exit();
    }
}