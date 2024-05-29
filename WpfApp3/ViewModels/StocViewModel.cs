using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfApp3.DataBase;
using WpfApp3.Models;
using WpfApp3.Services;

namespace WpfApp3.ViewModels
{

    public class StocViewModel : BaseViewModel
    {
        private readonly MagazinContextDb _context;
        private readonly StocService _stocService;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    

    public StocViewModel(MagazinContextDb context)
        {
            _context = context;
            _stocService = new StocService(_context);
            Stocuri = new ObservableCollection<Stoc>();
        }

        private Stoc _currentStoc;
        public Stoc CurrentStoc
        {
            get { return _currentStoc; }
            set
            {
                _currentStoc = value;
                OnPropertyChanged(nameof(CurrentStoc));
            }
        }

        public ObservableCollection<Stoc> Stocuri { get; }

        public void AdaugaStoc()
        {
            if (CurrentStoc != null)
            {
                _stocService.AdaugaStoc(CurrentStoc);
                CurrentStoc = new Stoc();
            }
        }

    }
}
