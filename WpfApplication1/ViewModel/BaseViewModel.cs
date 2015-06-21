using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.ViewModel
{
    // Clase base para las notificaciones y los bindings
    public class BaseViewModel : INotifyPropertyChanged, IDisposable
    {
        #region atributos
        /// <summary>
        /// Esta propiedad indica si se esta haciendo alguna operacion que necesite
        /// sincronizacion con la vista.
        /// </summary>
        private bool _estaOcupado;
        /// <summary>
        /// Mensaje de error cuando ocurre
        /// </summary>
        ObservableCollection<string> _error;
        #endregion

        #region propiedades
        /// <summary>
        /// Esta propiedad indica si se esta haciendo alguna operacion que necesite
        /// sincronizacion con la vista.
        /// </summary>
        //PSP_METRICS_METHOD_BEGIN : EstaOcupado
        public bool EstaOcupado
        {
            get
            {
                return _estaOcupado;
            }
            set
            {
                _estaOcupado = value;
                OnPropertyChanged("EstaOcupado");
            }
        }
        //PSP_METRICS_METHOD_END
        /// <summary>
        /// Mensaje de error cuando ocurre
        /// </summary>
        //PSP_METRICS_METHOD_BEGIN : Error
        public ObservableCollection<string> Error
        {
            get
            {
                if (_error == null)
                    _error = new ObservableCollection<string>();
                return _error;
            }
            set
            {
                _error = value;
                OnPropertyChanged("Error");
            }
        }
        //PSP_METRICS_METHOD_END
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Dispose()
        {
            this.OnDispose();
        }

        protected virtual void OnDispose()
        {
            throw new NotImplementedException();
        }
    }
}
