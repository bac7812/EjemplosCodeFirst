using Ejercicio1.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Repositorios
{
    public class RepositorioCliente : RepositorioGenerico<Cliente>
    {
        public RepositorioCliente(ContextoTienda contexto) : base(contexto)
        {

        }
    }
}
