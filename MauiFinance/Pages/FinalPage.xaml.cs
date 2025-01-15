using Microsoft.Maui.Controls;

namespace Pages;

public partial class FinalPage : ContentPage
{
    public FinalPage()
    {
        InitializeComponent();

        // Seome nupu toimingu käsu, et viia tagasi MainPage-le
        var backButton = this.FindByName<Button>("BackToHomeButton");
        backButton.Clicked += OnBackToHomeButtonClicked;
    }

    // Funktsioon, mis viib tagasi MainPage-le
    private async void OnBackToHomeButtonClicked(object sender, EventArgs e)
    {
        // Siin kasutame Navigation.PopAsync() et viia tagasi eelnevalt avatud lehele (MainPage)
        await Navigation.PopAsync();  // Kui kasutatakse navigationi Stack
        // Või, kui kasutad shelli navigeerimist
        // await Shell.Current.GoToAsync("//MainPage");
    }
}
