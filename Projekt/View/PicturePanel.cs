using System.Text;

namespace Projekt.View;

/// <summary>
/// Egy panelre helyezett képet reprezentál
/// </summary>
public class PicturePanel : Panel
{
    public string Name { get; set; }

    private Label _title;
    private Button _btnExit;
    public PictureBox _pic;
    private int _pnlImageWidth = 137;
    private int _pnlImageHeight = 137;
    private int _pnlImageDistance = 13;
    public Panel pnlImages = MainView.Instance.pnlImages;

    public PicturePanel(string title, Image image)
    {
        #region SetPicBox
        _pic = new PictureBox();
        _pic.Image = image;
        Name = GetImageName(title);
        _pic.Height = _pnlImageHeight;
        _pic.Width = _pnlImageWidth;
        _pic.SizeMode = PictureBoxSizeMode.StretchImage;
        Controls.Add(_pic);
        #endregion

        #region SetLabel
        _title = new Label();
        _title.Text = title;
        _title.TextAlign = ContentAlignment.MiddleCenter;
        _title.BackColor = Color.Transparent;
        _title.ForeColor = Color.White;
        _title.Location = new Point((_pic.Width - _title.Width) / 2, _pic.Height);
        Controls.Add(_title);
        #endregion

        #region SetButton
        _btnExit = new Button();
        _btnExit.Text = "X";
        _btnExit.Size = new Size(21, 25);
        _btnExit.BackColor = SystemColors.ButtonFace;
        _btnExit.ForeColor = Color.Black;
        _btnExit.Location = new Point(_pic.Width - _btnExit.Width, 0);
        _btnExit.Click += Dispose;
        _btnExit.MouseEnter += OnMouseEnter;
        _btnExit.MouseLeave += OnMouseLeave;
        _pic.Controls.Add(_btnExit);
        #endregion

        Height = _pnlImageHeight + _title.Height;
        Width = _pnlImageWidth;
        pnlImages.Controls.Add(this);
        ReorderImages();
    }

    /// <summary>
    /// Megszünteti az objektumot
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void Dispose(object _, EventArgs e)
    {
        Dispose();
        ReorderImages();
    }


    /// <summary>
    /// Felépíti a kép mentési nevét
    /// </summary>
    /// <param name="title"></param>
    /// <returns></returns>
    string GetImageName(string title)
    {
        StringBuilder ImgName = new StringBuilder();
        ImgName.Append(title);
        ImgName.Append("_");
        ImgName.Append(DateTime.Now.ToString("yyyy_MM_dd").ToString());
        return ImgName.ToString();
    }


    /// <summary>
    /// Törlés gomb színváltoztató eseménykezelője
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnMouseEnter(object sender, EventArgs e)
    {
        ((Button)sender).BackColor = Color.Red;
        ((Button)sender).ForeColor = Color.White;

    }


    /// <summary>
    /// Törlés gomb színváltoztató eseménykezelője
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnMouseLeave(object sender, EventArgs e)
    {
        ((Button)sender).BackColor = SystemColors.ButtonFace;
        ((Button)sender).ForeColor = Color.Black;

    }


    /// <summary>
    /// Sorbarendezi a képeket
    /// </summary>
    private void ReorderImages()
    {
        int xPic = _pnlImageDistance, xLbl = _pnlImageDistance;
        foreach (Control control in pnlImages.Controls)
        {
            control.Location = new Point(xPic, 0);
            xPic += _pnlImageWidth + _pnlImageDistance;       
        }
    }

}
