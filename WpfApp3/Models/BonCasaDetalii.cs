using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp3.Models
{
    public class BonCasaDetalii
    {
        [Key]
        public int BonCasaDetaliuId { get; set; }

        // Foreign Keys
        public int BonCasaId { get; set; }
        public int ProdusId { get; set; }

        public decimal Cantitate { get; set; }
        public decimal Subtotal { get; set; }

        // Navigation Properties
        [ForeignKey("BonCasaId")]
        public BonCasa BonCasa { get; set; }

        [ForeignKey("ProdusId")]
        public Produs Produs { get; set; }
    }
}