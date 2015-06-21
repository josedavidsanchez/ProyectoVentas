using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAL;
using System.Collections.ObjectModel;

namespace BL
{

    //Clase que controla el business logic para las funcionalidades correspondientes a la entidad productos
    public class ProductoBL
    {
        //Contexto almacena la instancia del acceso a datos para la entidad producto

        //Trae desde la base de datos el producto el cual se identifica por el parametro "codigoProducto"
        public Producto consultarProductoPorCodido(string codigoProducto)
        {
            ProductoDAL contexto = new ProductoDAL();
            Producto producto = contexto.consultarProductoPorCodigo(codigoProducto);

            return producto;
        }

        //Trae desde la base de datos todos los productos disponibles para la venta
        public ObservableCollection<Producto> consultarProductos()
        {
            ProductoDAL contexto = new ProductoDAL();

            ObservableCollection<Producto> collectionProductos = new ObservableCollection<Producto>();
            collectionProductos = contexto.obtenerProductos();

            return collectionProductos;
        }
    }
}
