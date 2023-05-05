using Projekt.ImageProcess;
using System.Configuration;

namespace Projekt.Controller;
public class SetupController
{
    PythonExecute _pythonExecute = new PythonExecute();



    public async Task CalculateVectors()
    {
        _pythonExecute.CalculaterVectors();
    }

    public void RefreshAppSettings(string where, string text)
    {
        Configuration appSettings = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        appSettings.AppSettings.Settings[where].Value = text;
        appSettings.Save(ConfigurationSaveMode.Modified);
        ConfigurationManager.RefreshSection("appSettings");
    }
}
