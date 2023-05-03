using Projekt.Model;
using System.Text;
using System.Security.Cryptography;
using Projekt.IManager;
using Projekt.Manager;
namespace Projekt.Controller;

public class LoginController
{
    private readonly ILoginManager _loginManager = new LoginManager();

    /// <summary>
    /// Bejelentkezteti a felhasználót
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public async Task<User> LogonUser(string username, string password)
    {
        string securePassword = EncryptSHA1(password);
        var result = await _loginManager.LogonUser(username, securePassword);

        return result;
    }

    /// <summary>
    /// A megadott szöveget hasheli SHA1 használatával
    /// </summary>
    /// <param name="input">Hashelendő szöveg</param>
    /// <returns>Hash</returns>
    public string EncryptSHA1(string input)
    {
        string salt = "?RNQue?NpX.-E:<JH3'+";
        string result = String.Empty;
        using (SHA1 sha = new SHA1CryptoServiceProvider())
        {
            var byteResult = sha.ComputeHash(Encoding.Unicode.GetBytes(input + salt));
            //hash stringgé alakítása
            result = String.Concat(byteResult.Select(b => b.ToString("x2")));
        }

        return result;
    }
}
