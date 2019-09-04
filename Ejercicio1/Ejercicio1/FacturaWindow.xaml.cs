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
    /// Lógica de interacción para FacturaWindow.xaml
    /// </summary>
    public partial class FacturaWindow : Window
    {
        public FacturaWindow()
        {
            InitializeComponent();
            lineaPedidosDataGrid.ItemsSource = MainWindow.pedido.lineaPedido;
            totalLabel.Content = "Total: " + MainWindow.total.ToString().Replace('.', ',') + "€";
            clienteLabel.Content = "Cliente: " + MainWindow.nombreCompletoCliente;
            empleadoLabel.Content = "Empleado: " + MainWindow.empleado.nombre + " " + MainWindow.empleado.apellidos;
        }
    }
}
