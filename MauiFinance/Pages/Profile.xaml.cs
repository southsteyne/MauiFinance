using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Pages;

namespace MauiFinance
{
    public partial class Profile : ContentPage
    {
        public ObservableCollection<Transaction> RecentTransactions { get; set; }
        private decimal accountBalance = 0m;
        private CancellationTokenSource cancellationTokenSource;

        public Profile()
        {
            InitializeComponent();
            RecentTransactions = new ObservableCollection<Transaction>();
            transactionsCollection.ItemsSource = RecentTransactions;
            UpdateBalanceLabel();

            // Alusta automaatset tehingute lisamist
            StartAutoAddingTransactions();
        }

        private void UpdateBalanceLabel()
        {
            lblAccountBalance.Text = $"{accountBalance:F2} €";
        }

        private async void AddTransaction()
        {
            var newTransaction = new Transaction
            {
                Description = "Automaatne tehing",
                Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm"),
                Amount = new Random().Next(-50, 101) // Random summa (-50 kuni 100 €)
            };

            // Lisa uus tehing ja uuenda saldo
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                // Lisa uus tehing algusesse
                RecentTransactions.Insert(0, newTransaction);

                accountBalance += newTransaction.Amount;
                UpdateBalanceLabel();

                // Sujuv liikumisanimatsioon (kasutame lihtsalt CollectionView elementide muutumist)
                await Task.Delay(100); // Lühike viivitus, et animatsioon oleks märgatav
            });
        }

        private async void StartAutoAddingTransactions()
        {
            cancellationTokenSource = new CancellationTokenSource();
            var token = cancellationTokenSource.Token;

            try
            {
                while (!token.IsCancellationRequested)
                {
                    AddTransaction();
                    await Task.Delay(5000, token); // 5-sekundiline viivitus
                }
            }
            catch (TaskCanceledException)
            {
                // Ignoreeri katkestatud ülesande erandit
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            // Katkesta taimer, kui leht kaob ekraanilt
            cancellationTokenSource?.Cancel();
        }

        // Tagasi liikumine eelmisel lehele
        private async void OnNavigateBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        // Edasi liikumine FAQ lehele
        private async void OnNavigateForwardClicked(object sender, EventArgs e)
        {
            // Siin saad määrata, kuhu edasi liikuda. Näiteks FAQ leht:
            await Navigation.PushAsync(new FinalPage());
        }
    }

    public class Transaction
    {
        public string Description { get; set; }
        public string Date { get; set; }
        public decimal Amount { get; set; }
    }
}
