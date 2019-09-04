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
    /// Lógica de interacción para CategoriasWindow.xaml
    /// </summary>
    public partial class CategoriasWindow : Window
    {
        TextBox textBox;
        List<Categoria> listaCategorias = new List<Categoria>();
        public CategoriasWindow(TextBox textBox)
        {
            InitializeComponent();
            this.textBox = textBox;
            listaCategorias = MainWindow.unidadTrabajo.RepositorioCategoria.getGeneral();
            consultarCategoriasDataGrid.ItemsSource = listaCategorias;
        }

        private void consultarCategoriaDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (consultarCategoriasDataGrid.SelectedIndex != -1)
            {
                string nombreCategoria = listaCategorias[consultarCategoriasDataGrid.SelectedIndex].nombre;
                textBox.Text = nombreCategoria;
                Close();
            }
        }
    }
}
