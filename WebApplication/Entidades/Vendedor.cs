using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    //Esta clase representa los atributos de un vendedor
    public class Vendedor
    {
        //Numero de documento de identificacion del vendedor
        public string Identificacion { get; set; }

        //Nombres del vendedor, primer y segundo nombre separados por un espacio
        public string Nombre { get; set; }

        //Apellidos del vendedor, primer y segundo apellido separados por un espacio
        public string Apellido { get; set; }

        //Numero de telefono de contacto del vendedor
        public string Telefono { get; set; }

        //Direccion de residencia del vendedor
        public string Direccion { get; set; }

        //Contrasena propia del vendedor, con la que se validara su identificacion para acceso al sistema
        public string password { get; set; }
    }
}
