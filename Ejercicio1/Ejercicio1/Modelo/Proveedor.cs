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
    [Table("Proveedores")]
    public class Proveedor : PropiedadValidarModelo
    {
        public Proveedor()
        {
            producto = new HashSet<Producto>();
        }
        [Key]
        public int proveedorId { get; set; }
        [Required(ErrorMessage = "El campo nombre de proveedor no se puede estar vacío")]
        public string nombreProveedor { get; set; }
        public string direccionProveedor { get; set; }
        public string nombreContactoProveedor { get; set; }
        [Phone(ErrorMessage = "El campo télefono de contacto no es válido")]
        [DisplayName("Teléfono")]
        public string telefonoContactoProveedor { get; set; }
        public virtual ICollection<Producto> producto { get; set; }
    }
}
