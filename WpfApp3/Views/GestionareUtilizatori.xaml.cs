using System.Text;
using System.Windows;
using WpfApp3.Models;
using WpfApp3.Services;


namespace WpfApp3.Views
{
    public partial class GestionareUtilizatori : Window
    {
        private readonly UtilizatorService _utilizatorService;

        public GestionareUtilizatori(UtilizatorService utilizatorService)
        {
            InitializeComponent();
            _utilizatorService = utilizatorService;
        }

        private void BtnAdaugaUtilizator_Click(object sender, RoutedEventArgs e)
        {
            var utilizator = new Utilizator
            {
                Nume = txtNume.Text,
                Parola = txtParola.Text,
                TipUtilizator = txtTipUtilizator.Text,
                IsActive = chkIsActive.IsChecked ?? false
            };

            AdaugaUtilizator(utilizator);
        }

        private void BtnActualizeazaUtilizator_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtUtilizatorId.Text, out int utilizatorId))
            {
                var utilizator = new Utilizator
                {
                    UtilizatorId = utilizatorId,
                    Nume = txtNume.Text,
                    Parola = txtParola.Text,
                    TipUtilizator = txtTipUtilizator.Text,
                    IsActive = chkIsActive.IsChecked ?? false
                };

                ActualizeazaUtilizator(utilizator);
            }
            else
            {
                MessageBox.Show("ID utilizator invalid.");
            }
        }

        private void BtnStergeUtilizator_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtUtilizatorId.Text, out int utilizatorId))
            {
                StergeUtilizator(utilizatorId);
            }
            else
            {
                MessageBox.Show("ID utilizator invalid.");
            }
        }

        private void BtnAfiseazaUtilizatori_Click(object sender, RoutedEventArgs e)
        {
            var utilizatori = _utilizatorService.GetUtilizatori();
            StringBuilder messageBuilder = new StringBuilder();

            foreach (var utilizator in utilizatori)
            {
                messageBuilder.AppendLine($"ID: {utilizator.UtilizatorId}, Nume: {utilizator.Nume}, Tip : {utilizator.TipUtilizator}, Parola {utilizator.Parola}, Activ : {utilizator.IsActive}");
            }

            MessageBox.Show(messageBuilder.ToString());
        }

        private void AdaugaUtilizator(Utilizator utilizator)
        {
            try
            {
                _utilizatorService.AddUtilizator(utilizator);
                MessageBox.Show("Utilizator adăugat cu succes!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare: {ex.Message}");
            }
        }

        private void ActualizeazaUtilizator(Utilizator utilizator)
        {
            try
            {
                _utilizatorService.UpdateUtilizator(utilizator);
                MessageBox.Show("Utilizator actualizat cu succes!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare: {ex.Message}");
            }
        }

        private void StergeUtilizator(int utilizatorId)
        {
            try
            {
                _utilizatorService.DeleteUtilizator(utilizatorId);
                MessageBox.Show("Utilizator șters cu succes!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare: {ex.Message}");
            }
        }
    }
}

