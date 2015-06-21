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
    //Clase que administra la UI Pedido
    public class PedidoViewModel : BaseViewModel
    {
        bool _detalleActivo;
        Cliente _cliente;
        Pedido _pedido;
        double _totalPedido;
        ObservableCollection<ListaPedido> _productos;
        ObservableCollection<Pedido> _pedidos;
        ListaPedido _productoActual;

        public bool DetalleActivo
        {
            get { return _detalleActivo; }
            set
            {
                _detalleActivo = value;
                OnPropertyChanged("DetalleActivo");
            }
        }

        public Cliente Cliente
        {
            get { return _cliente; }
            set { _cliente = value;
            OnPropertyChanged("Cliente");
            }
        }

        public Pedido Pedido
        {
            get { return _pedido; }
            set
            {
                _pedido = value;                
                OnPropertyChanged("Pedido");
            }
        }

        public double TotalPedido
        {
            get {
                PedidoBL pedidoBL = new PedidoBL();
                _totalPedido = pedidoBL.calcularTotalPedido(Pedido);
                Pedido.Total = _totalPedido;
                return _totalPedido;
            }
            set
            {
                _totalPedido = value;
                OnPropertyChanged("TotalPedido");
            }
        }

        public ObservableCollection<ListaPedido> Productos
        {
            get {
                return _productos;
            }
            set { _productos = value;
            OnPropertyChanged("Productos");
            }
        }

        public ObservableCollection<Pedido> Pedidos
        {
            get { return _pedidos; }
            set 
            {
                _pedidos = value;
                OnPropertyChanged("Pedidos");
            }
        }

        public ListaPedido ProductoActual
        {
            get { return _productoActual;
            }
            set
            {
                _productoActual = value;
                OnPropertyChanged("ProductoActual");
            }
        }

        public PedidoViewModel()
        {
            _cliente = new Cliente();
            _pedido = new Pedido();
            _productos = new ObservableCollection<ListaPedido>();

        }

        //Adicionar producto seleccionado del listado de productos desde la UI ListadoProductos si no existe en la lista de
        //productos del pedido
        public void AdicionarProducto(Producto productoAdicionado)
        {
            LogBL logbl = new LogBL(); //si se adiciona un producto o no se registra 
            VendedorBL vendbl = new VendedorBL();
            Vendedor vendedor = vendbl.consultarVendedor(); //necesario para poner el id del usuario en el log


            if (productoAdicionado == null) return;
            foreach (var producto in Productos)
            {
                if (producto.Producto == productoAdicionado)
                {
                    logbl.registrarLog("Adicion Producto a Pedido", "El producto seleccionado ya ha sido adicionado al pedido", vendedor.Identificacion);
                    MessageBox.Show("El producto seleccionado ya ha sido adicionado al pedido", "Error");
                    return;
                }
            }

            ListaPedido nuevoProducto = new ListaPedido();
            nuevoProducto.Producto = productoAdicionado;
            nuevoProducto.Pedido = this.Pedido;
            nuevoProducto.PrecioVenta = productoAdicionado.Precio;
            Productos.Add(nuevoProducto);
            Pedido.Productos = this.Productos;
            PedidoBL pedidoBL = new PedidoBL();
            Pedido.Total = pedidoBL.calcularTotalPedido(Pedido);
            this.TotalPedido = Pedido.Total;

            string respuesta = "Se ha añadido " + productoAdicionado.Nombre + " al pedido.";
            logbl.registrarLog("Adicion Producto a Pedido", respuesta, vendedor.Identificacion);
        }

        //Lista en la UI actual la lista de los pedidos realizados por el cliente que se solicita
        public void MostrarPedidos()
        {
            LogBL logbl = new LogBL(); //si se muestra un pedido de cliente o no se registra 
            VendedorBL vendbl = new VendedorBL();
            Vendedor vendedor = vendbl.consultarVendedor();

            PedidoBL pedidoBL = new PedidoBL();
            Pedidos = pedidoBL.obtenerPedidosPorCliente(Cliente);
            if (Pedidos.Count() == 0)
            {
                logbl.registrarLog("Mostrar Pedidos", "El cliente actual no tiene pedidos", vendedor.Identificacion);
                MessageBox.Show("El cliente actual no tiene pedidos","Informacion");
            }
            else logbl.registrarLog("Mostrar Pedidos", "Se muestra la información de los pedidos del cliente", vendedor.Identificacion);
        }

        #region comandos

        RelayCommand _comandoGuardar;
        RelayCommand _comandoCancelar;
        RelayCommand _comandoQuitarProducto;

        public ICommand ComandoGuardar
        {
            get
            {
                if (_comandoGuardar == null)
                    _comandoGuardar = new RelayCommand(param => this.guardarExecute());
                return _comandoGuardar;
            }
        }

        private void guardarExecute()
        {
            if(Productos.Count==0){
                MessageBox.Show("No hay productos para adicionar al pedido", "Error");
            }
            else{
                PedidoBL pedidoBL = new PedidoBL();
                Pedido.NitCliente = Cliente.Nit;
                Pedido.Productos = Productos;
                
                pedidoBL.registrarPedido(Pedido);
                MessageBox.Show("Pedido registrado");
                Cliente = new Cliente();
                Productos = new ObservableCollection<ListaPedido>();
                Pedido = new Pedido();
                DetalleActivo = false;
                OnGuardarPedido(EventArgs.Empty);
            }            
        }

        public ICommand ComandoCancelar
        {
            get
            {
                if (_comandoCancelar == null)
                    _comandoCancelar = new RelayCommand(param => this.cancelarExecute());
                return _comandoCancelar;
            }
        }

        private void cancelarExecute()
        {
            LogBL logbl = new LogBL(); //si se cancela un pedido de cliente o no se registra 
            VendedorBL vendbl = new VendedorBL();
            Vendedor vendedor = vendbl.consultarVendedor();

            if(MessageBox.Show("Esta seguro que quiere cancelar el pedido actual?", "Confirmacion", MessageBoxButton.YesNo)
                == MessageBoxResult.Yes)
            {
                Cliente = new Cliente();
                Productos = new ObservableCollection<ListaPedido>();
                Pedido = new Pedido();
                DetalleActivo = false;
                OnCancelarPedido(EventArgs.Empty);

                logbl.registrarLog("Cancelar Pedido", "Se canceló el pedido", vendedor.Identificacion);
            }
            else logbl.registrarLog("Cancelar Pedido", "No se confirmo la cancelación del pedido.", vendedor.Identificacion);
        }

        public ICommand ComandoQuitarProducto
        {
            get
            {
                if (_comandoQuitarProducto == null)
                    _comandoQuitarProducto = new RelayCommand(param => this.quitarProductoExecute());
                return _comandoQuitarProducto;
            }
        }

        private void quitarProductoExecute()
        {
            LogBL logbl = new LogBL(); //si se elimina un producto del pesdido o no se registra 
            VendedorBL vendbl = new VendedorBL();
            Vendedor vendedor = vendbl.consultarVendedor();

            if (MessageBox.Show("Esta seguro que quiere eliminar el producto del pedido?", "Confirmacion", MessageBoxButton.YesNo)
                == MessageBoxResult.Yes)
            {
                Productos.Remove(ProductoActual);
                string respuesta = "Se eliminó producto del pedido.";
                logbl.registrarLog("Eliminar Producto del Pedido", respuesta, vendedor.Identificacion);
            }
            else logbl.registrarLog("Eliminar Producto del Pedido", "Se canceló la eliminacion del producto.", vendedor.Identificacion);
        }

        #endregion

        protected virtual void OnGuardarPedido(EventArgs e)
        {
            EventHandler handler = GuardarPedido;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnCancelarPedido(EventArgs e)
        {
            EventHandler handler = CancelarPedido;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        //Eventos que se lanza para informar a las otras vistas que se ha guardado o cancelado un producto
        //Con el fin que se sincronice toda la vista y los datos
        public event EventHandler GuardarPedido;
        public event EventHandler CancelarPedido;
    }
}
