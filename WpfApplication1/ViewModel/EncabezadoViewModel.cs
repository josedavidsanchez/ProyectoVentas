using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.ViewModel
{
    ///Esta clase la creamos para soportar todo el comportamiento comun del encabezado
    ///
    public class EncabezadoViewModel : BaseViewModel
    {
        bool _buscarHabilitado;
        bool _crearPedidoHabilitado;
        bool _verPedidosHabilitado;
        bool _resultadoHabilitado;

        public bool BuscarHabilitado
        {
            get { return _buscarHabilitado; }
            set
            {
                _buscarHabilitado = value;
                OnPropertyChanged("BuscarHabilitado");
            }
        }

        public bool CrearPedidoHabilitado
        {
            get { return _crearPedidoHabilitado; }
            set
            {
                _crearPedidoHabilitado = value;
                OnPropertyChanged("CrearPedidoHabilitado");
            }
        }

        public bool VerPedidosHabilitado
        {
            get { return _verPedidosHabilitado; }
            set
            {
                _verPedidosHabilitado = value;
                OnPropertyChanged("VerPedidosHabilitado");
            }
        }

        public bool ResultadoHabilitado
        {
            get { return _resultadoHabilitado; }
            set
            {
                _resultadoHabilitado = value;
                OnPropertyChanged("ResultadoHabilitado");
            }
        }

        protected void HabilitarBusqueda()
        {
            BuscarHabilitado = true;
            ResultadoHabilitado = true;
            CrearPedidoHabilitado = false;
            VerPedidosHabilitado = false;
        }

        protected void HabilitarOpcionesPedido()
        {
            BuscarHabilitado = true;
            ResultadoHabilitado = true;
            CrearPedidoHabilitado = true;
            VerPedidosHabilitado = true;

        }

        protected void DeshabilitarEncabezado()
        {
            BuscarHabilitado = false;
            ResultadoHabilitado = false;
            CrearPedidoHabilitado = false;
            VerPedidosHabilitado = false;
        }

    }
}
