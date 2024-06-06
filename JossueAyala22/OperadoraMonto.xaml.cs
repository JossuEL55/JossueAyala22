
namespace JossueAyala22
{
    public partial class OperadoraMonto : ContentPage
    {
        private string _numero;
        private int _seleccionarMonto = 0;

        public OperadoraMonto(string phoneNumber)
        {
            InitializeComponent();
            _numero = phoneNumber;
        }

        private void OnRechargeOptionChanged(object sender, CheckedChangedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton.IsChecked)
            {
                _seleccionarMonto = int.Parse(radioButton.Content.ToString());
                JAyala_selectedAmountLabel.Text = $"Ha seleccionado una recarga de: {_seleccionarMonto} dólares";
            }
        }

        private async void OnRechargeButtonClicked(object sender, EventArgs e)
        {
            var operatorName = JAyala_operatorPicker.SelectedItem?.ToString();
            if (operatorName == null || _seleccionarMonto == 0)
            {
                await DisplayAlert("Error", "Por favor seleccione un operador y el monto de la recarga.", "OK");
                return;
            }

            bool confirm = await DisplayAlert("Confirmación", $"¿Desea recargar {_seleccionarMonto}?", "No", "Sí");
            if (confirm)
            {
                await SaveRechargeAsync(_numero, _seleccionarMonto);
                await Navigation.PushAsync(new Confirmacion(_numero, _seleccionarMonto));
            }
        }

        private async Task SaveRechargeAsync(string phoneNumber, int rechargeAmount)
        {
            var date = DateTime.Now.ToString("dd/MM/yyyy");
            var text = $"Se hizo una recarga de {rechargeAmount} dólares en la siguiente fecha; {date}";
            var filePath = Path.Combine(FileSystem.AppDataDirectory, $"{phoneNumber}.txt");

            using (var writer = new StreamWriter(filePath, false))
            {
                await writer.WriteLineAsync(text);
            }
        }
    }
}