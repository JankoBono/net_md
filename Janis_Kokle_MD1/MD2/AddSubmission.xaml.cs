using MD1;

namespace MD2;

public partial class AddSubmission : ContentPage
{
    private IAddSubmission _dm;
    public DataManager dm1;
    public AddSubmission()
	{
		InitializeComponent();
        _dm = App.dm;
        dm1 = App.dm;

        // Picker elementam iedod iespējamās vērtības
        UzdPicker.ItemsSource = dm1.GetAssignements();
        StuPicker.ItemsSource = dm1.GetStudents();

    }
    private Submission _ies;

    public AddSubmission(Submission ies)
    {
        InitializeComponent();
        _ies = ies;
        _dm = App.dm;
        dm1 = App.dm;
        // atkārtoti iedod picker elementam iespējamās vērtības
        UzdPicker.ItemsSource = dm1.GetAssignements();
        StuPicker.ItemsSource = dm1.GetStudents();

        Rez.Text = _ies.Score.ToString();
        datePicker.Date = _ies.SubmissionTime;
        StuPicker.SelectedItem = _ies.Student;
        UzdPicker.SelectedItem = _ies.Assignement;

        AddPoga.IsVisible = false;
        EditPoga.IsVisible = true;

    }

    public void Pogaclick(object sender, EventArgs e)
    {
        try
        {
            // izpildās, ja skaitlis ir ievadīts korekti
            int d = int.Parse(Rez.Text);
            DateTime selectedDate = datePicker.Date;

            // Piešķir vērtību objektu mainīgajiem no picker elementiem
            Student students = StuPicker.SelectedItem as Student;
            Assignement uzdevums = UzdPicker.SelectedItem as Assignement;

            // izveido jaunu objektu ar ievadītajām vērtībām
            var ies = new Submission
            {
                Assignement = uzdevums,
                Student = students,
                SubmissionTime = selectedDate,
                Score = d
            };
            RezultUzd.Text = ies.ToString();
            _dm.AddSubmission(ies);
        }
        catch (FormatException)
        {
            // Uzrāda kļūdu, ja ir ievadītais nav skaitlis
            RezultUzd.Text = "Šis nav skaitlis, ievadi derīgu skaitli";
        }
        catch (OverflowException)
        {
            // Uzrāda kļūdu, ja skaitlis ir pārāk liels
            RezultUzd.Text = "Skaitlis ir pārāk liels";
        }
        catch (Exception ex)
        {
            // Uzķer jebkuru kļūdu, iavadot to, nenokar sistēmu
            RezultUzd.Text = $"Uzradās kļūda: {ex.Message}";
        }


    }

    private void PogaclickEdit(object sender, EventArgs e)
    {
        _ies.Score = int.Parse(Rez.Text);
        _ies.SubmissionTime = datePicker.Date;
        _ies.Student = StuPicker.SelectedItem as Student;
        _ies.Assignement = UzdPicker.SelectedItem as Assignement;

        RezultUzd.Text = _ies.ToString();
    }

}