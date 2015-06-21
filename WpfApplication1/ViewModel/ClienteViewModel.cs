using BL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfApplication1.ViewModel
{
    //Clase que administra la UI busqueda
    public class ClienteViewModel : EncabezadoViewModel
    {
        string _textoBuscar;
        Cliente _clienteSeleccionado;
        ObservableCollection<Cliente> _clientesEncontrados;

        public Cliente ClienteSeleccionado
        {
            get { return _clienteSeleccionado; }
            set
            {
                _clienteSeleccionado = value;
                OnPropertyChanged("ClienteSeleccionado");
            }
        }

        public string TextoBuscar
        {
            get { return _textoBuscar; }
            set {
                _textoBuscar = value;
                OnPropertyChanged("TextoBuscar");
            }
        }

        public ObservableCollection<Cliente> ClientesEncontrados
        {
            get { return _clientesEncontrados; }
            set { 
                _clientesEncontrados = value;
                OnPropertyChanged("ClientesEncontrados");
            }
        }

        public ClienteViewModel()
        {
            TextoBuscar = "Nombre del cliente";
            HabilitarBusqueda();
        }

        public void nuevaBusqueda()
        {
            HabilitarBusqueda();
            HabilitarOpcionesPedido();
        }


        #region comandos
        
        RelayCommand _comandoCrearPedido;
        RelayCommand _comandoBuscar;
        RelayCommand _comandoVerPedidos;

        public ICommand ComandoCrearPedido
        {
            get
            {
                if (_comandoCrearPedido == null)
                    _comandoCrearPedido = new RelayCommand(param => this.crearPedidoExecute(), param => this.CanCrearPedidoExecute);
                return _comandoCrearPedido;
            }
        }

        private void crearPedidoExecute()
        {
            LogBL logbl = new LogBL(); //si se crea un pedido o no, se registra 
            VendedorBL vendbl = new VendedorBL();
            Vendedor vendedor = vendbl.consultarVendedor(); //necesario para poner el id del usuario en el log

            if (ClienteSeleccionado == null)
            {
                logbl.registrarLog("Crear Pedido", "Por favor seleccionar un cliente", vendedor.Identificacion);
                MessageBox.Show("Por favor seleccionar un cliente", "Error");
            }
            else
            {                
                DeshabilitarEncabezado();
                OnCrearPedido(EventArgs.Empty);
                string resultado = "Se creó pedido al cliente " + ClienteSeleccionado.Nombre;
                logbl.registrarLog("Crear Pedido", resultado, vendedor.Identificacion);
            }
        }

        public bool CanCrearPedidoExecute 
        {
            get { return CrearPedidoHabilitado; } 
        }

        public ICommand ComandoBuscar
        {
            get
            {
                if (_comandoBuscar == null)
                    _comandoBuscar = new RelayCommand(param => this.buscarExecute(), param => this.CanBuscarExecute);
                return _comandoBuscar;
            }
        }

        private void buscarExecute()
        {
            ClienteBL clienteBL = new ClienteBL();
            ClientesEncontrados = clienteBL.consultarClientesPorNombre(TextoBuscar);
            if (ClientesEncontrados.Count() == 0) MessageBox.Show("Clientes no encontrados", "Informacion");
            else HabilitarOpcionesPedido();
        }

        public bool CanBuscarExecute 
        {
            get { return BuscarHabilitado; } 
        }

        public ICommand ComandoVerPedidos
        {
            get
            {
                if (_comandoVerPedidos == null)
                    _comandoVerPedidos = new RelayCommand(param => this.verPedidosExecute(), param => this.CanVerPedidosExecute);
                return _comandoVerPedidos;
            }
        }

        private void verPedidosExecute()
        {
            if (ClienteSeleccionado == null)
            {
                MessageBox.Show("Por favor seleccionar un cliente", "Error");
            }
            else
            {
                OnVerPedido(EventArgs.Empty);
            }
        }

        public bool CanVerPedidosExecute 
        { 
            get { return VerPedidosHabilitado; } 
        }

        #endregion

        protected virtual void OnCrearPedido(EventArgs e)
        {
            EventHandler handler = CrearPedido;
            if (handler != null)
            {
                handler(this, e);
            }
        }      

        protected virtual void OnVerPedido(EventArgs e)
        {
            EventHandler handler = VerPedido;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        //Eventos que se lanza para enviar el nombre del cliente que se requere las funcionalidades, ver o crear pedidos
        public event EventHandler CrearPedido;
        public event EventHandler VerPedido;
    }
}
