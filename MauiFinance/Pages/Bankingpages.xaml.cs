namespace Pages;

public partial class Bankingpages : ContentPage
{
    public Bankingpages()
    {
        InitializeComponent();
    }
    // Arvutamise meetod
    private void OnCalculateBalanceClicked(object sender, EventArgs e)
    {
        // Proovime muuta tekstiv‰li numbriks, kui kasutaja sisestas v‰‰rtuse
        if (double.TryParse(IncomeEntry.Text, out double income) &&
            double.TryParse(ExpenseEntry.Text, out double expense))
        {
            // Arvutame saldo
            double balance = income - expense;
            BalanceLabel.Text = $"Saldo: {balance:C}"; // Kuvatakse saldo
        }
        else
        {
            // Kui kasutaja sisestatud v‰‰rtused pole numbrid, kuvame teate
            BalanceLabel.Text = "Palun sisesta kehtivad summad.";
        }
    }
}