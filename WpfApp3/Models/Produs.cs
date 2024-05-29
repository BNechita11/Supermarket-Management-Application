using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WpfApp3.Models
{
    public class Produs
    {
        [Key]
        public int ProdusId { get; set; }

        public string Nume { get; set; }
        public string CodDeBare { get; set; }

        public decimal PretNormal { get; set; }
        public decimal? PretRedus { get; set; }

        public int CategorieId { get; set; }
        public int ProducatorId { get; set; }

        [ForeignKey("CategorieId")]
        public Categorie Categorie { get; set; }

        [ForeignKey("ProducatorId")]
        public Stoc Producator { get; set; }

        public bool IsActive { get; set; } = true;
    }
}