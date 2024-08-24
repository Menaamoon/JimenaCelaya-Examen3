using System;
using System.ComponentModel.DataAnnotations;

namespace JimenaCelaya_Examen3.Models
{
    public class Visa
    {
        public int IDVisa { get; set; }

        [Required]
        public DateTime FechaEmision { get; set; }

        [Required]
        public DateTime FechaVencimiento { get; set; }

        public int IDViajero { get; set; }
        public Viajero Viajero { get; set; }

        public int IDPais { get; set; }
        public Pais Pais { get; set; }
    }
}
