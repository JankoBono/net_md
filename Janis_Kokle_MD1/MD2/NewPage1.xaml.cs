using MD1;

namespace MD2;

public partial class NewPage1 : ContentPage
{
    private IAddStudent _dm;
    public DbDataManeger dm1;
    public NewPage1()
	{
		InitializeComponent();
		_dm = App.dm;
        Dzimums.SelectedIndex = 0;
        dm1 = App.dm;

    }
    private Student _st;
    public NewPage1(Student uzd)
    {
        InitializeComponent();
        _st = uzd;
        _dm = App.dm;
        dm1 = App.dm;

        Ievade1.Text = _st.Name.ToString();
        Ievade2.Text = _st.Surname.ToString();
        Ievade3.Text = _st.StudentIdNumber.ToString();
        Dzimums.SelectedItem = _st.Gender;

        Poga.IsVisible = false;
        EditPoga.IsVisible = true;

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
    private void PogaclickEdit(object sender, EventArgs e)
    {
        _st.Name = Ievade1.Text;
        _st.Surname = Ievade2.Text;
        _st.Gender = (Gender)Enum.Parse(typeof(Gender), (String)Dzimums.SelectedItem);
        _st.StudentIdNumber = Ievade3.Text;


        Rezult.Text = _st.ToString();
    }

}