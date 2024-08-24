using System.ComponentModel.DataAnnotations;

namespace JimenaCelaya_Examen3.Models
{
    public class Usuario
    {
        public int IDUsuario { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreUsuario { get; set; }

        [Required]
        [StringLength(100)]
        public string Contraseña { get; set; }

     
    }
}
