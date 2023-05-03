using Projekt.ImageProcess;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
namespace Projekt.Controller;

public class CameraController
{
    PythonExecute _pythonExecute = new PythonExecute();


    /// <summary>
    /// Meghívja a képet feldolgozó Python kódot
    /// </summary>
    /// <param name="pythonPath"></param>
    /// <returns></returns>
    public Task ImageProcess(string pythonPath)
    {
        _pythonExecute.ExecutePython(pythonPath);

        return Task.CompletedTask;
    }


    /// <summary>
    /// Arányokat megtartva újraméretezi a képet a megadott szélesség és magasság alapján
    /// </summary>
    /// <param name="image"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    public Bitmap ResizeImage(Image image, int width, int height)
    {
        var destRect = new Rectangle(0, 0, width, height);
        var destImage = new Bitmap(width, height);

        destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

        using (var graphics = Graphics.FromImage(destImage))
        {
            graphics.CompositingMode = CompositingMode.SourceCopy;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            using (var wrapMode = new ImageAttributes())
            {
                wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
            }
        }

        return destImage;
    }
}
