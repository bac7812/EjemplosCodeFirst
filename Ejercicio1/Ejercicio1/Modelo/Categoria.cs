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
    [Table("Categorias")]
    public class Categoria
    {
        public Categoria()
        {
            producto = new HashSet<Producto>();
        }
        [Key]
        public int categoriaId { get; set; }
        [Required(ErrorMessage = "El campo nombre no se puede estar vacío")]
        public string nombre { get; set; }

        public string descripcion { get; set; }

        public virtual ICollection<Producto> producto { get; set; }
    }
}
