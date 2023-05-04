using Projekt.Exception;
using System.Configuration;
using System.Diagnostics;
namespace Projekt.ImageProcess;

public class PythonExecute
{
    private readonly string snapshotPath = ConfigurationManager.AppSettings["SnapshotPath"];
    private readonly string croppedImage = ConfigurationManager.AppSettings["CroppedImagePath"];



    /// <summary>
    /// Meghívja a képet feldolgozó Python kódot
    /// </summary>
    /// <exception cref="ImageProcessException"></exception>
    public void ExecutePython(string pythonPath)
    {

        try
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = @$"/C rembg i {snapshotPath} {croppedImage}";

            var errors = "";
            var results = "";

            using (var process = Process.Start(startInfo))
            {
                errors = process.StandardError.ReadToEnd();
                results = process.StandardOutput.ReadToEnd();
            }

            if (errors != "")
            {
                throw new ImageProcessException(errors);
            }
        }
        catch (System.ComponentModel.Win32Exception ex)
        {
            throw new ImageProcessException(ex.Message);
        }
    }
}
