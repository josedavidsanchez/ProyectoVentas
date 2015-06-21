using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    //Esta clase representa los atributos de un cliente
    public class Cliente
    {
        //Nit que identifica al cliente como empresa, en caso que el cliente sea persona natural puede ser su numero de cedula
        public string Nit { get; set; }

        //Nombre de cliente
        public string Nombre { get; set; }

        //Telefono de contacto del cliente
        public string Telefono { get; set; }
        
        //Direccion donde se ubica la sede del cliente
        public string Direccion { get; set; }

        //Ciudad a la que corresponde la direccion del cliente
        public string Ciudad { get; set; }

        //Nombre de administrador o encargado de realizar los pedidos en el cliente
        public string NombreContacto { get; set; }

        //Numero del documento de identificacion del vendedor a quien se ha asignado el cliente
        public string IdentificacionVendedor { get; set; }

    }
}
