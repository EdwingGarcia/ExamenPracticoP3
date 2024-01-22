using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAreasAPP.Models
{
    public class Tarea
    {
        [Key]
        public int IdTarea { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Estado { get; set; }

        public string Descripcion { get; set; }

    }
}
