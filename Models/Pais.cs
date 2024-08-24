
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JimenaCelaya_Examen3.Models
{
    public class Pais
    {
        public int IDPais { get; set; }

        [Required]
        [StringLength(100)]
        public string NombrePais { get; set; }

        public ICollection<Visa> Visas { get; set; }
    }
}
