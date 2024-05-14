namespace Perfect_Pay
{
    public partial class MainPage : ContentPage
    {
        decimal bill;
        int tip;
        int noPersons=1;

        public MainPage()
        {
            InitializeComponent();
        }

        private void txtBill_Completed(object sender, EventArgs e)
        {
            bill = decimal.Parse(txtBill.Text);
            calculateTotal();
        }

        private void calculateTotal()
        {
            var totaltip = (bill * tip) / 100;
            var pp = totaltip / noPersons;
            LblTipPerPerson.Text= pp.ToString();
            lblTotal.Text = ((bill+totaltip)/noPersons).ToString();
            var sub = bill / noPersons;
            lblSub.Text = sub.ToString();
        }

        private void sld_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            tip = (int)sld.Value;
            lblTip.Text = tip.ToString();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if(sender is Button)
            {
                var btn = (Button)sender;
                var percentage = int.Parse( btn.Text.Replace("%",""));
                sld.Value = percentage;
            }
        }

        private void btnminus_Clicked(object sender, EventArgs e)
        {
            if (noPersons > 1)
                noPersons--;
            lblnumperson.Text = noPersons.ToString();
            calculateTotal();
        }

        private void btnplus_Clicked(object sender, EventArgs e)
        {
            noPersons++;
            lblnumperson.Text = noPersons.ToString();
            calculateTotal();
        }
    }
}