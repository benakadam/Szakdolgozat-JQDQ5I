using Projekt.Model;
namespace Projekt.IManager;

public interface ILoginManager
{

    public Task<User> LogonUser(string username, string password);

}
