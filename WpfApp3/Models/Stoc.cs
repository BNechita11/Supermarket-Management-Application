using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp3.Models
{
    public class Stoc
    {
        [Key]
        public int StocId { get; set; }

        // Foreign Key
        public int ProdusId { get; set; }

        public decimal Cantitate { get; set; }
        public string UnitateDeMasura { get; set; }
        public DateTime DataAprovizionarii { get; set; }
        public DateTime DataExpirarii { get; set; }
        public decimal PretAchizitie { get; set; } 
        public decimal PretVanzare { get; set; }

        public bool IsActive { get; set; } = true;

        // Navigation Property
        [ForeignKey("ProdusId")]
        public Produs Produs { get; set; }

        public void SetPretAchizitie(decimal pretAchizitie)
        {
            if (this.PretAchizitie != 0)
            {
                throw new InvalidOperationException("Pretul de achizitie nu poate fi modificat dupa adaugarea stocului.");
            }
            this.PretAchizitie = pretAchizitie;
        }

        public void SetPretVanzare(decimal pretVanzare)
        {
            if (pretVanzare < this.PretAchizitie)
            {
                throw new InvalidOperationException("Pretul de vanzare nu poate fi mai mic decat pretul de achizitie.");
            }
            this.PretVanzare = pretVanzare;
        }
    }
}
