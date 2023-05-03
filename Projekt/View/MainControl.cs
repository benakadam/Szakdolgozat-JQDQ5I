using System.Configuration;

namespace Projekt.View;


/// <summary>
/// Minden Control szülője, ahol egységes témát és fejlécet kap
/// </summary>
public partial class MainControl : UserControl
{
    protected Color _mainColor = ColorTranslator.FromHtml(ConfigurationManager.AppSettings["MainColor"]);
    protected Color _secondaryColor = ColorTranslator.FromHtml("#252A40");
    protected Color _buttonColor = ColorTranslator.FromHtml("#181E36");
    public Button btnExit = new Button();
    public Button btnMinimize = new Button();
    public Panel titleBar = new Panel();

    private bool isDragging = false;
    private Point lastCursor;
    private Point lastForm;
    public MainControl()
    {
        InitializeComponent();
        BackColor = _mainColor;
        Font = new Font("Berlin Sans FB", 12f);
        ForeColor = Color.White;

        btnExit.Text = "X";
        btnExit.Height = 30;
        btnExit.Click += new EventHandler(Exit);
        Controls.Add(btnExit);

        btnMinimize.Text = "-";
        btnMinimize.Height = 30;
        btnMinimize.Font = new Font("Berlin Sans FB", 16f);
        btnMinimize.Click += new EventHandler(Minimize);
        Controls.Add(btnMinimize);

        titleBar.BackColor = Color.White;
        titleBar.MouseDown += new MouseEventHandler(TitleBar_MouseDown);
        titleBar.MouseUp += new MouseEventHandler(TitleBar_MouseUp);
        titleBar.MouseMove += new MouseEventHandler(TitleBar_MouseMove);
        Controls.Add(titleBar);
    }

    /// <summary>
    /// Kilép az alkalmazásból
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void Exit(object sender, EventArgs e) => Application.Exit();

    /// <summary>
    /// Tálcára helyezi az alkalmazást
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void Minimize(object sender, EventArgs e) => ParentForm.WindowState = FormWindowState.Minimized;


    /// <summary>
    /// Beállítja a témát
    /// </summary>
    /// <param name="controls"></param>
    /// <param name="width"></param>
    protected void ApplyTheme(ControlCollection controls, int width = -1)
    {
        if (width > -1)
        {
            btnExit.Location = new Point(width - btnExit.Width, 0);
            btnMinimize.Location = new Point(btnExit.Location.X - btnMinimize.Width - 5, 0);
            titleBar.Width = width;
            titleBar.Height = btnExit.Height;
        }
        
        foreach (Control control in controls)
        {
            if (control is Button)
            {
                Button button = (Button)control;
                button.ForeColor = Color.White;
                button.BackColor = _buttonColor;
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
            }
            if (control is DataGridView)
            {
                DataGridView datagrid = (DataGridView)control;
                datagrid.ForeColor = Color.Black;
                datagrid.BackgroundColor = _secondaryColor;
            }
            if (control is Panel)
            {
                control.BackColor = _secondaryColor;
                ApplyTheme(control.Controls);
            }
        }
    }

    /// <summary>
    /// Fejlécre kattintás eseméynkezelője
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TitleBar_MouseDown(object sender, MouseEventArgs e)
    {
        isDragging = true;
        lastCursor = Cursor.Position;
        lastForm = ParentForm.Location;
    }

    /// <summary>
    /// Fejléc mozgatás vége eseméynkezelője
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TitleBar_MouseUp(object sender, MouseEventArgs e) => isDragging = false;

    /// <summary>
    /// Fejléc mozgatás eseméynkezelője
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TitleBar_MouseMove(object sender, MouseEventArgs e)
    {
        if (isDragging)
        {
            int dx = Cursor.Position.X - lastCursor.X;
            int dy = Cursor.Position.Y - lastCursor.Y;
            ParentForm.Location = new Point(lastForm.X + dx, lastForm.Y + dy);
        }
    }
}
