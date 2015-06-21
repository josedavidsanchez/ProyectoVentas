using BL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApplication1.ViewModel
{
    //Clase que administra la UI ListadoProductos
    public class ProductosViewModel : BaseViewModel
    {
        Producto _productoActual;
        ObservableCollection<Producto> _productos;

        public Producto ProductoActual
        {
            get { return _productoActual; }
            set
            {
                _productoActual = value;
                OnAdicionarProducto(EventArgs.Empty);
                OnPropertyChanged("ProductoActual");
            }
        }

        public ObservableCollection<Producto> Productos
        {
            get { return _productos; }
            set
            {
                _productos = value;
                OnPropertyChanged("Productos");
            }
        }

        //Muestra en la UI todos los productos disponibles para realizar un pedido
        public void ListarProductos()
        {
            ProductoBL bl = new ProductoBL();
            Productos = new ObservableCollection<Producto>();
            Productos = bl.consultarProductos();
        }

        //Quita en la UI todos los productos disponibles para realizar un pedido cuando se ha cancelado un pedido
        // o cuando se elige otra funcionalidad
        public void limpiarProductos()
        {
            Productos = new ObservableCollection<Producto>();
        }

        protected virtual void OnAdicionarProducto(EventArgs e)
        {
            EventHandler handler = AdicionarProducto;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        //Evento que se lanza para enviar producto seleccionado a la vista de Pedido para ser adicionado a la lista
        // de productos en el pedido actual
        public event EventHandler AdicionarProducto;
    }
}
