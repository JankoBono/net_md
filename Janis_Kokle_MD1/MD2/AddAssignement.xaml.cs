using MD1;


namespace MD2;

public partial class AddAssignement : ContentPage
{
    private IAddAssignement _dm;
    public DataManager dm1;

    public AddAssignement()
	{
        InitializeComponent();
        _dm = App.dm;
        dm1 = App.dm;


        // Picker elementam iedod kursa iespējamās vērtības
        CoursePicker.ItemsSource = dm1.GetCourse();
    }
    private Assignement _uzd;
    public AddAssignement(Assignement uzd)
    {
        InitializeComponent();
        _uzd = uzd;
        _dm = App.dm;
        dm1 = App.dm;
        // atkārtoti iedod picker elementam iespējamās vērtības
        CoursePicker.ItemsSource = dm1.GetCourse();

        Ievade4.Text = _uzd.Description.ToString();
        datePicker.Date = _uzd.Deadline;
        CoursePicker.SelectedItem = _uzd.Course;

        AddPoga.IsVisible = false;
        EditPoga.IsVisible = true;

    }

    public void Pogaclick(object sender, EventArgs e)
    {
        string d = Ievade4.Text;
        DateTime selectedDate = datePicker.Date;
        Course kurss = CoursePicker.SelectedItem as Course;

        var uzd = new Assignement
        {
            Deadline = selectedDate,
            Course = kurss,
            Description = d
        };
        RezultUzd.Text = uzd.ToString();
        _dm.AddAssignement(uzd);

    }

    private void PogaclickEdit(object sender, EventArgs e)
    {
        _uzd.Description = Ievade4.Text;
        _uzd.Deadline = datePicker.Date;
        _uzd.Course = CoursePicker.SelectedItem as Course;

        RezultUzd.Text = _uzd.ToString();
    }
}