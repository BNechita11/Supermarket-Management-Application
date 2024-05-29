using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.Models
{
    public class Producator
    {
        [Key]
        public int ProducatorId { get; set; }

        public string Nume { get; set; }
        public string TaraDeOrigine { get; set; }

        public bool IsActive { get; set; } = true;
    }
}