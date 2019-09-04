using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Modelo
{
    [Table("Empleados")]
    public class Empleado : PropiedadValidarModelo
    {
        public Empleado()
        {
            pedido = new HashSet<Pedido>();
        }
        [Key]
        public int usuarioId { get; set; }
        [Required(ErrorMessage = "El campo nombre no se puede estar vacío")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "El campo apellidos no se puede estar vacío")]
        public string apellidos { get; set; }
        [Required(ErrorMessage = "El campo usuario no se puede estar vacío")]
        public string usuario { get; set; }
        [Required(ErrorMessage = "El campo contraseña no se puede estar vacío")]
        public string contrasena { get; set; }
        [Required(ErrorMessage = "El campo tipo de cuenta no se puede estar vacío")]
        public string tipoCuenta { get; set; }

        public virtual ICollection<Pedido> pedido { get; set; }
    }
}
