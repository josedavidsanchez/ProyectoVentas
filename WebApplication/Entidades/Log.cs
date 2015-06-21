using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    //Esta clase representa los atributos de un log que se ha realizado
    public class Log
    {        
        //Tipo de actividad que se registra
        public string TipoTransaccion { get; set; }

        //Fecha en que se realiza el log
        public System.DateTime Fecha { get; set; }

        //Resultado de la actividad
        public string Resultado { get; set; }

        //Identificacion del usuario que realiza la actividad
        public string IDUsuario { get; set; }       
    }
}
