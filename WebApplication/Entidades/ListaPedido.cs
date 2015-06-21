using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    //Esta clase representa los atributos de un producto que se a adicionado en un pedido
    public class ListaPedido
    {
        Pedido _pedido;
        Producto _producto;
        int _cantidad;
        double _total;

        //Pedido al que pertence la instancia actual de listaPedido
        public Pedido Pedido
        {
            get
            {
                if (_pedido == null) _pedido = new Pedido();
                return _pedido;
            }
            set
            {
                _pedido = value;
            }
        }

        //Producto que ha seleccionado para un pedido
        public Producto Producto
        {
            get
            {
                if (_producto == null) _producto = new Producto();
                return _producto;
            }
            set
            {
                _producto = value;
            }
        }

        //Cantidad del producto seleccionado para el pedido
        public int Cantidad
        {
            get { return _cantidad; }
            set
            {
                _cantidad = value;
                Total = _cantidad * PrecioVenta;
            }
        }

        //Precio del producto en el momento de realizar el pedido
        public double PrecioVenta { get; set; }

        //Precio total del producto en el pedido
        public double Total { 
            get {
                return _total;
            }
            set {
                _total = value;
            }
        }

    }
}
