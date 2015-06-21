using DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    //Clase que controla el business logic para las funcionalidades correspondientes a la entidad Pedido y Lista pedidos
    public class PedidoBL
    {

        //Contexto almacena la instancia del acceso a datos para la entidad Pedidos y lista pedido


        //Este metodo almacena en la base de datos el nuevo pedido que se pasa por parametro
        public void registrarPedido(Entidades.Pedido pedido)
        {
            PedidoDAL contexto = new PedidoDAL();

            //Se crea aleatoriamente un codigo de pedido para asignar al nuevo pedido
            pedido.Codigo = "" + new Random().Next(9999);
            pedido.Fecha = DateTime.Now;
            pedido.Total = calcularTotalPedido(pedido);
            contexto.registrarPedido(pedido);
        }

        //Trae desde la base de datos los pedidos realizados por el cliente pasado como parametro
        //Retorna un conjunto de pedidos almacenados en una coleccion ObservableCollection
        public ObservableCollection<Entidades.Pedido> obtenerPedidosPorCliente(Entidades.Cliente cliente)
        {
            PedidoDAL contexto = new PedidoDAL();
            ObservableCollection<Entidades.Pedido> clientes = contexto.obtenerPedidosPorCliente(cliente);

            return clientes;
        }

        //Calcula el valor total de un pedido, sumando el valorsubtotal por cada item.
        public double calcularTotalPedido(Entidades.Pedido pedido)
        {
            double suma=0;
            foreach (Entidades.ListaPedido producto in pedido.Productos)
            {
                if (producto.Cantidad < 0) return -1;
                producto.Total = producto.Cantidad * producto.PrecioVenta;
                suma += producto.Total;
            }

            return suma;
        }

    }
}
