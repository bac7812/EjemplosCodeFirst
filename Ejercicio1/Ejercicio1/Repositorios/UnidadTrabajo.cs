using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Repositorios
{
    public class UnidadTrabajo
    {
        private ContextoTienda contexto = new ContextoTienda();
        private RepositorioCategoria repositorioCategoria;
        private RepositorioCliente repositorioCliente;
        private RepositorioEmpleado repositorioEmpleado;
        private RepositorioLineaPedido repositorioLineaPedido;
        private RepositorioPedido repositorioPedido;
        private RepositorioProducto repositorioProducto;
        private RepositorioProveedor repositorioProveedor;
        
        public RepositorioCategoria RepositorioCategoria
        {
            get
            {
                if(this.repositorioCategoria == null)
                {
                    this.repositorioCategoria = new RepositorioCategoria(contexto);
                }
                return repositorioCategoria;
            }
        }

        public RepositorioCliente RepositorioCliente
        {
            get
            {
                if(this.repositorioCliente == null)
                {
                    this.repositorioCliente = new RepositorioCliente(contexto);
                }
                return repositorioCliente;
            }
        }

        public RepositorioEmpleado RepositorioEmpleado
        {
            get
            {
                if(this.repositorioEmpleado == null)
                {
                    this.repositorioEmpleado = new RepositorioEmpleado(contexto);
                }
                return repositorioEmpleado;
            }
        }

        public RepositorioLineaPedido RepositorioLineaPedido
        {
            get
            {
                if(this.repositorioLineaPedido == null)
                {
                    this.repositorioLineaPedido = new RepositorioLineaPedido(contexto);
                }
                return repositorioLineaPedido;
            }
        }

        public RepositorioPedido RepositorioPedido
        {
            get
            {
                if(this.repositorioPedido == null)
                {
                    this.repositorioPedido = new RepositorioPedido(contexto);
                }
                return repositorioPedido;
            }
        }

        public RepositorioProducto RepositorioProducto
        {
            get
            {
                if(this.repositorioProducto == null)
                {
                    this.repositorioProducto = new RepositorioProducto(contexto);
                }
                return repositorioProducto;
            }
        }

        public RepositorioProveedor RepositorioProveedor
        {
            get
            {
                if(this.repositorioProveedor == null)
                {
                    this.repositorioProveedor = new RepositorioProveedor(contexto);
                }
                return repositorioProveedor;
            }
        }
    }
}
