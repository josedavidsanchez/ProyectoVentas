using Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ProductoBL
    {

        //Carga un archivo csv y actualiza los precios de los productos. Crea un archivo en el mismo folder donde se encontro
        //el archivo con un log de errores de la actualizacion
        public void asignarPreciosPorArchivo(string ubicacionArchivo)
        {
            string line;
            string resultado = "";
            int lineNumber = 0;
            ObservableCollection<Producto> productos = new ObservableCollection<Producto>();
            
            System.IO.StreamReader file =
                new System.IO.StreamReader(@ubicacionArchivo);
            while ((line = file.ReadLine()) != null)
            {
                lineNumber++;
                string[] lineArray = line.Split(',');
                if (lineArray.Count() != 2) resultado = resultado + "\n Error en la linea " + lineNumber;

                try
                {
                    Producto productoActual = new Producto();
                    productoActual.Codigo = lineArray[0];
                    productoActual.Precio = Convert.ToDouble(lineArray[1]);
                    productos.Add(productoActual);
                }
                catch (Exception e)
                {
                    resultado = resultado + "\n Error " + e.Message + " en la linea " + lineNumber;
                }
            }

            file.Close();

            if (lineNumber == 0) resultado = "Archivo vacio";

            System.IO.FileInfo infoArchivo = new System.IO.FileInfo(@ubicacionArchivo);
            string folderPath = infoArchivo.DirectoryName;
            using (System.IO.StreamWriter outfile = new System.IO.StreamWriter(folderPath + @"\errorPrecios.log"))
            {
                outfile.Write(resultado);
            }            
        }
    }
}
