using MD1;
using Microsoft.Maui.ApplicationModel.DataTransfer;
using Microsoft.Maui.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace MD2;

public partial class StSaraksts : ContentPage
{
    public DbDataManeger dm;

    public StSaraksts()
    {
        dm = App.dm;
        BindingContext = this;
        InitializeComponent();
    }

    public List<Student> StList
    {
        get
        {
            Debug.WriteLine("GetList");
            return dm.studenti;
        }
        set { dm.studenti = value; }
    }

    private async void EditClicked(object sender, EventArgs e)
    {
        var b = sender as Button;
        if (b != null)
        {
            if (b.BindingContext is Student)
            {
                var st = (Student)b.BindingContext;
                var stPage = new NewPage1(st);
                await Navigation.PushAsync(stPage);
            }
        }
    }

    private void DeleteClicked(object sender, EventArgs e)
    {
        var b = sender as Button;
        if (b != null)
        {
            var f = b.BindingContext as Student;
            if (f != null)
            {
                try
                {
                    dm.context.Studenti.Remove(f);
                    if (dm.Save())
                    {
                        BindingContext = null;
                        BindingContext = this;
                    }
                    else
                    {
                        DisplayAlert("Kïûda", "Neizdevâs dzçst studentu no datubâzes.", "Labi");
                    }
                }
                catch (Exception ex)
                {
                    DisplayAlert("Kïûda", $"Dzçðanas laikâ radâs kïûda: {ex.Message}", "Labi");
                }
            }
        }
    }


    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = null;
        BindingContext = this;
    }
}
