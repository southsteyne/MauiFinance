using Pages;

namespace MauiFinance
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnNavigateClicked(object sender, EventArgs e)
        {
            count++;

            await Navigation.PushAsync(new Bankingpages());
        }
    }

}
