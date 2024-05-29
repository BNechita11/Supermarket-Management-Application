using System;
using System.Windows;
using System.Windows.Controls;
using WpfApp3.DataBase;
using WpfApp3.Models;
using WpfApp3.Services;

namespace WpfApp3.Views
{
    public partial class GestionareProduse : Window
    {
        private readonly MagazinContextDb _context;
        private readonly ProdusService _produsService;
        private readonly ProducatorService _producatorService;

        public GestionareProduse(MagazinContextDb context)
        {
            InitializeComponent();
            _context = context;
            _produsService = new ProdusService(_context);
            _producatorService = new ProducatorService(_context);
        }

        private void SalveazaProdus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var produs = new Produs
                {
                    Nume = txtNumeProdus.Text,
                    CodDeBare = txtCodDeBare.Text,
                    CategorieId = int.Parse(txtCategorieId.Text),
                    ProducatorId = int.Parse(txtProducatorId.Text),
                    IsActive = chkIsActive.IsChecked ?? false
                };

                _produsService.AdaugaProdus(produs);

                MessageBox.Show("Produsul a fost adăugat cu succes!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la adăugarea produsului: {ex.Message}");
            }
        }

        private void StergeProdus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int produsId = int.Parse(txtProdusId.Text);
                _produsService.StergeProdus(produsId);

                MessageBox.Show("Produsul a fost șters cu succes!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la ștergerea produsului: {ex.Message}");
            }
        }

        private void ActualizeazaProdus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var produs = new Produs
                {
                    ProdusId = int.Parse(txtProdusId.Text),
                    Nume = txtNumeProdus.Text,
                    CodDeBare = txtCodDeBare.Text,
                    CategorieId = int.Parse(txtCategorieId.Text),
                    ProducatorId = int.Parse(txtProducatorId.Text),
                    IsActive = chkIsActive.IsChecked ?? false
                };

                _produsService.ActualizeazaProdus(produs);

                MessageBox.Show("Produsul a fost actualizat cu succes!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la actualizarea produsului: {ex.Message}");
            }
        }

        private void AfiseazaProduse_Click(object sender, RoutedEventArgs e)
        {
            AfiseazaProduse();
        }
        private void AfiseazaProduse()
        {
            var produse = _produsService.GetProduse().ToList();
            string produseList = string.Join(Environment.NewLine, produse.Select(p => $"ID: {p.ProdusId}, Nume: {p.Nume}, Stoc: {p.Producator}, Pret Normal: {p.PretNormal}, Cod de bare {p.CodDeBare}, Activ {p.IsActive}"));
            MessageBox.Show(produseList, "Lista Produse");
        }

        private void cbProducatori_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // Afișează lista de producători în combobox
                var producatori = _producatorService.GetProducatori();
                cbProducatori.ItemsSource = producatori;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la încărcarea producătorilor: {ex.Message}");
            }
        }

        private void cbProducatori_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                // Când se schimbă selecția producătorului, afișează produsele respective în ListView (lvProduse)
                if (cbProducatori.SelectedItem != null)
                {
                    int producatorId = (int)cbProducatori.SelectedValue;
                    var produse = _produsService.GetProduseByProducator(producatorId);
                    lvProduse.ItemsSource = produse;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la afișarea produselor: {ex.Message}");
            }
        }
    }
}
