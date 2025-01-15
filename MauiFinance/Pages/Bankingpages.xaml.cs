using MauiFinance;

namespace Pages
{
    public partial class Bankingpages : ContentPage
    {
        public Bankingpages()
        {
            InitializeComponent();
        }

        // Arvutamise meetod
        private void OnCalculateBalanceClicked(object sender, EventArgs e)
        {
            if (double.TryParse(IncomeEntry.Text, out double income) &&
                double.TryParse(ExpenseEntry.Text, out double expense))
            {
                double balance = income - expense;
                BalanceLabel.Text = $"Saldo: {balance:C}";
            }
            else
            {
                BalanceLabel.Text = "Palun sisesta kehtivad summad.";
            }
        }

        // Järgmisele lehele liikumise meetod (FinalPage)
        private async void OnNavigateToFinalPageClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FinalPage());
        }

        // Eelmisele lehele liikumise meetod (MainPage)
        private async void OnNavigateToMainPageClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        // Liikumine Profile lehele
        private async void OnNavigateToProfilePageClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Profile()); // Siin muudame klassi nime
        }
    }
}
