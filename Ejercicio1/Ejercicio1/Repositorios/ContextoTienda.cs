using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Ejercicio1.Modelo;
using Ejercicio1.Migrations;

namespace Ejercicio1.Repositorios
{
    public class ContextoTienda : DbContext 
    {
        public ContextoTienda() : base("TiendaEntities")
        {
            if (Database.Exists())
            {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<ContextoTienda, Configuration>());
            }
            else
            {
                Database.SetInitializer(new createdb());
            }
        }

        class createdb : CreateDatabaseIfNotExists<ContextoTienda>
        {
            protected override void Seed(ContextoTienda context)
            {
                context.empleados.Add(
                  new Empleado
                  {
                      nombre = "Super",
                      apellidos = "Administrador",
                      usuario = "admin",
                      contrasena = "admin",
                      tipoCuenta = "Administrador"
                  }
                  );
            }
        }

        public DbSet<Empleado> empleados { get; set; }
        public DbSet<Proveedor> proveedores { get; set; }
        public DbSet<Categoria> categorias { get; set; }
        public DbSet<Producto> productos { get; set; }
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Pedido> pedidos { get; set; }
        public DbSet<LineaPedido> lineasPedidos { get; set; }
        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            base.OnModelCreating(dbModelBuilder);
        }
    }
}
