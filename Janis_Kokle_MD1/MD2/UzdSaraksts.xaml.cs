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

public partial class UzdSaraksts : ContentPage
{
    public DbDataManeger dm;
    public UzdSaraksts()
	{
        dm = App.dm;
        BindingContext = this;
        InitializeComponent();
    }
    public List<Assignement> UzdList
    {
        get
        {
            Debug.WriteLine("GetList");
            return dm.assignements;
        }
        set { dm.assignements = value; }
    }

    private async void EditClicked(object sender, EventArgs e)
    {
        var b = sender as Button;
        if (b != null)
        {
            if (b.BindingContext is Assignement)
            {
                var uzd = (Assignement)b.BindingContext;
                var uzdPage = new AddAssignement(uzd);
                await Navigation.PushAsync(uzdPage);
            }
        }
    }

    private void DeleteClicked(object sender, EventArgs e)
    {
        var b = sender as Button;
        if (b != null)
        {
            var p = b.BindingContext as Assignement;
            if (p != null)
            {
                try
                {
                    dm.context.Assignements.Remove(p);
                    if (dm.Save())
                    {
                        BindingContext = null;
                        BindingContext = this;
                    }
                    else
                    {
                        DisplayAlert("Kïûda", "Neizdevâs dzçst iesniegumu no datubâzes.", "Labi");
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