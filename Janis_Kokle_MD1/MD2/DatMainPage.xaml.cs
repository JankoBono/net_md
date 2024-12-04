using MD1;
using System.Xml;

namespace MD2;

public partial class DatMainPage : ContentPage
{
    public IDataManager dm;
    public DatMainPage()
	{
		InitializeComponent();
        dm = App.dm;
    }
    private void btnPrint_Clicked(object sender, EventArgs e)
    {
        lblText.Text = dm.Print();
    }

    public void btnLoad_Clicked(object sender, EventArgs e)
    {
        dm.Load();
        lblText.Text = "Dati ir ielādēti!";
    }

    public void btnSave_Clicked(object sender, EventArgs e)
    {
        dm.Save();
        lblText.Text = "Dati ir saglabāti!";
    }

    private void btnCreate_Clicked(object sender, EventArgs e)
    {
        dm.CreateTestData();
        lblText.Text = "Testa dati ir izveidoti!";
    }

    private void btnReset_Clicked(object sender, EventArgs e)
    {
        dm.Reset();
        lblText.Text = "Dati ir izdzēsti!";
    }
}