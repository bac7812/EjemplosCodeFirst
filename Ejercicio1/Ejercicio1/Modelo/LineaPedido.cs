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
    [Table("LineaPedidos")]
    public class LineaPedido : PropiedadValidarModelo
    {
        [Key]
        public int lineaPedidoId { get; set; }
        [Required(ErrorMessage = "El campo nombre no se puede estar vacío")]
        [Range(0, 999999999, ErrorMessage = "El cantidad debe ser mayor que 0")]
        [DisplayName("Cantidad")]
        public int cantidad { get; set; }

        public virtual Pedido pedido { get; set; }

        public virtual Producto producto { get; set; }
    }
}
