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
    [Table("Clientes")]
    public class Cliente : PropiedadValidarModelo
    {
        public Cliente()
        {
            pedidos = new HashSet<Pedido>();
        }
        [Key]
        public int clienteId { get; set; }
        [Required(ErrorMessage = "El campo nombre de proveedor no se puede estar vacío")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "El campo nombre de proveedor no se puede estar vacío")]
        public string apellidos { get; set; }
        [Required(ErrorMessage = "El campo nombre de proveedor no se puede estar vacío")]
        public string direccion { get; set; }
        [Phone(ErrorMessage = "El campo télefono de contacto no es válido")]
        [DisplayName("Teléfono")]
        public string telefono { get; set; }
        [EmailAddress(ErrorMessage = "El campo e-mail no es válido")]
        [DisplayName("E-mail")]
        public string email { get; set; }

        public virtual ICollection<Pedido> pedidos { get; set; }
    }
}
