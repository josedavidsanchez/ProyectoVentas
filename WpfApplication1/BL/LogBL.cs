using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class LogBL
    {
        public void registrarLog(string tipo_transaccion, string resultado, string id_usuario) 
        {
            Log log = new Log();
            log.TipoTransaccion = tipo_transaccion;
            log.Fecha = DateTime.Now;
            log.Resultado = resultado;
            log.IDUsuario = id_usuario;

            LogDAL logdal = new LogDAL();
            logdal.registrarLog(log);

        }
    }
}
