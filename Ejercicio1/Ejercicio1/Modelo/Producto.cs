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
    [Table("Productos")]
    public class Producto : PropiedadValidarModelo
    {
        public Producto()
        {
            lineaPedido = new HashSet<LineaPedido>();
        }
        [Key]
        public int productoId { get; set; }
        [Required(ErrorMessage = "El campo nombre no se puede estar vacío")]
        public string nombre { get; set; }
        
        public string descripcion { get; set; }
        
        public string imagen { get; set; }
        [Required(ErrorMessage = "El campo precio no se puede estar vacío")]
        [Range(0.01, 999999999, ErrorMessage = "El precio debe ser mayor que 0.00")]
        [DisplayName("Precio")]
        public decimal precio { get; set; }
        [Required(ErrorMessage = "El campo stock no se puede estar vacío")]
        public int stock { get; set; }

        public virtual Categoria categoria { get; set; }

        public virtual Proveedor proveedor { get; set; }

        public virtual ICollection<LineaPedido> lineaPedido { get; set; }
    }
}
