using System.Windows.Input;

namespace MauiFinance.ViewModels;

public class FinalPageViewModel
{
    public ICommand NavigateToMainPageCommand { get; }

    public FinalPageViewModel()
    {
        NavigateToMainPageCommand = new Command(NavigateToMainPage);
    }

    private void NavigateToMainPage()
    {
        Application.Current.MainPage = new Pages.MainPage();
    }
}
