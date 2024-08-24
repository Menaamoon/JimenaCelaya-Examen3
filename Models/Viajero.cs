using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JimenaCelaya_Examen3.Models
{
    public class Viajero
    {
        public int IDViajero { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreCompleto { get; set; }

        [Required]
        [StringLength(50)]
        public string NumeroPasaporte { get; set; }

        [Required]
        [StringLength(50)]
        public string Nacionalidad { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        public ICollection<EntradaSalida> EntradasSalidas { get; set; }
        public ICollection<Visa> Visas { get; set; }
    }
}
