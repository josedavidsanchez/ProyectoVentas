using Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    //Clase que controla el acceso a la base de datos mediante entity framework para las funcionalidades correspondientes a la entidad producto
    public class ProductoDAL
    {

        //Retorna un conjunto de tipo ObservableCollection de productos disponibles almacenados en la base de datos
        public ObservableCollection<Producto> obtenerProductos()
        {
            using (ModeloDesconectado contexto = new ModeloDesconectado())
            {
                ObservableCollection<Producto> respuesta = new ObservableCollection<Producto>();
                List<PRODUCTOS> productos = contexto.PRODUCTOS.ToList();

                foreach (var item in productos)
                {
                    Producto actual = mapearProducto(item);
                    respuesta.Add(actual);
                }
                return respuesta;
            }
        }

        //Retorna desde la base de datos un producto que es identificado por el codigoProducto dado como parametro
        public Producto consultarProductoPorCodigo(string codigoProducto)
        {
            
            using (ModeloDesconectado contexto = new ModeloDesconectado())
            {
                PRODUCTOS prod = contexto.PRODUCTOS.Where(p => p.Codigo == codigoProducto).FirstOrDefault();
                if (prod != null)
                {
                    Producto producto = new Producto();
                    producto.Codigo = prod.Codigo;
                    producto.Nombre = prod.Nombre;
                    producto.Descripcion = prod.Descripcion;
                    producto.Precio = (double)prod.Precio;
                    producto.Categoria = prod.Categoria;
                    producto.EnOferta = prod.EnOferta;

                    return producto;
                }
                return null;
            }
        }

        //Retorna un dato correspondiente a la endidad producto, mapeando atributo por atriburo del item
        //recibido como parametro que corresponde al de entity framework del modelo PRODUCTOS
        private Producto mapearProducto(PRODUCTOS item)
        {
            Producto producto = new Producto();
            producto.Codigo = item.Codigo;
            producto.Nombre = item.Nombre;
            producto.Descripcion = item.Descripcion;
            producto.Precio = (double)item.Precio;
            producto.Categoria = item.Categoria;
            producto.EnOferta = item.EnOferta;
            producto.Imagen = item.Imagen;

            return producto;
        }
    }
}
