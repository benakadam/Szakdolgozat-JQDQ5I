using Projekt.Exception;
using System.Diagnostics;
namespace Projekt.ImageProcess;

public class PythonExecute
{


    /// <summary>
    /// Meghívja a képet feldolgozó Python kódot
    /// </summary>
    /// <param name="pythonPath"></param>
    /// <exception cref="ImageProcessException"></exception>
    public void ExecutePython(string pythonPath)
    {
        try
        {
            var psi = new ProcessStartInfo();
            psi.FileName = pythonPath + @"\python.exe";

            var script = @"..\..\..\ImageProcess\RemoveBg.py";

            psi.Arguments = $"\"{script}\"";

            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;

            var errors = "";
            var results = "";

            using (var process = Process.Start(psi))
            {
                errors = process.StandardError.ReadToEnd();
                results = process.StandardOutput.ReadToEnd();
            }

            if (errors != "")
            {
                throw new ImageProcessException(errors);
            }
        }catch (System.ComponentModel.Win32Exception ex)
        {
            throw new ImageProcessException(ex.Message);
        }
    }
}
