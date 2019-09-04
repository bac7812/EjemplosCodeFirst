namespace Ejercicio1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Informatica : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        categoriaId = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.categoriaId);
            
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        productoId = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        descripcion = c.String(),
                        imagen = c.String(),
                        precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        stock = c.Int(nullable: false),
                        categoria_categoriaId = c.Int(),
                        proveedor_proveedorId = c.Int(),
                    })
                .PrimaryKey(t => t.productoId)
                .ForeignKey("dbo.Categorias", t => t.categoria_categoriaId)
                .ForeignKey("dbo.Proveedores", t => t.proveedor_proveedorId)
                .Index(t => t.categoria_categoriaId)
                .Index(t => t.proveedor_proveedorId);
            
            CreateTable(
                "dbo.LineaPedidos",
                c => new
                    {
                        lineaPedidoId = c.Int(nullable: false, identity: true),
                        cantidad = c.Int(nullable: false),
                        pedido_pedidoId = c.Int(),
                        producto_productoId = c.Int(),
                    })
                .PrimaryKey(t => t.lineaPedidoId)
                .ForeignKey("dbo.Pedidos", t => t.pedido_pedidoId)
                .ForeignKey("dbo.Productos", t => t.producto_productoId)
                .Index(t => t.pedido_pedidoId)
                .Index(t => t.producto_productoId);
            
            CreateTable(
                "dbo.Pedidos",
                c => new
                    {
                        pedidoId = c.Int(nullable: false, identity: true),
                        fecha = c.DateTime(nullable: false),
                        cliente_clienteId = c.Int(),
                        empleado_usuarioId = c.Int(),
                    })
                .PrimaryKey(t => t.pedidoId)
                .ForeignKey("dbo.Clientes", t => t.cliente_clienteId)
                .ForeignKey("dbo.Empleados", t => t.empleado_usuarioId)
                .Index(t => t.cliente_clienteId)
                .Index(t => t.empleado_usuarioId);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        clienteId = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        apellidos = c.String(nullable: false),
                        direccion = c.String(nullable: false),
                        telefono = c.String(),
                        email = c.String(),
                    })
                .PrimaryKey(t => t.clienteId);
            
            CreateTable(
                "dbo.Empleados",
                c => new
                    {
                        usuarioId = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        apellidos = c.String(nullable: false),
                        usuario = c.String(nullable: false),
                        contrasena = c.String(nullable: false),
                        tipoCuenta = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.usuarioId);
            
            CreateTable(
                "dbo.Proveedores",
                c => new
                    {
                        proveedorId = c.Int(nullable: false, identity: true),
                        nombreProveedor = c.String(nullable: false),
                        direccionProveedor = c.String(),
                        nombreContactoProveedor = c.String(),
                        telefonoContactoProveedor = c.String(),
                    })
                .PrimaryKey(t => t.proveedorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productos", "proveedor_proveedorId", "dbo.Proveedores");
            DropForeignKey("dbo.LineaPedidos", "producto_productoId", "dbo.Productos");
            DropForeignKey("dbo.LineaPedidos", "pedido_pedidoId", "dbo.Pedidos");
            DropForeignKey("dbo.Pedidos", "empleado_usuarioId", "dbo.Empleados");
            DropForeignKey("dbo.Pedidos", "cliente_clienteId", "dbo.Clientes");
            DropForeignKey("dbo.Productos", "categoria_categoriaId", "dbo.Categorias");
            DropIndex("dbo.Pedidos", new[] { "empleado_usuarioId" });
            DropIndex("dbo.Pedidos", new[] { "cliente_clienteId" });
            DropIndex("dbo.LineaPedidos", new[] { "producto_productoId" });
            DropIndex("dbo.LineaPedidos", new[] { "pedido_pedidoId" });
            DropIndex("dbo.Productos", new[] { "proveedor_proveedorId" });
            DropIndex("dbo.Productos", new[] { "categoria_categoriaId" });
            DropTable("dbo.Proveedores");
            DropTable("dbo.Empleados");
            DropTable("dbo.Clientes");
            DropTable("dbo.Pedidos");
            DropTable("dbo.LineaPedidos");
            DropTable("dbo.Productos");
            DropTable("dbo.Categorias");
        }
    }
}
