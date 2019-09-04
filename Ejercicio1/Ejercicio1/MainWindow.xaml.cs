using Ejercicio1.Modelo;
using Ejercicio1.Repositorios;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ejercicio1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static UnidadTrabajo unidadTrabajo = new UnidadTrabajo();
        public static Empleado empleado = new Empleado();
        public static Proveedor proveedor = new Proveedor();
        public static Categoria categoria = new Categoria();
        public static Producto producto = new Producto();
        public static Cliente cliente = new Cliente();
        public static List<Categoria> listaCategoria = new List<Categoria>();
        public static List<Producto> listaProducto = new List<Producto>();
        public static LineaPedido lineaPedido = new LineaPedido();
        public static List<Cliente> listaCliente = new List<Cliente>();
        public static Pedido pedido = new Pedido();
        public static decimal total;
        public static string nombreCompletoCliente;
        string rolEmpleado;
        string imagenRuta;
        string imagenProductoNuevo;
        string imagenProductoAntiguo;

        public MainWindow()
        {
            InitializeComponent();
        }

        #region Validacion
        private Boolean validar(Object obj)
        {
            ValidationContext validationContext = new ValidationContext(obj, null, null);
            List<System.ComponentModel.DataAnnotations.ValidationResult> errors = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            Validator.TryValidateObject(obj, validationContext, errors, true);

            if (errors.Count() > 0)
            {
                string mensageErrores = string.Empty;
                foreach (var error in errors)
                {
                    error.MemberNames.First();
                    mensageErrores += error.ErrorMessage + Environment.NewLine;
                }
                MessageBox.Show(mensageErrores); return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region IniciarSesion
        private void accederButton_Click(object sender, RoutedEventArgs e)
        {
            if (usuarioIniciarSesionTextBox.Text != "" && contrasenaIniciarSesionPasswordBox.Password != "")
            {
                empleado = unidadTrabajo.RepositorioEmpleado.singular(em => em.usuario == usuarioIniciarSesionTextBox.Text && em.contrasena == contrasenaIniciarSesionPasswordBox.Password);
                if (empleado != null)
                {
                    inicioSesionGrid.Visibility = Visibility.Hidden;
                    gestionGrid.Visibility = Visibility.Visible;
                    estadoEmpleadoStatusBar.Content = "Bienviendo " + empleado.nombre;
                    estadoFechaStatusBar.Content = DateTime.Now.ToString("dd/MM/yyyy");
                    rolEmpleado = empleado.tipoCuenta;
                }
                else
                {
                    MessageBox.Show("Ese usuario o contraseña no es correcta", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Introduzca el usuario y la contraseña del usuario", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void accederButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (usuarioIniciarSesionTextBox.Text != "" && contrasenaIniciarSesionPasswordBox.Password != "")
            {
                empleado = unidadTrabajo.RepositorioEmpleado.singular(em => em.usuario == usuarioIniciarSesionTextBox.Text && em.contrasena == contrasenaIniciarSesionPasswordBox.Password);
                if (empleado != null)
                {
                    inicioSesionGrid.Visibility = Visibility.Hidden;
                    gestionGrid.Visibility = Visibility.Visible;
                    estadoEmpleadoStatusBar.Content = "Bienviendo " + empleado.nombre;
                    estadoFechaStatusBar.Content = DateTime.Now.ToString("dd/MM/yyyy");
                    rolEmpleado = empleado.tipoCuenta;
                }
                else
                {
                    MessageBox.Show("Ese usuario o contraseña no es correcta", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Introduzca el usuario y la contraseña del usuario", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        #region Menu
        private void empleadosButton_Click(object sender, RoutedEventArgs e)
        {
            if(rolEmpleado == "Administrador")
            {
                bienvenidoLabel.Visibility = Visibility.Hidden;
                empleadosGrid.Visibility = Visibility.Visible;
                proveedoresGrid.Visibility = Visibility.Hidden;
                categoriasGrid.Visibility = Visibility.Hidden;
                productosGrid.Visibility = Visibility.Hidden;
                clientesGrid.Visibility = Visibility.Hidden;
                tpvGrid.Visibility = Visibility.Hidden;
                empleadosDataGrid.ItemsSource = "";
                empleadosDataGrid.ItemsSource = unidadTrabajo.RepositorioEmpleado.getGeneral();
                limpiarEmpleado();
            }
            else
            {
                MessageBox.Show("No puedes entrar la sección de " + empleadosLabel.Content + ".", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void proveedoresButton_Click(object sender, RoutedEventArgs e)
        {
            if (rolEmpleado == "Administrador")
            {
                bienvenidoLabel.Visibility = Visibility.Hidden;
                empleadosGrid.Visibility = Visibility.Hidden;
                proveedoresGrid.Visibility = Visibility.Visible;
                categoriasGrid.Visibility = Visibility.Hidden;
                productosGrid.Visibility = Visibility.Hidden;
                clientesGrid.Visibility = Visibility.Hidden;
                tpvGrid.Visibility = Visibility.Hidden;
                proveedoresDataGrid.ItemsSource = "";
                proveedoresDataGrid.ItemsSource = unidadTrabajo.RepositorioProveedor.getGeneral();
                limpiarProveedor();
            }
            else
            {
                MessageBox.Show("No puedes entrar la sección de " + proveedoresLabel.Content + ".", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void categoriasButton_Click(object sender, RoutedEventArgs e)
        {
            if (rolEmpleado == "Administrador")
            {
                bienvenidoLabel.Visibility = Visibility.Hidden;
                empleadosGrid.Visibility = Visibility.Hidden;
                proveedoresGrid.Visibility = Visibility.Hidden;
                categoriasGrid.Visibility = Visibility.Visible;
                productosGrid.Visibility = Visibility.Hidden;
                clientesGrid.Visibility = Visibility.Hidden;
                tpvGrid.Visibility = Visibility.Hidden;
                categoriasDataGrid.ItemsSource = "";
                categoriasDataGrid.ItemsSource = unidadTrabajo.RepositorioCategoria.getGeneral();
                limpiarCategoria();
            }
            else
            {
                MessageBox.Show("No puedes entrar la sección de " + categoriasLabel.Content + ".", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void productosButton_Click(object sender, RoutedEventArgs e)
        {
            if (rolEmpleado == "Administrador")
            {
                bienvenidoLabel.Visibility = Visibility.Hidden;
                empleadosGrid.Visibility = Visibility.Hidden;
                proveedoresGrid.Visibility = Visibility.Hidden;
                categoriasGrid.Visibility = Visibility.Hidden;
                productosGrid.Visibility = Visibility.Visible;
                clientesGrid.Visibility = Visibility.Hidden;
                tpvGrid.Visibility = Visibility.Hidden;
                productosDataGrid.ItemsSource = "";
                productosDataGrid.ItemsSource = unidadTrabajo.RepositorioProducto.getGeneral();
                limpiarProducto();
            }
            else
            {
                MessageBox.Show("No puedes entrar la sección de " + productosLabel.Content + ".", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void clientesButton_Click(object sender, RoutedEventArgs e)
        {
            if (rolEmpleado == "Administrador")
            {
                bienvenidoLabel.Visibility = Visibility.Hidden;
                empleadosGrid.Visibility = Visibility.Hidden;
                proveedoresGrid.Visibility = Visibility.Hidden;
                categoriasGrid.Visibility = Visibility.Hidden;
                productosGrid.Visibility = Visibility.Hidden;
                clientesGrid.Visibility = Visibility.Visible;
                tpvGrid.Visibility = Visibility.Hidden;
                clientesDataGrid.ItemsSource = "";
                clientesDataGrid.ItemsSource = unidadTrabajo.RepositorioCliente.getGeneral();
                limpiarCliente();
            }
            else
            {
                MessageBox.Show("No puedes entrar la sección de " + clientesLabel.Content + ".", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void tpvButton_Click(object sender, RoutedEventArgs e)
        {
            cliente = unidadTrabajo.RepositorioCliente.singular(c => c.clienteId == 1);
            if (cliente != null)
            {
                bienvenidoLabel.Visibility = Visibility.Hidden;
                empleadosGrid.Visibility = Visibility.Hidden;
                proveedoresGrid.Visibility = Visibility.Hidden;
                categoriasGrid.Visibility = Visibility.Hidden;
                productosGrid.Visibility = Visibility.Hidden;
                clientesGrid.Visibility = Visibility.Hidden;
                tpvGrid.Visibility = Visibility.Visible;
                pedido = null;
                lineaPedido = null;
                clienteLabel.Content = "Cliente actual: " + cliente.nombre + " " + cliente.apellidos;
                nombreCompletoCliente = "Cliente actual: " + cliente.nombre + " " + cliente.apellidos;
                categoriasListView.Items.Clear();
                productosWrapPanel.Children.Clear();
                listaCategoria.Clear();
                listaProducto.Clear();
                listaCategoria = unidadTrabajo.RepositorioCategoria.getGeneral();
                foreach (Categoria c in listaCategoria)
                {
                    categoriasListView.Items.Add(c.nombre);
                }
            }
            else
            {
                MessageBox.Show("No hay cliente", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void cerrarSesionButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mensaje = MessageBox.Show("¿Seguro que deseas salir de esa aplicación?", "Aviso", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (mensaje.Equals(MessageBoxResult.Yes))
            {
                inicioSesionGrid.Visibility = Visibility.Visible;
                gestionGrid.Visibility = Visibility.Hidden;
                empleadosGrid.Visibility = Visibility.Hidden;
                proveedoresGrid.Visibility = Visibility.Hidden;
                categoriasGrid.Visibility = Visibility.Hidden;
                productosGrid.Visibility = Visibility.Hidden;
                clientesGrid.Visibility = Visibility.Hidden;
                tpvGrid.Visibility = Visibility.Hidden;
                usuarioIniciarSesionTextBox.Text = "";
                contrasenaIniciarSesionPasswordBox.Password = "";
                estadoEmpleadoStatusBar.Content = "";
                estadoFechaStatusBar.Content = "";
                empleado = new Empleado();
            }
        }
        #endregion

        #region Empleado
        private void crearEmpleadoButton_Click(object sender, RoutedEventArgs e)
        {
            if (nombreEmpleadoTextBox.Text != "" && apellidosEmpleadoTextBox.Text != "" && usuarioEmpleadoTextBox.Text != "" && contrasenaEmpleadoPasswordBox.Password != "" && tipoCuentaEmpleadoComboBox.SelectedValue.ToString() != "")
            {
                Empleado nuevo = new Empleado();
                nuevo.nombre = nombreEmpleadoTextBox.Text;
                nuevo.apellidos = apellidosEmpleadoTextBox.Text;
				nuevo.usuario = usuarioEmpleadoTextBox.Text;
                nuevo.contrasena = contrasenaEmpleadoPasswordBox.Password;
                
                nuevo.tipoCuenta = ((ComboBoxItem)tipoCuentaEmpleadoComboBox.SelectedItem).Content.ToString();
                if (validar(nuevo))
                {
                    unidadTrabajo.RepositorioEmpleado.añadir(nuevo);
                    empleadosDataGrid.ItemsSource = "";
                    empleadosDataGrid.ItemsSource = unidadTrabajo.RepositorioEmpleado.getGeneral();
                    MessageBox.Show("Ya creado nuevo/a empleado/a", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("No se puedan estar vacíos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void modificarEmpleadoButton_Click(object sender, RoutedEventArgs e)
        {
            if (validar(empleado))
            {
                unidadTrabajo.RepositorioEmpleado.modificar(empleado);
                empleadosDataGrid.ItemsSource = "";
                empleadosDataGrid.ItemsSource = unidadTrabajo.RepositorioEmpleado.getGeneral();
                MessageBox.Show("Ya modificado empleado/a", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void eliminarEmpleadoButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mensaje = MessageBox.Show("¿Seguro que deseas eliminar el/la empleado/a?", "Aviso", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (mensaje.Equals(MessageBoxResult.Yes))
            {
                unidadTrabajo.RepositorioEmpleado.eliminar(empleado);
                empleado = new Empleado();
                empleadosGrid.DataContext = empleado;
                idEmpleadoTextBox.Text = "";
                empleadosDataGrid.ItemsSource = "";
                empleadosDataGrid.ItemsSource = unidadTrabajo.RepositorioEmpleado.getGeneral();
                crearEmpleadoButton.IsEnabled = true;
                modificarEmpleadoButton.IsEnabled = false;
                eliminarEmpleadoButton.IsEnabled = false;
                buscarEmpleadoButton.IsEnabled = true;
                MessageBox.Show("Ya eliminado empleado/a", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void buscarEmpleadoButton_Click(object sender, RoutedEventArgs e)
        {
            empleado = new Empleado();
            if (idEmpleadoTextBox.Text != "")
            {
                int idEmpleado = Convert.ToInt32(idEmpleadoTextBox.Text);
                empleado = unidadTrabajo.RepositorioEmpleado.singular(em => em.usuarioId == idEmpleado);

                if (empleado != null)
                {
                    empleadosGrid.DataContext = empleado;
                    contrasenaEmpleadoPasswordBox.Password = empleado.contrasena;
                    crearEmpleadoButton.IsEnabled = false;
                    modificarEmpleadoButton.IsEnabled = true;
                    eliminarEmpleadoButton.IsEnabled = true;
                    idEmpleadoTextBox.IsEnabled = false;
                    buscarEmpleadoButton.IsEnabled = false;
                }
                else
                {
                    MessageBox.Show("No encuentro lo que buscas", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Debes introducir una busqueda", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void limpiarEmpleadoButton_Click(object sender, RoutedEventArgs e)
        {
            limpiarEmpleado();
        }

        private void limpiarEmpleado()
        {
            empleado = new Empleado();
            empleadosGrid.DataContext = empleado;
            idEmpleadoTextBox.Text = "";
            contrasenaEmpleadoPasswordBox.Password = "";
            empleadosDataGrid.ItemsSource = "";
            empleadosDataGrid.ItemsSource = unidadTrabajo.RepositorioEmpleado.getGeneral();
            crearEmpleadoButton.IsEnabled = true;
            modificarEmpleadoButton.IsEnabled = false;
            eliminarEmpleadoButton.IsEnabled = false;
            idEmpleadoTextBox.IsEnabled = true;
            buscarEmpleadoButton.IsEnabled = true;
        }

        private void empleadosDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (empleadosDataGrid.SelectedIndex != -1)
            {
                empleado = (Empleado)empleadosDataGrid.SelectedItem;

                if (empleado != null)
                {
                    empleadosGrid.DataContext = empleado;
                    contrasenaEmpleadoPasswordBox.Password = empleado.contrasena;
                    crearEmpleadoButton.IsEnabled = false;
                    modificarEmpleadoButton.IsEnabled = true;
                    eliminarEmpleadoButton.IsEnabled = true;
                    idEmpleadoTextBox.IsEnabled = false;
                    buscarEmpleadoButton.IsEnabled = false;
                }
            }
        }
        #endregion

        #region Proveedor
        private void crearProveedorButton_Click(object sender, RoutedEventArgs e)
        {
            if (nombreProveedorTextBox.Text != "" && direccionProveedorTextBox.Text != "" && nombreContactoProveedorTextBox.Text != "" && telefonoContactoProveedorTextBox.Text != "")
            {
                Proveedor nuevo = new Proveedor();
                nuevo.nombreProveedor = nombreProveedorTextBox.Text;
                nuevo.direccionProveedor = direccionProveedorTextBox.Text;
                nuevo.nombreContactoProveedor = nombreContactoProveedorTextBox.Text;
                nuevo.telefonoContactoProveedor = telefonoContactoProveedorTextBox.Text;
                if (validar(nuevo))
                {
                    unidadTrabajo.RepositorioProveedor.añadir(nuevo);
                    proveedoresDataGrid.ItemsSource = "";
                    proveedoresDataGrid.ItemsSource = unidadTrabajo.RepositorioProveedor.getGeneral();
                    MessageBox.Show("Ya creado nuevo proveedor", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("No se puedan estar vacíos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void modificarProveedorButton_Click(object sender, RoutedEventArgs e)
        {
            if (validar(proveedor))
            {
                unidadTrabajo.RepositorioProveedor.modificar(proveedor);
                proveedoresDataGrid.ItemsSource = "";
                proveedoresDataGrid.ItemsSource = unidadTrabajo.RepositorioProveedor.getGeneral();
                MessageBox.Show("Ya modificado proveedor", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void eliminarProveedorButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mensaje = MessageBox.Show("¿Seguro que deseas eliminar el proveedor?", "Aviso", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (mensaje.Equals(MessageBoxResult.Yes))
            {
                unidadTrabajo.RepositorioProveedor.eliminar(proveedor);
                proveedor = new Proveedor();
                proveedoresGrid.DataContext = proveedor;
                proveedoresDataGrid.ItemsSource = "";
                proveedoresDataGrid.ItemsSource = unidadTrabajo.RepositorioProveedor.getGeneral();
                crearProveedorButton.IsEnabled = true;
                modificarProveedorButton.IsEnabled = false;
                eliminarProveedorButton.IsEnabled = false;
                buscarProveedorButton.IsEnabled = true;
                MessageBox.Show("Ya eliminado proveedor", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void buscarProveedorButton_Click(object sender, RoutedEventArgs e)
        {
            proveedor = new Proveedor();
            if (idProveedorTextBox.Text != "")
            {
                int idProveedor = Convert.ToInt32(idProveedorTextBox.Text);
                proveedor = unidadTrabajo.RepositorioProveedor.singular(p => p.proveedorId == idProveedor);

                if (proveedor != null)
                {
                    proveedoresGrid.DataContext = proveedor;
                    crearProveedorButton.IsEnabled = false;
                    modificarProveedorButton.IsEnabled = true;
                    eliminarProveedorButton.IsEnabled = true;
                    idProveedorTextBox.IsEnabled = false;
                    buscarProveedorButton.IsEnabled = false;
                }
                else
                {
                    MessageBox.Show("No encuentro lo que buscas", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Debes introducir una busqueda", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void limpiarProveedorButton_Click(object sender, RoutedEventArgs e)
        {
            limpiarProveedor();
        }

        private void limpiarProveedor()
        {
            proveedor = new Proveedor();
            proveedoresGrid.DataContext = proveedor;
            idProveedorTextBox.Text = "";
            proveedoresDataGrid.ItemsSource = "";
            proveedoresDataGrid.ItemsSource = unidadTrabajo.RepositorioProveedor.getGeneral();
            crearProveedorButton.IsEnabled = true;
            modificarProveedorButton.IsEnabled = false;
            eliminarProveedorButton.IsEnabled = false;
            idProveedorTextBox.IsEnabled = true;
            buscarProveedorButton.IsEnabled = true;
        }

        private void proveedoresDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (proveedoresDataGrid.SelectedIndex != -1)
            {
                proveedor = (Proveedor)proveedoresDataGrid.SelectedItem;

                if (proveedor != null)
                {
                    proveedoresGrid.DataContext = proveedor;
                    crearProveedorButton.IsEnabled = false;
                    modificarProveedorButton.IsEnabled = true;
                    eliminarProveedorButton.IsEnabled = true;
                    idProveedorTextBox.IsEnabled = false;
                    buscarProveedorButton.IsEnabled = false;
                }
            }
        }
        #endregion

        #region Categoria
        private void crearCategoriaButton_Click(object sender, RoutedEventArgs e)
        {
            if (nombreCategoriaTextBox.Text != "" && descripcionCategoriaTextBox.Text != "")
            {
                Categoria nuevo = new Categoria();
                nuevo.nombre = nombreCategoriaTextBox.Text;
                nuevo.descripcion = descripcionCategoriaTextBox.Text;
                if (validar(nuevo))
                {
                    unidadTrabajo.RepositorioCategoria.añadir(nuevo);
                    categoriasDataGrid.ItemsSource = "";
                    categoriasDataGrid.ItemsSource = unidadTrabajo.RepositorioCategoria.getGeneral();
                    MessageBox.Show("Ya creado nueva categoría", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("No se puedan estar vacíos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void modificarCategoriaButton_Click(object sender, RoutedEventArgs e)
        {
            if (validar(categoria))
            {
                unidadTrabajo.RepositorioCategoria.modificar(categoria);
                categoriasDataGrid.ItemsSource = "";
                categoriasDataGrid.ItemsSource = unidadTrabajo.RepositorioCategoria.getGeneral();
                MessageBox.Show("Ya modificado categoría", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void eliminarCategoriaButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mensaje = MessageBox.Show("¿Seguro que deseas eliminar la categoría?", "Aviso", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (mensaje.Equals(MessageBoxResult.Yes))
            {
                unidadTrabajo.RepositorioCategoria.eliminar(categoria);
                categoria = new Categoria();
                categoriasGrid.DataContext = categoria;
                categoriasDataGrid.ItemsSource = "";
                categoriasDataGrid.ItemsSource = unidadTrabajo.RepositorioCategoria.getGeneral();
                crearCategoriaButton.IsEnabled = true;
                modificarCategoriaButton.IsEnabled = false;
                eliminarCategoriaButton.IsEnabled = false;
                buscarCategoriaButton.IsEnabled = true;
                MessageBox.Show("Ya eliminado categoría", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void buscarCategoriaButton_Click(object sender, RoutedEventArgs e)
        {
            categoria = new Categoria();
            if (idCategoriaTextBox.Text != "")
            {
                int idCategoria = Convert.ToInt32(idCategoriaTextBox.Text);
                categoria = unidadTrabajo.RepositorioCategoria.singular(c => c.categoriaId == idCategoria);

                if (categoria != null)
                {
                    categoriasGrid.DataContext = categoria;
                    crearCategoriaButton.IsEnabled = false;
                    modificarCategoriaButton.IsEnabled = true;
                    eliminarCategoriaButton.IsEnabled = true;
                    idCategoriaTextBox.IsEnabled = false;
                    buscarCategoriaButton.IsEnabled = false;
                }
                else
                {
                    MessageBox.Show("No encuentro lo que buscas", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Debes introducir una busqueda", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void limpiarCategoriaButton_Click(object sender, RoutedEventArgs e)
        {
            limpiarCategoria();
        }

        private void limpiarCategoria()
        {
            categoria = new Categoria();
            categoriasGrid.DataContext = categoria;
            idCategoriaTextBox.Text = "";
            categoriasDataGrid.ItemsSource = "";
            categoriasDataGrid.ItemsSource = unidadTrabajo.RepositorioCategoria.getGeneral();
            crearCategoriaButton.IsEnabled = true;
            modificarCategoriaButton.IsEnabled = false;
            eliminarCategoriaButton.IsEnabled = false;
            idCategoriaTextBox.IsEnabled = true;
            buscarCategoriaButton.IsEnabled = true;
        }

        private void categoriasDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (categoriasDataGrid.SelectedIndex != -1)
            {
                categoria = (Categoria)categoriasDataGrid.SelectedItem;

                if (categoria != null)
                {
                    categoriasGrid.DataContext = categoria;
                    crearCategoriaButton.IsEnabled = false;
                    modificarCategoriaButton.IsEnabled = true;
                    eliminarCategoriaButton.IsEnabled = true;
                    idCategoriaTextBox.IsEnabled = false;
                    buscarCategoriaButton.IsEnabled = false;
                }
            }
        }
        #endregion

        #region Producto
        private void crearProductoButton_Click(object sender, RoutedEventArgs e)
        {
            if (nombreProductoTextBox.Text != "" && descripcionProductoTextBox.Text != "" && precioProductoTextBox.Text != "" && stockProductoTextBox.Text != "" && categoriaProductoTextBox.Text != "" && proveedorProductoTextBox.Text != "")
            {
                Categoria categoria = unidadTrabajo.RepositorioCategoria.singular(c => c.nombre == categoriaProductoTextBox.Text);
                Proveedor proveedor = unidadTrabajo.RepositorioProveedor.singular(p => p.nombreProveedor == proveedorProductoTextBox.Text);
                if (categoria != null && proveedor != null)
                {
                    Producto nuevo = new Producto();
                    nuevo.nombre = nombreProductoTextBox.Text;
                    nuevo.descripcion = descripcionProductoTextBox.Text;
                    nuevo.precio = Convert.ToDecimal(precioProductoTextBox.Text.Replace('€', ' ').TrimEnd());
                    nuevo.stock = Convert.ToInt32(stockProductoTextBox.Text);
                    nuevo.categoria = categoria;
                    nuevo.proveedor = proveedor;
                    nuevo.imagen = imagenProductoNuevo;
                    if (validar(nuevo))
                    {
                        if (File.Exists(imagenProductoNuevo))
                        {
                            MessageBox.Show("Ya existe la imagen", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            File.Copy(imagenRuta, imagenProductoNuevo);
                        }
                        unidadTrabajo.RepositorioProducto.añadir(nuevo);
                        productosDataGrid.ItemsSource = "";
                        productosDataGrid.ItemsSource = unidadTrabajo.RepositorioProducto.getGeneral();
                        MessageBox.Show("Ya creado nuevo producto", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("No se puedan estar vacíos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void modificarProductoButton_Click(object sender, RoutedEventArgs e)
        {
            if (validar(producto))
            {
                if (imagenProductoNuevo != null)
                {
                    if (File.Exists(imagenProductoAntiguo))
                    {
                        File.Delete(imagenProductoAntiguo);
                        File.Copy(imagenRuta, imagenProductoNuevo);
                        producto.imagen = imagenProductoNuevo;
                    }
                    else
                    {
                        File.Copy(imagenRuta, imagenProductoNuevo);
                        producto.imagen = imagenProductoNuevo;
                    }
                }
                producto.precio = Convert.ToDecimal(precioProductoTextBox.Text.Replace('€', ' ').TrimEnd());
                unidadTrabajo.RepositorioProducto.modificar(producto);
                categoriasDataGrid.ItemsSource = "";
                categoriasDataGrid.ItemsSource = unidadTrabajo.RepositorioCategoria.getGeneral();
                MessageBox.Show("Ya modificado producto", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void eliminarProductoButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mensaje = MessageBox.Show("¿Seguro que deseas eliminar el producto?", "Aviso", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (mensaje.Equals(MessageBoxResult.Yes))
            {
                unidadTrabajo.RepositorioProducto.eliminar(producto);
                producto = new Producto();
                productosGrid.DataContext = producto;
                productosDataGrid.ItemsSource = "";
                productosDataGrid.ItemsSource = unidadTrabajo.RepositorioProducto.getGeneral();
                crearProductoButton.IsEnabled = true;
                modificarProductoButton.IsEnabled = false;
                eliminarProductoButton.IsEnabled = false;
                buscarProductoButton.IsEnabled = true;
                MessageBox.Show("Ya eliminado producto", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void buscarProductoButton_Click(object sender, RoutedEventArgs e)
        {
            producto = new Producto();
            if (idProductoTextBox.Text != "")
            {
                int idProducto = Convert.ToInt32(idProductoTextBox.Text);
                producto = unidadTrabajo.RepositorioProducto.singular(p => p.productoId == idProducto);

                if (producto != null)
                {
                    productosGrid.DataContext = producto;
                    crearProductoButton.IsEnabled = false;
                    modificarProductoButton.IsEnabled = true;
                    eliminarProductoButton.IsEnabled = true;
                    idProductoTextBox.IsEnabled = false;
                    buscarProductoButton.IsEnabled = false;
                }
                else
                {
                    MessageBox.Show("No encuentro lo que buscas", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Debes introducir una busqueda", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void limpiarProductoButton_Click(object sender, RoutedEventArgs e)
        {
            limpiarProducto();
        }

        private void limpiarProducto()
        {
            producto = new Producto();
            productosGrid.DataContext = producto;
            idProductoTextBox.Text = "";
            productosDataGrid.ItemsSource = "";
            productosDataGrid.ItemsSource = unidadTrabajo.RepositorioProducto.getGeneral();
            crearProductoButton.IsEnabled = true;
            modificarProductoButton.IsEnabled = false;
            eliminarProductoButton.IsEnabled = false;
            idProductoTextBox.IsEnabled = true;
            buscarProductoButton.IsEnabled = true;
            precioProductoTextBox.Text = "";
            stockProductoTextBox.Text = "";
            imagenProductoImage.Source = null;
        }

        private void productosDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (productosDataGrid.SelectedIndex != -1)
            {
                producto = (Producto)productosDataGrid.SelectedItem;

                if (producto != null)
                {
                    productosGrid.DataContext = producto;
                    crearProductoButton.IsEnabled = false;
                    modificarProductoButton.IsEnabled = true;
                    eliminarProductoButton.IsEnabled = true;
                    idProductoTextBox.IsEnabled = false;
                    buscarProductoButton.IsEnabled = false;
                    if (producto.imagen != null)
                    {
                        imagenRuta = Environment.CurrentDirectory + "\\" + producto.imagen;
                        imagenProductoImage.Source = new BitmapImage(new Uri(imagenRuta, UriKind.Absolute));
                    }
                    else
                    {
                        imagenProductoImage.Source = null;
                    }
                }
            }
        }

        private void buscarCategoriaProductoButton_Click(object sender, RoutedEventArgs e)
        {
            CategoriasWindow categoriasWindow = new CategoriasWindow(categoriaProductoTextBox);
            categoriasWindow.Show();
        }

        private void buscarProveedorProductoButton_Click(object sender, RoutedEventArgs e)
        {
            ProveedoresWindow proveedoresWindow = new ProveedoresWindow(proveedorProductoTextBox);
            proveedoresWindow.Show();
        }

        private void subirImagenProductoButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog cargar = new OpenFileDialog();
            cargar.ShowDialog();
            if (cargar.FileName != "")
            {
                if (Regex.IsMatch(cargar.FileName, @".(jpg|bmp|png)$"))
                {
                    imagenProductoAntiguo = Convert.ToString(producto.imagen);
                    if (imagenProductoAntiguo != "")
                    {
                        imagenRuta = cargar.FileName;
                        imagenProductoImage.Source = new BitmapImage(new Uri(imagenRuta, UriKind.Absolute));
                        imagenProductoNuevo = @"Imagenes\" + cargar.SafeFileName;
                    }
                    else
                    {
                        imagenRuta = cargar.FileName;
                        imagenProductoImage.Source = new BitmapImage(new Uri(imagenRuta, UriKind.Absolute));
                        imagenProductoNuevo = @"Imagenes\" + cargar.SafeFileName;
                    }

                }
                else
                {
                    MessageBox.Show("El imagen no es correcta. Debe estar en formato JPG, BMP, PNG", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("No se ha cargado ninguna imagen", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

        #region Cliente
        private void crearClienteButton_Click(object sender, RoutedEventArgs e)
        {
            if (nombreClienteTextBox.Text != "" && apellidosClienteTextBox.Text != "" && direccionClienteTextBox.Text != "" && telefonoClienteTextBox.Text != "" && emailClienteTextBox.Text != "")
            {

                Cliente nuevo = new Cliente();
                nuevo.nombre = nombreClienteTextBox.Text;
                nuevo.apellidos = apellidosClienteTextBox.Text;
                nuevo.direccion = direccionClienteTextBox.Text;
                nuevo.telefono = telefonoClienteTextBox.Text;
                nuevo.email = emailClienteTextBox.Text;
                if (validar(nuevo))
                {
                    unidadTrabajo.RepositorioCliente.añadir(nuevo);
                    clientesDataGrid.ItemsSource = "";
                    clientesDataGrid.ItemsSource = unidadTrabajo.RepositorioCliente.getGeneral();
                    MessageBox.Show("Ya creado nuevo cliente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("No se puedan estar vacíos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void modificarClienteButton_Click(object sender, RoutedEventArgs e)
        {
            if (validar(cliente))
            {
                unidadTrabajo.RepositorioCliente.modificar(cliente);
                clientesDataGrid.ItemsSource = "";
                clientesDataGrid.ItemsSource = unidadTrabajo.RepositorioCliente.getGeneral();
                MessageBox.Show("Ya modificado cliente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void eliminarClienteButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mensaje = MessageBox.Show("¿Seguro que deseas eliminar el cliente?", "Aviso", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (mensaje.Equals(MessageBoxResult.Yes))
            {
                unidadTrabajo.RepositorioCliente.eliminar(cliente);
                cliente = new Cliente();
                clientesGrid.DataContext = cliente;
                clientesDataGrid.ItemsSource = "";
                clientesDataGrid.ItemsSource = unidadTrabajo.RepositorioCliente.getGeneral();
                crearClienteButton.IsEnabled = true;
                modificarClienteButton.IsEnabled = false;
                eliminarClienteButton.IsEnabled = false;
                buscarClienteButton.IsEnabled = true;
                MessageBox.Show("Ya eliminado cliente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void buscarClienteButton_Click(object sender, RoutedEventArgs e)
        {
            cliente = new Cliente();
            if (idClienteTextBox.Text != "")
            {
                int idCliente = Convert.ToInt32(idClienteTextBox.Text);
                cliente = unidadTrabajo.RepositorioCliente.singular(c => c.clienteId == idCliente);

                if (cliente != null)
                {
                    clientesGrid.DataContext = producto;
                    crearClienteButton.IsEnabled = false;
                    modificarClienteButton.IsEnabled = true;
                    eliminarClienteButton.IsEnabled = true;
                    idClienteTextBox.IsEnabled = false;
                    buscarClienteButton.IsEnabled = false;
                }
                else
                {
                    MessageBox.Show("No encuentro lo que buscas", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Debes introducir una busqueda", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void limpiarClienteButton_Click(object sender, RoutedEventArgs e)
        {
            limpiarCliente();
        }

        private void limpiarCliente()
        {
            cliente = new Cliente();
            clientesGrid.DataContext = producto;
            idClienteTextBox.Text = "";
            clientesDataGrid.ItemsSource = "";
            clientesDataGrid.ItemsSource = unidadTrabajo.RepositorioCliente.getGeneral();
            crearClienteButton.IsEnabled = true;
            modificarClienteButton.IsEnabled = false;
            eliminarClienteButton.IsEnabled = false;
            idClienteTextBox.IsEnabled = true;
            buscarClienteButton.IsEnabled = true;
        }

        private void clientesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (clientesDataGrid.SelectedIndex != -1)
            {
                cliente = (Cliente)clientesDataGrid.SelectedItem;

                if (cliente != null)
                {
                    clientesGrid.DataContext = cliente;
                    crearClienteButton.IsEnabled = false;
                    modificarClienteButton.IsEnabled = true;
                    eliminarClienteButton.IsEnabled = true;
                    idClienteTextBox.IsEnabled = false;
                    buscarClienteButton.IsEnabled = false;
                }
            }
        }
        #endregion

        #region TPV
        private void categoriasListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (categoriasListView.SelectedIndex != -1)
            {
                productosWrapPanel.Children.Clear();
                List<Producto> listaProducto = unidadTrabajo.RepositorioProducto.get(l => l.categoria.nombre == categoriasListView.SelectedValue.ToString());
                foreach (Producto p in listaProducto)
                {
                    Button button = new Button();
                    button.Name = p.nombre.Replace(' ', '_');
                    button.Content = actualizarProducto(p);
                    button.Background = Brushes.White;
                    if (p.stock > 0)
                    {
                        button.Foreground = Brushes.Blue;
                        button.BorderBrush = Brushes.Blue;
                    }
                    else
                    {
                        button.Foreground = Brushes.Red;
                        button.BorderBrush = Brushes.Red;
                    }
                    button.Width = 145;
                    button.Height = 100;
                    button.Margin = new Thickness(5);
                    button.Click += productoButton_click;
                    productosWrapPanel.Children.Add(button);
                }
            }
        }

        private void productoButton_click(object sender, RoutedEventArgs e)
        {
            var originalSource = e.OriginalSource;

            Button button = (Button)originalSource;

            string productoNombre = button.Name.Replace('_', ' ');

            listaProducto = unidadTrabajo.RepositorioProducto.getGeneral();

            producto = listaProducto.Where(l => l.nombre == productoNombre).FirstOrDefault();

            if (producto.stock < 1)
            {
                MessageBox.Show("El producto no tiene stock", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (pedido == null)
                {
                    pedido = new Pedido();
                    pedido.empleado = empleado;
                    pedido.cliente = cliente;
                    pedido.fecha = DateTime.Now;
                }

                lineaPedido = pedido.lineaPedido.Where(p => p.producto.productoId.Equals(producto.productoId)).FirstOrDefault();

                if (lineaPedido == null)
                {
                    lineaPedido = new LineaPedido();
                    lineaPedido.producto = producto;
                    lineaPedido.cantidad = 1;
                    lineaPedido.pedido = pedido;

                    pedido.lineaPedido.Add(lineaPedido);

                    total += lineaPedido.producto.precio;

                    producto.stock--;
                    unidadTrabajo.RepositorioProducto.modificar(producto);

                    totalLabel.Content = "Total: " + total.ToString().Replace('.',',') + "€";
                    button.Content = actualizarProducto(producto);
                    if (producto.stock > 0)
                    {
                        button.Foreground = Brushes.Blue;
                        button.BorderBrush = Brushes.Blue;
                    }
                    else
                    {
                        button.Foreground = Brushes.Red;
                        button.BorderBrush = Brushes.Red;
                    }
                }
                else
                {
                    LineaPedido lineaPedido = pedido.lineaPedido.Where(p => p.producto.productoId.Equals(producto.productoId)).FirstOrDefault();
                    lineaPedido.cantidad++;
                    total += lineaPedido.producto.precio;

                    producto.stock--;
                    unidadTrabajo.RepositorioProducto.modificar(producto);

                    totalLabel.Content = "Total: " + total.ToString().Replace('.', ',') + "€";
                    button.Content = actualizarProducto(producto);
                    if (producto.stock > 0)
                    {
                        button.Foreground = Brushes.Blue;
                        button.BorderBrush = Brushes.Blue;
                    }
                    else
                    {
                        button.Foreground = Brushes.Red;
                        button.BorderBrush = Brushes.Red;
                    }
                }
                
                lineaPedidosDataGrid.ItemsSource = "";
                lineaPedidosDataGrid.ItemsSource = pedido.lineaPedido.ToList();
            }
        }

        private object actualizarProducto(Producto p)
        {
            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Vertical;
            stackPanel.VerticalAlignment = VerticalAlignment.Center;
            stackPanel.HorizontalAlignment = HorizontalAlignment.Stretch;
            stackPanel.Width = 140;
            stackPanel.Height = 100;

            Label labelNombre = new Label();
            labelNombre.Content = p.nombre;
            labelNombre.FontSize = 12;
            labelNombre.HorizontalAlignment = HorizontalAlignment.Center;

            Label labelPrecioSock = new Label();
            labelPrecioSock.Content = "Precio: " + p.precio + "€ Stock: " + p.stock;
            labelPrecioSock.FontSize = 12;
            labelPrecioSock.HorizontalAlignment = HorizontalAlignment.Center;

            Image image = new Image();
            if (p.imagen != null)
            {
                imagenRuta = Environment.CurrentDirectory + "\\" + p.imagen;
                image.Source = new BitmapImage(new Uri(imagenRuta, UriKind.Absolute));
                image.Width = 50;
                image.Height = 50;
                
            }
            else
            {
                image.Source = null;
                image.Width = 50;
                image.Height = 50;
            }

            Border border = new Border();
            border.BorderBrush = Brushes.Blue;
            border.BorderThickness = new Thickness(1);
            border.Width = 50;
            border.Height = 50;
            border.Child = image;

            stackPanel.Children.Add(labelNombre);
            stackPanel.Children.Add(border);
            stackPanel.Children.Add(labelPrecioSock);
            return stackPanel;
        }

        private void pagarButton_Click(object sender, RoutedEventArgs e)
        {
            if (pedido != null)
            {
                if (pedido.lineaPedido.Count != 0)
                {
                    unidadTrabajo.RepositorioPedido.añadir(pedido);

                    FacturaWindow facturaWindow = new FacturaWindow();
                    facturaWindow.Show();

                    actualizarProductos();

                    pedido = null;
                    producto = new Producto();

                    lineaPedidosDataGrid.ItemsSource = "";

                    total = 0;
                    totalLabel.Content = "Total: 0,00€";

                    cliente = unidadTrabajo.RepositorioCliente.singular(c => c.clienteId == 1);
                    clienteLabel.Content = "Cliente actual: " + cliente.nombre + " " + cliente.apellidos;
                    nombreCompletoCliente = "Cliente actual: " + cliente.nombre + " " + cliente.apellidos;
                }
                else
                {
                    MessageBox.Show("No tiene ningún producto en el pedido", "Aviso", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
        }

        private void anularButton_Click(object sender, RoutedEventArgs e)
        {
            if (pedido.lineaPedido.Count > 0)
            {
                MessageBoxResult mensaje = MessageBox.Show("¿Seguro que desea anular el pedido actual?", "Aviso", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (mensaje.Equals(MessageBoxResult.Yes))
                {
                    foreach (LineaPedido l in pedido.lineaPedido)
                    {
                        Producto p = unidadTrabajo.RepositorioProducto.singular(pr => pr.productoId == lineaPedido.producto.productoId);
                        p.stock += l.cantidad;
                        unidadTrabajo.RepositorioProducto.modificar(p);
                    }

                    pedido = null;
                    producto = new Producto();

                    lineaPedidosDataGrid.ItemsSource = "";

                    total = 0;
                    totalLabel.Content = "Total: 0,00€";

                    cliente = unidadTrabajo.RepositorioCliente.singular(c => c.clienteId == 1);
                    clienteLabel.Content = "Cliente actual: " + cliente.nombre + " " + cliente.apellidos;
                    nombreCompletoCliente = "Cliente actual: " + cliente.nombre + " " + cliente.apellidos;

                    actualizarProductos();
                }
            }
            else
            {
                MessageBox.Show("No tiene ningún producto en el pedido", "Aviso", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void cambiarButton_Click(object sender, RoutedEventArgs e)
        {
            ClientesWindow clientesWindow = new ClientesWindow(clienteLabel);
            clientesWindow.Show();
        }

        private void eliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (lineaPedidosDataGrid.SelectedIndex != -1)
            {
                MessageBoxResult mensaje = MessageBox.Show("¿Seguro que deseas eliminar el producto?", "Aviso", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (mensaje.Equals(MessageBoxResult.Yes))
                {
                    lineaPedido = (LineaPedido)lineaPedidosDataGrid.SelectedItem;
                    if (lineaPedido != null)
                    {
                        Producto p = unidadTrabajo.RepositorioProducto.singular(pr => pr.productoId == lineaPedido.producto.productoId);
                        p.stock += lineaPedido.cantidad;
                        unidadTrabajo.RepositorioProducto.modificar(p);

                        decimal valorTotal = lineaPedido.cantidad * lineaPedido.producto.precio;
                        total = total - valorTotal;

                        pedido.lineaPedido.Remove(lineaPedido);

                        lineaPedidosDataGrid.ItemsSource = "";
                        lineaPedidosDataGrid.ItemsSource = pedido.lineaPedido.ToList();

                        totalLabel.Content = "Total: " + total.ToString().Replace('.', ',') + "€";

                        actualizarProductos();
                    }
                }
            }
            else
            {
                MessageBox.Show("No tiene ningún producto seleccionado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void actualizarProductos()
        {
            productosWrapPanel.Children.Clear();
            List<Producto> listaProducto = unidadTrabajo.RepositorioProducto.get(l => l.categoria.nombre == categoriasListView.SelectedValue.ToString());
            foreach (Producto pr in listaProducto)
            {
                Button button = new Button();
                button.Name = pr.nombre.Replace(' ', '_');
                button.Content = actualizarProducto(pr);
                button.Background = Brushes.White;
                if (pr.stock > 0)
                {
                    button.Foreground = Brushes.Blue;
                    button.BorderBrush = Brushes.Blue;
                }
                else
                {
                    button.Foreground = Brushes.Red;
                    button.BorderBrush = Brushes.Red;
                }
                button.Width = 145;
                button.Height = 100;
                button.Margin = new Thickness(5);
                button.Click += productoButton_click;
                productosWrapPanel.Children.Add(button);
            }
        }
        #endregion
    }
}
