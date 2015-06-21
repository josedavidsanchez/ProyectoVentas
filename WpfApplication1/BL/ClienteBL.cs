using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    //Clase que controla el business logic para las funcionalidades correspondientes a la entidad Cliente
    public class ClienteBL
    {
        //Contexto almacena la instancia del acceso a datos para la entidad cliente

        public ObservableCollection<Cliente> consultarClientesPorNombre(string nombreCliente)
        {    
            ClienteDAL contexto = new ClienteDAL();

            //Se almacena los clientes retornados en la variable clientes
            ObservableCollection<Cliente> clientes = contexto.consultarClientesPorNombre(nombreCliente);

            return clientes;
        }
    }
}