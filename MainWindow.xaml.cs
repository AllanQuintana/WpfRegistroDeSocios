using System;
using System.Windows;

namespace WpfRegistroDeSocios
{
    public partial class MainWindow : Window
    {
        private int totalFemeninos = 0;
        private int totalMasculinos = 0;
        private int sumaEdades = 0;
        private int totalSocios = 0;
        private double totalInscripciones = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            // Realiza acciones adicionales cuando se selecciona un RadioButton, si es necesario.
        }

        private void Calcular_Click(object sender, RoutedEventArgs e)
        {
            double costoInscripcion = 45000;
            double costoTenis = 250000;
            double costoFutbol = 120000;
            double subvencion = 0.85;

            double totalAPagar = costoInscripcion;
            if (rbTenis.IsChecked == true)
            {
                totalAPagar += costoTenis;
            }
            if (rbFutbol.IsChecked == true)
            {
                totalAPagar += costoFutbol;
            }

            double totalEmpleado = totalAPagar * (1 - subvencion);
            double totalEmpresa = totalAPagar * subvencion;

            if (rbFemeninos.IsChecked == true)
            {
                totalFemeninos++;
            }
            else
            {
                totalMasculinos++;
            }

            if (int.TryParse(txtEdad.Text, out int edad))
            {
                sumaEdades += edad;
                totalSocios++;
            }
            double promedioEdad = (double)sumaEdades / totalSocios;

            totalInscripciones += totalAPagar;

            txtAPagarPorFuncionario.Text = totalEmpleado.ToString("C");
            txtAPagarPorLaEmpresa.Text = totalEmpresa.ToString("C");
            txtSociosFemeninos.Text = totalFemeninos.ToString();
            txtSociosMaculinos.Text = totalMasculinos.ToString();
            txtPromedioEdad.Text = promedioEdad.ToString("F2");
            lblTotalAPagar.Content = totalInscripciones.ToString("C");
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtRut.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtEdad.Clear();
            rbFemeninos.IsChecked = true;
            rbMasculinos.IsChecked = false;
            rbFutbol.IsChecked = false;
            rbTenis.IsChecked = false;
            txtAPagarPorFuncionario.Clear();
            txtAPagarPorLaEmpresa.Clear();
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
