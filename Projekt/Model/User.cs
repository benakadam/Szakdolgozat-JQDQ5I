namespace Projekt.Model;


/// <summary>
/// Bejelentkezett felhasználót reprezentál
/// </summary>
public class User
{
    public string Guid { get; set; }
    public string LoginName { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string EncryptedPassword { get; set; }
}
