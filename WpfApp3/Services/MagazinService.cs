using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using WpfApp3.DataBase;
using WpfApp3.Models;

namespace WpfApp3
{
    public class MagazinService
    {
        private readonly MagazinContextDb _context;

        public MagazinService(MagazinContextDb context)
        {
            _context = context;
        }

        public void CreareBazaDeDate()
        {
            _context.Database.EnsureCreated();
        }
    }
}
