using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp3.Models
{
    public class BonCasa
    {
        [Key]
        public int BonCasaId { get; set; }

        public DateTime DataEliberarii { get; set; }

        // Foreign Key
        public int CasierId { get; set; }

        public decimal SumaIncasata { get; set; }

        public bool isActive { get; set; } = true;

        // Navigation Properties
        [ForeignKey("CasierId")]
        public Utilizator Casier { get; set; }
        public List<BonCasaDetalii> Detalii { get; set; } = new List<BonCasaDetalii>();

        public class SumaIncasataPerZi
        {
            public int Zi { get; set; }
            public decimal SumaTotala { get; set; }
        }

    }
}