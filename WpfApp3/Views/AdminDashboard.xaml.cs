using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using Microsoft.EntityFrameworkCore;
using WpfApp3.ViewModels;

namespace WpfApp3.Views
{
    public partial class AdminDashboard : Window
    {
        private readonly UtilizatorService _utilizatorService;
        private readonly MagazinContextDb _produsService;
        private readonly  MagazinContextDb _producatorService;
        private readonly MagazinContextDb _categorieService;
        private readonly MagazinContextDb _bonService;
        private readonly StocService _stocService;

        public AdminDashboard()
        {
            InitializeComponent();

            var dbContextFactory = new MagazinContextFactory();
            var dbContext = dbContextFactory.CreateDbContext(new string[] { });
            _utilizatorService = new UtilizatorService(dbContext);
            _stocService = new StocService(dbContext);
          

        }

        private void BtnGestionareUtilizatori_Click(object sender, RoutedEventArgs e)
        {
            var gestionareUtilizatoriWindow = new GestionareUtilizatori(_utilizatorService);
            gestionareUtilizatoriWindow.Show();
        }
        private void BtnGestionareCategorii_Click(object sender, RoutedEventArgs e)
        {
            GestionareCategorii gestionareCategorii = new GestionareCategorii(_categorieService);
           gestionareCategorii.Show();
        }

        private void BtnGestionareProducatori_Click(object sender, RoutedEventArgs e)
        {
            GestionareProducatori gestionareProducatori = new GestionareProducatori(_producatorService);
            gestionareProducatori.Show();
        }


        private void BtnGestionareProduse_Click(object sender, RoutedEventArgs e)
        {
            var gestionareProduseWindow = new GestionareProduse(_produsService);
            gestionareProduseWindow.Show();
        }

        private void BtnGestionareStocuri_Click(object sender, RoutedEventArgs e)
        {
            var gestionareStocuriWindow = new GestionareStocuri(_stocService);
            gestionareStocuriWindow.Show();
        }


        private void BtnGestionareBonuri_Click(object sender, RoutedEventArgs e)
        {
            var gestionareBonuriWindow = new GestionareBonuri(_bonService, _stocService);
            gestionareBonuriWindow.Show();

        }
    }
}
