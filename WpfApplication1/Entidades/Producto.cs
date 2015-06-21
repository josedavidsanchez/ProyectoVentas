using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    //Esta clase representa los atributos de un producto
    public class Producto
    {
        //Codigo que identifica un producto dentro de la lista de todos los productos
        public string Codigo { get; set; }

        //Nombre del producto
        public string Nombre { get; set; }

        //Descripcion breve de lo que es el producto
        public string Descripcion { get; set; }

        //Precio actual del producto
        public double Precio { get; set; }

        //Categoria a la que pertenece un producto
        public string Categoria { get; set; }

        //Valor binario que indica si el precio actual del producto es de promocion o si existe alguna oferta para el actual producto
        //true si existe oferta, false sino existe
        public bool EnOferta { get; set; }

        //Ruta dentro del sistema archivo donde se ubica la imagen o foto que representa el producto
        public string Imagen { get; set; }
    }
}
