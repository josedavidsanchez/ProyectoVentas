using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    //Clase que controla el acceso a la base de datos mediante entity framework para las funcionalidades correspondientes a la entidad vendedor
    public class VendedoresDAL
    {

        //Busca en la base de datos y retorna el vendedor que esta registrado como a quien pertenece el dispositivo local
        public Vendedor obtenerVendedor()
        {
            using (ModeloDesconectado contexto = new ModeloDesconectado())
            {
                VENDEDORES vendedor = contexto.VENDEDORES.ToList().First();

                Vendedor respuesta = mapearVendedor(vendedor);

                return respuesta;
            }
        }

        //Retorna un dato correspondiente a la endidad vendedor, mapeando atributo por atriburo del item
        //recibido como parametro que corresponde al de entity framework del modelo VENDEDORESs
        private Entidades.Vendedor mapearVendedor(VENDEDORES item)
        {
            Entidades.Vendedor vendedor = new Entidades.Vendedor();
            vendedor.Identificacion = item.Identificacion;
            vendedor.Nombre = item.Nombre;
            vendedor.Apellido = item.Apellido;
            vendedor.Telefono = item.Telefono;
            vendedor.Direccion = item.Direccion;
            vendedor.password = item.password;

            return vendedor;
        }
    }
}
