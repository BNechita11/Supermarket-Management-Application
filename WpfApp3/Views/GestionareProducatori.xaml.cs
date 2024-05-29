using System;
using System.Windows;
using System.Windows.Controls;
using WpfApp3.DataBase;
using WpfApp3.Models;
using WpfApp3.Services;

namespace WpfApp3.Views
{
    public partial class GestionareProducatori : Window
    {
        private readonly MagazinContextDb _context;
        private readonly ProducatorService _producatorService;

        public GestionareProducatori(MagazinContextDb context)
        {
            InitializeComponent();
            _context = context;
            _producatorService = new ProducatorService(_context);
        }

        private void AdaugaProducatori_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var producator = new Producator
                {
                    Nume = txtNumeProducatori.Text,
                    TaraDeOrigine = txtTaraOrigine.Text,
                    IsActive = chkIsActiveProducatori.IsChecked ?? false
                };

                _producatorService.AdaugaProducator(producator);

                MessageBox.Show("Producatorul a fost adăugat cu succes!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la adăugarea producatorului: {ex.Message}");
            }
        }
        private void ActualizeazaProducatori_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var producator = new Producator
                {
                    ProducatorId = int.Parse(txtIdProducatori.Text),
                    Nume = txtNumeProducatori.Text,
                    TaraDeOrigine = txtTaraOrigine.Text,
                    IsActive = chkIsActiveProducatori.IsChecked ?? false
                };

                _producatorService.ActualizeazaProducator(producator);
                MessageBox.Show("Producătorul a fost actualizat cu succes!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la actualizarea producătorului: {ex.Message}");
            }
        }



        private void StergeProducatori_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int producatorId = int.Parse(txtIdProducatori.Text);

                _producatorService.StergeProducator(producatorId);

                MessageBox.Show("Producatorul a fost șters logic cu succes!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la ștergerea logică a producatorului: {ex.Message}");
            }
        }
        private void AfiseazaProducatori_Click(object sender, RoutedEventArgs e)
        {
            AfiseazaProducatori();
        }

        private void AfiseazaProducatori()
        {
            try
            {
                var producatori = _producatorService.GetProducatori().ToList();
                string producatoriList = string.Join(Environment.NewLine, producatori.Select(p => $"ID: {p.ProducatorId}, Nume: {p.Nume}, TaraOrigine: {p.TaraDeOrigine}, Activ: {p.IsActive}"));
                MessageBox.Show(producatoriList, "Lista Producatori");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la afișarea producătorilor: {ex.Message}");
            }
        }
    }
}
