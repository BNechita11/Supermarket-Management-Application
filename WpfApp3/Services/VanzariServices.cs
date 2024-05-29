using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using WpfApp3.DataBase;
using WpfApp3.Models;

namespace WpfApp3.Services
{
    public class VanzariService
    {
        private readonly MagazinContextDb _context;

        public VanzariService(MagazinContextDb context)
        {
            _context = context;
        }
    }
}
