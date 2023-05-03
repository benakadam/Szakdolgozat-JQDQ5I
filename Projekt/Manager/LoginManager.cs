using Projekt.Communication;
using Projekt.Exception;
using Projekt.IManager;
using Projekt.Model;
using System.Configuration;
namespace Projekt.Manager;

public class LoginManager : ILoginManager
{


    /// <summary>
    /// Bejelentkezteti a felhasználót
    /// </summary>
    /// <exception cref="LoginException"></exception>
    public async Task<User> LogonUser(string username, string securedPassword)
    {
        throw new NotImplementedException();
    }
}
