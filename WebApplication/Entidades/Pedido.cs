using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Entidades
{
    //Esta clase representa los atributos de un pedido que se ha realizado
    public class Pedido
    {

        private ObservableCollection<Entidades.ListaPedido> _productos;

        //Codigo que identifica el pedido
        public string Codigo { get; set; }

        //Valor total del pedido, es la suma de los totales por producto
        public double Total { get; set; }

        //Fecha en que se realiza el pedido
        public System.DateTime Fecha { get; set; }

        //Identificacion del cliente que realiza el pedido
        public string NitCliente { get; set; }

        //Lista de los productos que ha pedido el cliente para la instancia actual de pedido
        public ObservableCollection<Entidades.ListaPedido> Productos
        {
            get
            {
                if (_productos == null) _productos = new ObservableCollection<ListaPedido>();
                return _productos; }
            set { _productos = value; }
        }
    }
}
