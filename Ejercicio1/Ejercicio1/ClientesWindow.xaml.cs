using Ejercicio1.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Ejercicio1
{
    /// <summary>
    /// Lógica de interacción para ClientesWindow.xaml
    /// </summary>
    public partial class ClientesWindow : Window
    {
        Label label;
        List<Cliente> listaClientes = new List<Cliente>();
        Cliente cliente = new Cliente();
        public ClientesWindow(Label label)
        {
            InitializeComponent();
            this.label = label;
            listaClientes = MainWindow.unidadTrabajo.RepositorioCliente.getGeneral();
            consultarClientesDataGrid.ItemsSource = listaClientes;
        }

        private void consultarCategoriaDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (consultarClientesDataGrid.SelectedIndex != -1)
            {
                string nombre = listaClientes[consultarClientesDataGrid.SelectedIndex].nombre;
                cliente = MainWindow.unidadTrabajo.RepositorioCliente.singular(c => c.nombre == nombre);
                label.Content = "Cliente actual: " + cliente.nombre + " " + cliente.apellidos;
                MainWindow.nombreCompletoCliente = cliente.nombre + " " + cliente.apellidos;
                MainWindow.pedido.cliente = cliente;
                Close();
            }
        }
    }
}
