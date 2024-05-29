using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp3.DataBase;
using WpfApp3.Services;
using WpfApp3.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace WpfApp3.Views
{
    public partial class GestionareBonuri : Window
    {
        private readonly MagazinContextDb _context;
        private readonly BonService _bonService;
        private readonly StocService _stocService;
       

        public GestionareBonuri(MagazinContextDb context, StocService stocService)
        {
            InitializeComponent();
            _context = context;
            _bonService = new BonService(_context);
            _stocService = stocService;
        }

        private void AdaugaBon_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var bon = new BonCasa
                {
                    DataEliberarii = datePickerDataEliberarii.SelectedDate ?? DateTime.Now,
                    CasierId = int.Parse(txtCasierId.Text),
                    SumaIncasata = decimal.Parse(txtSumaIncasata.Text),
                    isActive = chkIsActive.IsChecked ?? true
                };

                _bonService.AdaugaBon(bon);

                MessageBox.Show("Bonul a fost adăugat cu succes!");
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la adăugarea bonului: {ex.Message}");
            }
        }

        private void ActualizeazaBon_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var bon = new BonCasa
                {
                    BonCasaId = int.Parse(txtBonId.Text),
                    DataEliberarii = datePickerDataEliberarii.SelectedDate ?? DateTime.Now,
                    CasierId = int.Parse(txtCasierId.Text),
                    SumaIncasata = decimal.Parse(txtSumaIncasata.Text),
                    isActive = chkIsActive.IsChecked ?? true
                };

                _bonService.ActualizeazaBon(bon);

                MessageBox.Show("Bonul a fost actualizat cu succes!");
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la actualizarea bonului: {ex.Message}");
            }
        }

        private void StergeBon_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int bonId = int.Parse(txtBonId.Text);
                _bonService.StergeBon(bonId);

                MessageBox.Show("Bonul a fost șters cu succes!");
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la ștergerea bonului: {ex.Message}");
            }
        }

        private void AfiseazaBonuri_Click(object sender, RoutedEventArgs e)
        {
            AfiseazaBonuri();
        }

        private void AfiseazaBonuri()
        {
            
            var bonuri = _bonService.GetBonuri().ToList();
            string bonuriList = string.Join(Environment.NewLine, bonuri.Select(b => $"ID: {b.BonCasaId}, CasierId: {b.CasierId}, Data Eliberarii: {b.DataEliberarii}, Casier {b.Casier}, SumaIncasata {b.SumaIncasata}, Activ{b.isActive}"));
            MessageBox.Show(bonuriList, "Afisare Bonuri");
            
        }

        public void EmitereBon(Dictionary<int, decimal> produseCuCantitati)
        {
            try
            {
                BonCasa newBon = new BonCasa();
                _context.BonCasa.Add(newBon);
                _context.SaveChanges();

                decimal totalBon = 0;

                foreach (var item in produseCuCantitati)
                {
                    int produsId = item.Key;
                    decimal cantitate = item.Value;

                    decimal pretProdus = _bonService.GetProductPrice(produsId);

                    // Create a new BonCasaDetalii
                    BonCasaDetalii detaliu = new BonCasaDetalii
                    {
                        BonCasaId = newBon.BonCasaId,
                        ProdusId = produsId,
                        Cantitate = cantitate,
                        Subtotal = pretProdus * cantitate
                    };

                    totalBon += detaliu.Subtotal;

                    _context.BonCasaDetalii.Add(detaliu);
                }
                newBon.SumaIncasata = totalBon;
                _context.SaveChanges();

                MessageBox.Show("Bon emis cu succes!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la emiterea bonului: {ex.Message}");
            }
        }
        private void BtnEmitereBon_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<int, decimal> produseCuCantitati = _stocService.GetProduseCuCantitati();

            EmitereBon(produseCuCantitati);
        }


        private void ClearFields()
        {
            txtBonId.Clear();
            txtCasierId.Clear();
            txtSumaIncasata.Clear();
            datePickerDataEliberarii.SelectedDate = null;
            chkIsActive.IsChecked = true;
        }
        private void BtnAfiseazaCelMaiMareBon_Click(object sender, RoutedEventArgs e)
        {
            DateTime dataSelectata = datePickerDataSelectata.SelectedDate ?? DateTime.Now;
            _bonService.GetCelMaiMareBon(dataSelectata);
        }
    }
}
