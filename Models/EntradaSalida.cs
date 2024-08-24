using System;
using System.ComponentModel.DataAnnotations;

namespace JimenaCelaya_Examen3.Models
{
    public class EntradaSalida
    {
        public int IDRegistro { get; set; }

        public DateTime? FechaEntrada { get; set; }

        [StringLength(100)]
        public string LugarEntrada { get; set; }

        public DateTime? FechaSalida { get; set; }

        [StringLength(100)]
        public string LugarSalida { get; set; }

        public int IDViajero { get; set; }
        public Viajero Viajero { get; set; }
    }
}
