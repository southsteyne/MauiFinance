using MauiFinance.ViewModels;

namespace Pages;

public partial class FinalPage : ContentPage
{
    public FinalPage()
    {
        InitializeComponent();

        // Seome ViewModel lehe k�lge
        BindingContext = new FinalPageViewModel();
    }
}
