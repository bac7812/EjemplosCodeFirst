using Ejercicio1.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Repositorios
{
    public class RepositorioLineaPedido : RepositorioGenerico<LineaPedido>
    {
        public RepositorioLineaPedido(ContextoTienda contexto) : base(contexto)
        {

        }
    }
}
