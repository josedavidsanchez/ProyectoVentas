using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    //Clase que controla el acceso a la base de datos mediante entity framework para las funcionalidades correspondientes a la entidad Cliente
    public class ClienteDAL
    {

        //Metodo accede a la base de datos mediante entity framework y retorna los clientes cuyo nombre coincide en cualquier
        //posicion de caracteres con el parametro nombreCliente.
        
        public ObservableCollection<Entidades.Cliente> consultarClientesPorNombre(string nombreCliente)
        {
            using (ModeloDesconectado contexto = new ModeloDesconectado())
            {
                //Collection que almacena los clientes
                ObservableCollection<Entidades.Cliente> respuesta = new ObservableCollection<Entidades.Cliente>();

                //Variable clientes almacena temporalmente la lista de clientes que retorna la base de datos para luego hacer
                // mapeo de tipos desde variable clientes a variable respuesta
                var clientes = contexto.CLIENTES.Where(p => p.Nombre.Contains(nombreCliente));
                
                foreach (var item in clientes)
                {
                    Entidades.Cliente actual = mapearCliente(item);
                    respuesta.Add(actual);
                }
                return respuesta;
            }
        }

        //Metodo que mapea atributo por atributo del tipo de dato cliente de entity framework, y retorna un dato de la entidad cliente
        private Entidades.Cliente mapearCliente(CLIENTES item)
        {
            Entidades.Cliente cliente = new Entidades.Cliente();
            cliente.Nit = item.Nit;
            cliente.Nombre = item.Nombre;
            cliente.Telefono = item.Telefono;
            cliente.Direccion = item.Direccion;
            cliente.Ciudad = item.Ciudad;
            cliente.IdentificacionVendedor = item.IdentificacionVendedor;

            return cliente;
        }
    }
}
