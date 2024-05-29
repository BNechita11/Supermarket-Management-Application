using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp3.Models
{
    public class Utilizator
    {
        [Key]
        public int UtilizatorId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nume { get; set; }

        [Required]
        [MaxLength(100)]
        public string Parola { get; set; }

        [Required]
        [MaxLength(50)]
        public string TipUtilizator { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}