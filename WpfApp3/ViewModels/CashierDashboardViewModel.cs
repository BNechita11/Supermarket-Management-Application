using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Input;
using WpfApp3.Commands;
using WpfApp3.Migrations;
using WpfApp3.Models;
using WpfApp3.Services;

namespace WpfApp3.ViewModels
{
    public class CashierDashboardViewModel : INotifyPropertyChanged
    {
        private string _searchQuery;
        private ObservableCollection<Produs> _produse;
        private ICommand _searchCommand;
        private readonly ProdusService _produsService;
        public ICommand CautăProduseCommand { get; set; }
        public CashierDashboardViewModel(ProdusService produsService)
        {
            _produsService = produsService;
            SearchCommand = new RelayCommand(Search);
            Produse = new ObservableCollection<Produs>();
            CautăProduseCommand = new RelayCommand(SearchProducts);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string SearchQuery
        {
            get { return _searchQuery; }
            set
            {
                _searchQuery = value;
                OnPropertyChanged(nameof(SearchQuery));
            }
        }

        public ObservableCollection<Produs> Produse
        {
            get { return _produse; }
            set
            {
                _produse = value;
                OnPropertyChanged(nameof(Produse));
            }
        }

        public ICommand SearchCommand
        {
            get { return _searchCommand; }
            set
            {
                _searchCommand = value;
                OnPropertyChanged(nameof(SearchCommand));
            }
        }
        private void Search(object parameter)
        {
            if (string.IsNullOrWhiteSpace(SearchQuery))
            {
                Produse.Clear();
                return;
            }

            var foundProduse = _produsService.GetProduseByName(SearchQuery);
            foreach (var produs in foundProduse)
            {
                Produse.Add(produs);
            }
        }
        private void SearchProducts(object parameter)
        {
            if (string.IsNullOrWhiteSpace(SearchQuery))
            {
                return;
            }

            var rezultate = _produsService.SearchProducts(SearchQuery, null, null, null, null);

            if (rezultate.Any())
            {
                StringBuilder messageBuilder = new StringBuilder();
                messageBuilder.AppendLine("Rezultatele căutării:");

                foreach (var rezultat in rezultate)
                {
                    messageBuilder.AppendLine($"Nume: {rezultat.Nume}, Cod de Bare: {rezultat.CodDeBare}");
                    
                }

                MessageBox.Show(messageBuilder.ToString(), "Rezultate Căutare", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Nu s-au găsit rezultate pentru căutarea efectuată.", "Rezultate Căutare", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }


    }
}
