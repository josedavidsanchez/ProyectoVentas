using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    //Clase que controla el acceso a la base de datos mediante entity framework para las funcionalidad de registros de actividades de los usuarios de la aplicacion
    public class LogDAL
    {
        //Metodo registra el log dado como parametro dentro de la base de datos.
        public void registrarLog(Entidades.Log log)
        {
            using (ModeloDesconectado contexto = new ModeloDesconectado())
            {
                try
                {
                    LOGS logs = mapearLogInsert(log);
                    contexto.LOGS.Add(logs);
                    contexto.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        //Retorna un log correspondiente al modelo LOGS de entity framework, mapeando atributo por atriburo
        private LOGS mapearLogInsert(Log item)
        {
            LOGS logs = new LOGS();
            logs.TipoTransaccion = item.TipoTransaccion;
            logs.Fecha = item.Fecha;
            logs.Resultado = item.Resultado;
            logs.IdentificacionUsuario = item.IDUsuario;

            return logs;
        }

        //Retorna un log correspondiente a la entidad Log, mapeando atributo por atriburo
        private Log mapearPedido(LOGS item)
        {
            Log log = new Log();
            log.TipoTransaccion = item.TipoTransaccion;
            log.Fecha = item.Fecha;
            log.Resultado = item.Resultado;
            log.IDUsuario = item.IdentificacionUsuario;

            return log;
        }
    }
}
