using Projekt.Exception;
using System.Configuration;
using System.Diagnostics;
namespace Projekt.ImageProcess;

public class PythonExecute
{
    private readonly string pythonPath = ConfigurationManager.AppSettings["PythonPath"];
    private readonly string vectorPath = ConfigurationManager.AppSettings["VectorPath"];
    private readonly string learningDirectoryPath = ConfigurationManager.AppSettings["LearningDirectoryPath"];
    private readonly string queryImage = ConfigurationManager.AppSettings["QueryImagePath"];


    private string ExecutePython(string arguments)
    {
        string results = "";
        try
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.FileName = pythonPath + @"\python.exe";

            startInfo.Arguments = arguments;

            string errors;
            int exitCode;

            using (var process = Process.Start(startInfo))
            {
                errors = process.StandardError.ReadToEnd();
                results = process.StandardOutput.ReadToEnd();
                exitCode = process.ExitCode;
            }

            if (errors != "" && exitCode != 0)
            {
                throw new PythonExecuteException(errors);
            }
        }
        catch (System.ComponentModel.Win32Exception ex)
        {
            throw new PythonExecuteException(ex.Message);
        }
        return results;
    }

    public void CalculaterVectors()
    {
        var script = @"..\..\..\ImageProcess\indexing.py";
        string arguments = $"{script} -i {learningDirectoryPath} -o {vectorPath}";
        ExecutePython(arguments);
    }


    public void ProcessImage()
    {
        var script = @"..\..\..\ImageProcess\RemoveBg.py";
        string arguments = $"{script}";
        ExecutePython(arguments);
    }



    public string SearchSimilarPhoto()
    {
        var script = @"..\..\..\ImageProcess\search.py";
        string arguments = $"{script} -v {vectorPath} -q {queryImage}";
        return ExecutePython(arguments);
    }
}
