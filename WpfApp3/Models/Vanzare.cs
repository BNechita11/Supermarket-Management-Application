using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp3.Models
{
    public class Vanzare
    {
        public int VanzareId { get; set; }
        public DateTime Data { get; set; }
        public decimal Suma { get; set; }
        public int UtilizatorId { get; set; }

        [ForeignKey("UtilizatorId")]
        public Utilizator Utilizator { get; set; }
    }
}