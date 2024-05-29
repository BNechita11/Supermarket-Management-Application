using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WpfApp3.Models
{
    public class Categorie
    {
        [Key]
        public int CategorieId { get; set; }

        public string Nume { get; set; }

        public bool IsActive { get; set; } = true;
    }
}