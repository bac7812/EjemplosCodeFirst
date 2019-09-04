using Ejercicio1.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Repositorios
{
    public class RepositorioProducto : RepositorioGenerico<Producto>
    {
        public RepositorioProducto(ContextoTienda contexto) : base(contexto)
        {

        }
    }
}
