using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using WpfApp3.DataBase;
using WpfApp3.Models;
using WpfApp3.Services;

namespace WpfApp3.Views
{
    public partial class GestionareStocuri : Window
    {
        private readonly StocService _stocService;

        public GestionareStocuri(StocService stocService)
        {
            InitializeComponent();
            _stocService = stocService;
        }
        private void AdaugaStoc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var stoc = new Stoc
                {
                    ProdusId = int.Parse(txtProdusId.Text),
                    Cantitate = decimal.Parse(txtCantitate.Text),
                    UnitateDeMasura = txtUnitateDeMasura.Text,
                    DataAprovizionarii = dpDataAprovizionarii.SelectedDate ?? DateTime.Now,
                    DataExpirarii = dpDataExpirarii.SelectedDate ?? DateTime.Now,
                    PretAchizitie = decimal.Parse(txtPretAchizitie.Text),
                    IsActive = true // Assuming you want this always true when adding new stock.
                };

                // Call the service method to add the stock
                _stocService.AdaugaStoc(stoc);
                MessageBox.Show("Stoc adăugat cu succes!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la adăugarea stocului: {ex.Message}");
            }
        }

        private void ActualizeazaStoc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var stoc = new Stoc
                {
                    StocId = int.Parse(txtStocId.Text),
                    ProdusId = int.Parse(txtProdusId.Text),
                    Cantitate = decimal.Parse(txtCantitate.Text),
                    UnitateDeMasura = txtUnitateDeMasura.Text,
                    DataAprovizionarii = dpDataAprovizionarii.SelectedDate ?? DateTime.Now,
                    DataExpirarii = dpDataExpirarii.SelectedDate ?? DateTime.Now,
                    PretAchizitie = decimal.Parse(txtPretAchizitie.Text),
                };

                // Apelăm metoda de adăugare din serviciul StocService
                _stocService.ActualizeazaStoc(stoc);

                MessageBox.Show("Stocul a fost actualizat cu succes!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la actualizarea stocului: {ex.Message}");
            }
        }
        private void StergeStoc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int stocId = int.Parse(txtStocId.Text);
                _stocService.StergeStoc(stocId);
                MessageBox.Show("Stoc șters cu succes!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la ștergerea stocului: {ex.Message}");
            }
        }
        private void AfiseazaStocuri_Click(object sender, RoutedEventArgs e)
        {
            AfiseazaStocuri();
        }
        private void AfiseazaStocuri()
        {
            var stocuri = _stocService.GetStocuri().ToList();
            string stocuriList = string.Join(Environment.NewLine, stocuri.Select(s => $"ID: {s.StocId}, Cantitate: {s.Cantitate}, Data expirarii: {s.DataExpirarii}, Pret Vanzare: {s.PretVanzare}, Data aprovizionarii: {s.DataAprovizionarii}, Activ {s.IsActive}, Pret Achizitie : {s.PretAchizitie}"));
            MessageBox.Show(stocuriList, "Lista Stocuri");
        }
    }
}
