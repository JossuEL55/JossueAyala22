namespace JossueAyala22
{
    public partial class Confirmacion : ContentPage
    {
        public Confirmacion(string phoneNumber, int rechargeAmount)
        {
            InitializeComponent();
            JAyala_confirmationLabel.Text = $"Se hizo una recarga de {rechargeAmount} dólares al número {phoneNumber}.";
        }

        private async void OnOkButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}