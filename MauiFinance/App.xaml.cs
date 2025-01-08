using Pages;

namespace MauiFinance;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new FinalPage();
    }
}
