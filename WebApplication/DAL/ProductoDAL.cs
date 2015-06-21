using Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductoDAL
    {
        //Metodo actualiza el precio de los productos que se encuentran en la collection productos
        //Retorna una cadena donde se muestra los productos que fallaron en la actualizacion
        public string actualizarPrecios(ObservableCollection<Producto> productos)
        {
            using (VENTASserverdbEntities contexto = new VENTASserverdbEntities())
            {
                string resultado = "";
                try
                {
                    
                    foreach (Producto productoActualizar in productos)
                    {
                        PRODUCTO productoEF = contexto.PRODUCTOS.Where(p => p.Codigo == productoActualizar.Codigo).FirstOrDefault();
                        if (productoEF != null) productoEF.Precio = productoActualizar.Precio;
                        else resultado = resultado + "\n Producto " + productoActualizar.Codigo + " no existe";
                    }
                }
                catch (Exception e)
                {
                    resultado = resultado + "\n Error " + e.Message;
                }
                return resultado;
            }
        }

    }
}
