using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    //Clase que controla el acceso a la base de datos mediante entity framework para las funcionalidades correspondientes a la entidad pedido y listaPedido
    public class PedidoDAL
    {

        //Metodo registra el pedido dado como parametro dentro de la base de datos.
        public void registrarPedido(Entidades.Pedido pedido)
        {
            using (ModeloDesconectado contexto = new ModeloDesconectado())
            {
                try {
                    PEDIDO pedidoEF = mapearPedidoInsert(pedido);
                    contexto.PEDIDO.Add(pedidoEF);
                    contexto.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        //Retorna un conjunto de tipo ObservableCollection de pedidos que pertenece al cliente dado como parametro almacenados
        // en la base de datos
        public ObservableCollection<Entidades.Pedido> obtenerPedidosPorCliente(Entidades.Cliente cliente)
        {
            using (ModeloDesconectado contexto = new ModeloDesconectado())
            {
                ObservableCollection<Entidades.Pedido> respuesta = new ObservableCollection<Entidades.Pedido>();
                var pedidos = contexto.PEDIDO.Where(p => p.CLIENTES.Nit == cliente.Nit);

                foreach (var item in pedidos)
                {
                    Pedido actual = mapearPedido(item);
                    respuesta.Add(actual);
                }
                return respuesta;
            }
        }

        //Retorna un pedido correspondiente al modelo PEDIDO de entity framework, mapeando atributo por atriburo, incluido cada item
        // de tipo LISTA_PEDIDO del pedido recibido como parametro que corresponde a la entidad Pedido
        private PEDIDO mapearPedidoInsert(Pedido item)
        {
            PEDIDO pedido = new PEDIDO();
            pedido.Codigo = item.Codigo;
            pedido.NitCliente = item.NitCliente;
            pedido.Fecha = item.Fecha;
            pedido.Total = item.Total;

            foreach (ListaPedido p in item.Productos)
            {
                LISTA_PEDIDO producto = new LISTA_PEDIDO();

                producto.CodPedido = p.Pedido.Codigo;
                producto.CodProducto = p.Producto.Codigo;
                producto.Cantidad = p.Cantidad;
                producto.PrecioVenta = p.PrecioVenta;
                pedido.LISTA_PEDIDO.Add(producto);
            }

            return pedido;
        }

        //Retorna un pedido correspondiente a laendidad pedido, mapeando atributo por atriburo, incluyendo cada item
        // de tipo listaPedido del pedido recibido como parametro que corresponde al de entity framework del modelo PEDIDO
        private Pedido mapearPedido(PEDIDO item)
        {
            Pedido pedido = new Pedido();
            pedido.Codigo = item.Codigo;
            pedido.Total = item.Total;
            pedido.Fecha = item.Fecha;
            pedido.NitCliente = item.NitCliente;

            foreach (LISTA_PEDIDO p in item.LISTA_PEDIDO)
            {
                ListaPedido productoActual = new ListaPedido();
                productoActual.Pedido = pedido;
                productoActual.Producto.Categoria = p.PRODUCTOS.Categoria;
                productoActual.Producto.Codigo = p.PRODUCTOS.Codigo;
                productoActual.Producto.EnOferta = p.PRODUCTOS.EnOferta;
                productoActual.Producto.Descripcion = p.PRODUCTOS.Descripcion;
                productoActual.Producto.Imagen = p.PRODUCTOS.Imagen;
                productoActual.Producto.Nombre = p.PRODUCTOS.Nombre;
                productoActual.Cantidad = p.Cantidad;
                productoActual.PrecioVenta = p.PrecioVenta;
                productoActual.Total = productoActual.Cantidad * productoActual.PrecioVenta;
                pedido.Productos.Add(productoActual);
            }

            return pedido;
        }

    }
}
