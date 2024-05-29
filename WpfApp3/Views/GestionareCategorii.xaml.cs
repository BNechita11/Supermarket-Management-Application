using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using WpfApp3.DataBase;
using WpfApp3.Models;
using WpfApp3.Services;

namespace WpfApp3.Views
{
    public partial class GestionareCategorii : Window
    {
        private readonly MagazinContextDb _context;
        private readonly CategorieService _categorieService;

        public GestionareCategorii(MagazinContextDb context)
        {
            InitializeComponent();
            _context = context;
            _categorieService = new CategorieService(_context);
        }

        private void AdaugaCategorie_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var categorie = new Categorie
                {
                    Nume = txtNumeCategorie.Text,
                    IsActive = chkIsActiveCategorie.IsChecked ?? false
                };

                _categorieService.AdaugaCategorie(categorie);

                MessageBox.Show("Categoria a fost adăugată cu succes!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la adăugarea categoriei: {ex.Message}");
            }
        }
        private void ActualizeazaCategorie_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var categorie = new Categorie
                {
                    CategorieId = int.Parse(txtIdCategorie.Text),
                    Nume = txtNumeCategorie.Text,
                    IsActive = chkIsActiveCategorie.IsChecked ?? false 
                };

                _categorieService.ActualizeazaCategorie(categorie);

                MessageBox.Show("Categoria a fost actualizată cu succes!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la actualizarea categoriei: {ex.Message}");
            }
        }


        private void StergeCategorie_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int categorieId = int.Parse(txtIdCategorie.Text);

                _categorieService.StergeCategorie(categorieId);

                MessageBox.Show("Categoria a fost ștearsă logic cu succes!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la ștergerea logică a categoriei: {ex.Message}");
            }
        }
        private void AfiseazaCategorii_Click(object sender, RoutedEventArgs e)
        {
            var categorii = _categorieService.GetCategorii();
            StringBuilder messageBuilder = new StringBuilder();

            foreach (var categorie in categorii)
            {
                messageBuilder.AppendLine($"ID: {categorie.CategorieId}, Nume: {categorie.Nume}");
            }

            MessageBox.Show(messageBuilder.ToString());
        }


        private void AfiseazaCategorii()
        {
            var categorie = _categorieService.GetCategorii().ToList();
            string categorieList = string.Join(Environment.NewLine, categorie.Select(c => $"ID: {c.CategorieId}, Nume: {c.Nume}, Activ: {c.IsActive}"));
            MessageBox.Show(categorieList, "Lista Categorii");
        }
    }
}
