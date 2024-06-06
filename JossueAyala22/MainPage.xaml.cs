
namespace JossueAyala22
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnNextButtonClicked(object sender, EventArgs e)
        {
            string phoneNumber = JAyala_phoneNumberEntry.Text;
            if (string.IsNullOrEmpty(phoneNumber))
            {
                await DisplayAlert("Error", "Por favor ingrese un número de teléfono.", "OK");
                return;
            }

            await Navigation.PushAsync(new OperadoraMonto(phoneNumber));
        }
    }
}