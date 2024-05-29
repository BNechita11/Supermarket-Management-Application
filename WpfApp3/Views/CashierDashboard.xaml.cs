using System;
using System.Windows;
using WpfApp3.DataBase;
using WpfApp3.Services;
using WpfApp3.ViewModels;

namespace WpfApp3.Views
{
    public partial class CashierDashboard : Window
    {
        private readonly ProdusService _produsService;
        private readonly MagazinContextDb _context;

        public CashierDashboard(MagazinContextDb context)
        {
            InitializeComponent();
            _context = context;
            // Initialize ProdusService
            _produsService = new ProdusService(_context);

            DataContext = new CashierDashboardViewModel(_produsService);
        }
    }
}
