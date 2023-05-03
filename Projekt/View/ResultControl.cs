using Projekt.Controller;
using Projekt.Exception;
using Projekt.Model;
using System.Text;

namespace Projekt.View;

public partial class ResultControl : MainControl
{

    #region Variables
    public static ResultControl instance;
    public TextBox textbox;
    public delegate void CameraDelegate(bool restart = false);
    private SearchResult _rowDetails = null;
    public event CameraDelegate StartCameraControl;
    private readonly ResultController _resultController = new ResultController();
    public List<SearchResult> searchResults = new List<SearchResult>();
    public Panel pnlImages = MainView.Instance.pnlImages;
    public string _imagesPath;

    #endregion


    public ResultControl()
    {
        InitializeComponent();
        ApplyTheme(Controls, Width);
        instance = this;
        textbox = txtTitle;
    }

    /// <summary>
    /// Visszalépés gomb eseménykezelője
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void btnBack_Click(object sender, EventArgs e)
    {
        MainView.Instance.Controls["CameraControl"].BringToFront();
        MainView.Instance.pnlImages.BringToFront();
        StartCameraControl?.Invoke();
    }


    /// <summary>
    /// Feltölti a Datagridview-t találatokkal, majd lazy loading-gal képekkel is
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void btnSearch_Click(object sender, EventArgs e)
    {
        EmptyTextboxes();

        await Search();
    }

    /// <summary>
    /// Kerés, majd Datagridview feltöltése
    /// </summary>
    /// <returns></returns>
    private async Task<bool> Search()
    {
        string keyword = txtTitle.Text.ToString().ToLower();
        try
        {
            searchResults = await Task.Run(() => _resultController.Search(new SearchModel
            {
                Guid = MainView.Instance.guid,
                Title = keyword,
                Author = txtAuthor.Text,
                ISBN = txtISBN.Text

            }));
        }
        catch (SearchException ex)
        {
            MessageBox.Show(ex.Message);
            return false;
        }
        if (searchResults.Count > 0)
        {
            var source = new BindingSource();
            source.DataSource = searchResults;
            dgdSearchResult.DataSource = source;

            if (!dgdSearchResult.Columns.Contains("Author"))
                dgdSearchResult.Columns.Add("Author", "Author");


            foreach (DataGridViewRow row in dgdSearchResult.Rows)
            {
                var database = row.Cells["Database"]?.Value;
                if (database != null && !(bool)database)
                {
                    row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#366FA9");
                }
            }

            #region Hide Columns
            dgdSearchResult.Columns["ID"].Visible = false;
            dgdSearchResult.Columns["Height"].Visible = false;
            dgdSearchResult.Columns["Width"].Visible = false;
            dgdSearchResult.Columns["Database"].Visible = false;
            dgdSearchResult.Columns["PhotoID"].Visible = false;
            #endregion

            int i = 0, columnWidht = 0;
            foreach (SearchResult result in searchResults)
            {
                if (result.Authors != null)
                    dgdSearchResult.Rows[i].Cells["Author"].Value = result.Authors[0].Trim();

                var image = (Bitmap)new ImageConverter().ConvertFrom(result.Photo);
                dgdSearchResult.Rows[i].Height = image.Height;
                columnWidht = Math.Max(columnWidht, image.Width);
                dgdSearchResult.Columns["Photo"].Width = columnWidht;
                DataGridViewImageColumn imageColumn = (DataGridViewImageColumn)dgdSearchResult.Columns["Photo"];
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;

                i++;
            }
        }
        else
        {
            dgdSearchResult.DataSource = null;
            MessageBox.Show("Nincs találat!");
            return false;
        }
        return true;
    }


    /// <summary>
    /// Elküldi az összegyűjtött információkat
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnSend_Click(object sender, EventArgs e)
    {
        if (_rowDetails == null)
        {
            MessageBox.Show("Nincs termék kiválasztva!");
            return;
        }
        if (txtWidth.Text == "" || txtHeight.Text == "" || txtWeight.Text == "")
        {
            MessageBox.Show("Méretek és súly kitöltése kötelező!");
            return;
        }
        try
        {
            List<string> imagePaths = SaveImages();

            var stationID = MainView.Instance.setupCon.txtStationID.Text;
            _rowDetails.Width = txtWidth.Text;
            _rowDetails.Height = txtHeight.Text;
            ResultMessage message = new ResultMessage(_rowDetails, stationID, imagePaths, txtWeight.Text);
            var result = _resultController.SendResult(message);

        }
        catch (System.Exception ex)
        {
            MessageBox.Show("Sikertelen küldés!\n" + ex.Message);
            return;
        }

        MessageBox.Show("Sikeres küldés!");


        btnSend.Visible = false;
        btnRestart.Visible = true;
    }


    /// <summary>
    /// Elmenti a képeket
    /// </summary>
    /// <returns></returns>
    private List<string> SaveImages()
    {
        var imagePaths = new List<string>();
        foreach (PicturePanel panel in pnlImages.Controls)
        {
            Image image = panel._pic.Image;
            string savePath = IndexedFilename(panel.Name);
            image.Save(savePath);
            imagePaths.Add(savePath);
        }
        pnlImages.Controls.Clear();

        return imagePaths;
    }

    /// <summary>
    /// Úra indítja a folyamatot
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnRestart_Click(object sender, EventArgs e)
    {
        MainView.Instance.Controls["CameraControl"].Dispose();
        MainView.Instance.Controls["ResultControl"].Dispose();
        MainView.Instance.Controls["SetupControl"].BringToFront();
    }

    /// <summary>
    /// Több információt gyűjt a kiválasztott sorról
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    private async Task SearchRowDetails(string ID)
    {
        try
        {
            _rowDetails = await Task.Run(() => _resultController.SearchRowDetailsByID(ID));
            txtHeight.Text = _rowDetails.Height?.ToString();
            txtWidth.Text = _rowDetails.Width?.ToString();
        }
        catch (SearchException ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    /// <summary>
    /// Cella kattintás eseménykezelője
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void dgdSearchResult_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        EmptyTextboxes();
        var selectedRow = dgdSearchResult.SelectedCells[0]?.OwningRow;
        _rowDetails = (SearchResult)selectedRow.DataBoundItem;

        if (!_rowDetails.Database)
        {
            string? selectedID = selectedRow.Cells["ID"]?.Value?.ToString();
            SearchRowDetails(selectedID);
            return;
        }

        txtHeight.Text = _rowDetails.Height?.ToString();
        txtWidth.Text = _rowDetails.Width?.ToString();
    }

    /// <summary>
    /// Kiüríti a textboxokat
    /// </summary>
    private void EmptyTextboxes()
    {
        foreach (Control txt in pnlDimensions.Controls)
            if (txt is TextBox) (txt as TextBox).Text = "";
    }

    /// <summary>
    /// Összeállítja a file mentési útvonalát, és indexeli a nevét ha már létezik
    /// </summary>
    /// <param name="ImgName"></param>
    /// <returns></returns>
    string IndexedFilename(string ImgName)
    {
        int ix = 0;
        StringBuilder save;

        do
        {
            ix++;
            save = new StringBuilder(_imagesPath, 100);
            save.Append("\\");
            save.Append(ImgName);
            save.Append("_");
            save.Append(ix.ToString());
            save.Append(".png");
        } while (File.Exists(save.ToString()));

        return save.ToString();
    }
}
