using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApplication1.ViewModel
{
    /// Clase base para generar comandos en la UI

    class RelayCommand : ICommand
    {
        #region Fields

        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;

        #endregion

        #region Constructors

        // Crea un nuevo comando que se puede ejecutar siempre. El parametro execute indica la ejecucion logica
        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        //Crea un nuevo comando. El parametro execute indica la ejecucion logica, parametro canExecute inidica el estado de
        //ejecucion logica del comando, si puede o no ejecutarse actualmente
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion

        #region ICommand Members

        // Método que indica si se peude ejecutar el comando. Parametro es el objeto que hace el llamado
        // retorna: true-> si pueden ejecutar el comando.  false -> si no se puede ejecutar el comando
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        // Evento que monitorea el cambio en las condiciones de ejecucion del evento
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        // Metodo que representa la ejecución del evento.
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
        #endregion
    }
}
