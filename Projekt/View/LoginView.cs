using Projekt.Controller;
using Projekt.Exception;
using Projekt.Model;
namespace Projekt.View;

public partial class LoginView : Form
{
    private readonly LoginController _loginController = new LoginController();
    public LoginView()
    {
        InitializeComponent();
        ActiveControl = txtLoginUsername;
        txtLoginPassword.KeyPress += new KeyPressEventHandler(CheckEnter);
        txtLoginUsername.KeyPress += new KeyPressEventHandler(CheckEnter);
        BackColor = ColorTranslator.FromHtml("#2E3349");
        Font = new Font("Berlin Sans FB", 12f);
        ForeColor = Color.White;
        ApplyTheme();
    }

    /// <summary>
    /// Beállítja a témat
    /// </summary>
    protected void ApplyTheme()
    {
        foreach (Control control in Controls)
        {
            if (control is Button)
            {
                Button button = (Button)control;
                button.BackColor = ColorTranslator.FromHtml("#181E36");
                button.ForeColor = Color.White;
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
            }
        }
    }

    /// <summary>
    /// Kilép az alkalmazásból
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnCancel_Click(object sender, EventArgs e) => Application.Exit();


    /// <summary>
    /// A bejelentkezés gomb eseménykezelője
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void btnLogin_Click(object sender, EventArgs e)
    {
        User user;
        btnLogin.Enabled = false;
        try
        {
            user = await _loginController.LogonUser(txtLoginUsername.Text, txtLoginPassword.Text);
            if (user == null)
                throw new LoginException("Hibás felhasználónév vagy jelszó!");

        }
        catch (LoginException ex)
        {
            MessageBox.Show(ex.Message);
            return;
        }
        finally
        {
            ActiveControl = txtLoginPassword;
            btnLogin.Enabled = true;
        }

        MainView _mainView = new MainView();
        _mainView.guid = user.Guid;
        _mainView.Show();
        Hide();
    }


    /// <summary>
    /// Enter gomb eseménykezelője
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void CheckEnter(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)13)
        {
            btnLogin_Click(sender, e);
        }
    }
}
