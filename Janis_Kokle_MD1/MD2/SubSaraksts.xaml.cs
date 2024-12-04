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

public partial class SubSaraksts : ContentPage
{
	public DataManager dm;

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
            return dm.Submissions;
        }
        set { dm.Submissions = value; }
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
            if (null != f)
            {
                dm.Submissions.Remove(f);
                BindingContext = null;
                BindingContext = this;
            }
        }
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = null;
        BindingContext = this;
    }
}