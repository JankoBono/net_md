using MD1;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MD2;

public partial class SubSaraksts : ContentPage
{
	public DbDataManeger dm;

    public SubSaraksts()
	{
        dm = App.dm;
        BindingContext = this;
        InitializeComponent();
	}

    public List<Submission> SubList
    {
        get
        {
            Debug.WriteLine("GetList");
            return dm.submissions;
        }
        set { dm.submissions = value; }
    }

    private async void EditClicked(object sender, EventArgs e)
    {
        var b = sender as Button;
        if (b != null)
        {
            if (b.BindingContext is Submission)
            {
                var ies = (Submission)b.BindingContext;
                var iesPage = new AddSubmission(ies);
                await Navigation.PushAsync(iesPage);
            }
        }
    }

    private void DeleteClicked(object sender, EventArgs e)
    {
        var b = sender as Button;
        if (b != null)
        {
            var f = b.BindingContext as Submission;
            if (f != null)
            {
                try
                {
                    dm.context.Submissions.Remove(f);
                    if (dm.Save())
                    {
                        BindingContext = null;
                        BindingContext = this;
                    }
                    else
                    {
                        DisplayAlert("K��da", "Neizdev�s dz�st iesniegumu no datub�zes.", "Labi");
                    }
                }
                catch (Exception ex)
                {
                    DisplayAlert("K��da", $"Dz��anas laik� rad�s k��da: {ex.Message}", "Labi");
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