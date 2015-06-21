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

    //Clase que controla el business logic para las funcionalidades correspondientes a la entidad vendedores
    public class VendedorBL
    {

        //Trae desde la base de datos el vendedor quien corresponde el dispositivo local
        public Vendedor consultarVendedor()
        {
            VendedoresDAL contexto = new VendedoresDAL();
            return contexto.obtenerVendedor();

        }

        public bool verificarIngreso(string id, string pass)
        {
            VendedoresDAL contexto = new VendedoresDAL();
            Vendedor vendedor = contexto.obtenerVendedor();
            if (vendedor.Identificacion == id && vendedor.password == pass) return true;
            else return false;
        }
    }
}
