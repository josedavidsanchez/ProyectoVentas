/*
 * Nombre del programa: Software Pedidos 2015
 * Author: Jose David Sanchez
 * Version: 1
 * Fecha Inicio: Mayo 14 2015
 * Fecha Finalizacion:
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.ViewModel
{
    //Clase que administra la UI principal y la comunicacion entre las diferentes UI
    public class MainWindowViewModel : BaseViewModel
    {
        //Instancia para manejar la UI ListadoProductos
        ObservableCollection<ProductosViewModel> _viewModelProducto;

        //Instancia para manejar la UI Busqueda
        ObservableCollection<ClienteViewModel> _viewModelCliente;

        //Instancia para manejar la UI Pedidos
        ObservableCollection<PedidoViewModel> _viewModelPedido;

        public ObservableCollection<ClienteViewModel> ViewModelCliente
        { 
            get
            {
                if (_viewModelCliente == null) _viewModelCliente = new ObservableCollection<ClienteViewModel>();
                return _viewModelCliente;
            }
            private set
            {
                _viewModelCliente = value;
                
                //Se crean las firmas para los dos eventos de ClienteViewModel, que son crearPedido y verPedido
                _viewModelCliente.First().CrearPedido += new EventHandler(eventoCrearPedido);
                _viewModelCliente.First().VerPedido += new EventHandler(eventoVerPedido);
                OnPropertyChanged("ViewModelCliente");
            }
        }

        private void eventoCrearPedido(object sender, EventArgs e)
        {            
            ViewModelPedido.First().Cliente = ViewModelCliente.First().ClienteSeleccionado;
            ViewModelPedido.First().Pedidos = null;
            ViewModelPedido.First().DetalleActivo = true;
            ViewModelProducto.First().ListarProductos();
        }

        private void eventoVerPedido(object sender, EventArgs e)
        {
            ViewModelPedido.First().Cliente = ViewModelCliente.First().ClienteSeleccionado;
            ViewModelPedido.First().MostrarPedidos();
        }

        public ObservableCollection<PedidoViewModel> ViewModelPedido
        {
            get
            {
                if (_viewModelPedido == null) _viewModelPedido = new ObservableCollection<PedidoViewModel>();
                return _viewModelPedido;
            }
            private set
            {
                _viewModelPedido = value;

                //Se crean las firmas para los dos eventos de PedidoViewModel, que son GuardarPedido y CancelarPedido
                _viewModelPedido.First().GuardarPedido += new EventHandler(eventoGuardarPedido);
                _viewModelPedido.First().CancelarPedido += new EventHandler(eventoCancelarPedido);
                OnPropertyChanged("ViewModelPedido");
            }
        }

        private void eventoGuardarPedido(object sender, EventArgs e)
        {
            ViewModelCliente.First().nuevaBusqueda();
            ViewModelProducto.First().limpiarProductos();
        }

        private void eventoCancelarPedido(object sender, EventArgs e)
        {
            ViewModelCliente.First().nuevaBusqueda();
            ViewModelProducto.First().limpiarProductos();
        }

        public ObservableCollection<ProductosViewModel> ViewModelProducto
        {
            get
            {
                if (_viewModelProducto == null) _viewModelProducto = new ObservableCollection<ProductosViewModel>();
                return _viewModelProducto;
            }
            private set
            {
                _viewModelProducto = value;

                //Se crean las firmas para el evento de ProductosViewModel, que es AdicionarProducto
                _viewModelProducto.First().AdicionarProducto += new EventHandler(eventoAdicionarProducto);
                OnPropertyChanged("ViewModelProducto");
            }
        }

        private void eventoAdicionarProducto(object sender, EventArgs e)
        {
            ViewModelPedido.First().AdicionarProducto(ViewModelProducto.First().ProductoActual);
        }

        public MainWindowViewModel()
        {

            ObservableCollection<ClienteViewModel> collectionParcialCliente = new ObservableCollection<ClienteViewModel>();
            ClienteViewModel clienteVM = new ClienteViewModel();
            collectionParcialCliente.Add(clienteVM);
            ViewModelCliente = collectionParcialCliente;

            ObservableCollection<ProductosViewModel> collectionParcialProductos = new ObservableCollection<ProductosViewModel>();
            ProductosViewModel productoVM = new ProductosViewModel();
            collectionParcialProductos.Add(productoVM);
            ViewModelProducto = collectionParcialProductos;

            ObservableCollection<PedidoViewModel> collectionParcialPedido = new ObservableCollection<PedidoViewModel>();
            PedidoViewModel pedidoVM = new PedidoViewModel();
            collectionParcialPedido.Add(pedidoVM);
            ViewModelPedido = collectionParcialPedido;

        }



    }
}
