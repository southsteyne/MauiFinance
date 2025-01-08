using MauiFinance.ViewModels;

namespace Pages;

public partial class FinalPage : ContentPage
{
    public FinalPage()
    {
        InitializeComponent();

        // Seome ViewModel lehe külge
        BindingContext = new FinalPageViewModel();
    }
}
