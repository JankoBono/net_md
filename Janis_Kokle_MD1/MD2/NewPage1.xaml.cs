using MD1;

namespace MD2;

public partial class NewPage1 : ContentPage
{
    private IAddStudent _dm;
    public NewPage1()
	{
		InitializeComponent();
		_dm = App.dm;
        Dzimums.SelectedIndex = 0;

    }

	public void Pogaclick(object sender, EventArgs e)
	{
		string vards = Ievade1.Text;
        string uzvards = Ievade2.Text;
        string id = Ievade3.Text;

        var skol = new Student(vards,uzvards,Gender.Man, id);
        skol.Gender = (Gender)Enum.Parse(typeof(Gender), (String)Dzimums.SelectedItem);
        Rezult.Text = skol.ToString();
		_dm.AddPerson(skol);

    }

}