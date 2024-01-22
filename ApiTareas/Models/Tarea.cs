using System.ComponentModel.DataAnnotations;

namespace ApiTareas.Models
{
    public class Tarea
    {
        [Key]
        public int IdTarea { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Estado { get; set; }

        public  string Descripcion {  get; set; }


    }
}
