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
    [Table("Pedidos")]
    public class Pedido : PropiedadValidarModelo
    {
        public Pedido()
        {
            lineaPedido = new HashSet<LineaPedido>();
        }
        [Key]
        public int pedidoId { get; set; }
        [Required(ErrorMessage = "El campo nombre no se puede estar vacío")]
        [DataType(DataType.Date, ErrorMessage = "Fecha no es valido")]
        [DisplayName("Fecha")]
        public DateTime fecha { get; set; }

        public virtual Empleado empleado { get; set; }

        public virtual Cliente cliente { get; set; }

        public virtual ICollection<LineaPedido> lineaPedido { get; set; }
    }
}
