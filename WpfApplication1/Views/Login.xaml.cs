using BL;
using Entidades;
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
using WpfApplication1.ViewModel;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

       

        private void btIngresar_Click(object sender, RoutedEventArgs e)
        {
            VendedorBL vendedorbl = new VendedorBL();
            LogBL logbl = new LogBL();//log registrará si el usuario con el id correspondiente pudo ingresar al sistema o no 
            string id = txtDocumento.Text;
            string pass = txtPassword.Password;
            if (vendedorbl.verificarIngreso(id, pass))
            {
                this.Hide();
                MainWindowViewModel viewModel = new MainWindowViewModel();
                MainWindow main = new MainWindow();
                main.DataContext = viewModel;
                main.Show();

                logbl.registrarLog("Logueo Usuario", "Realizado con exito", id);
            }
            else
            {
                logbl.registrarLog("Logueo Usuario", "Documento o contraseña no validos", id);
                MessageBox.Show("Documento o contraseña no validos");
            }
        }
    }
}
