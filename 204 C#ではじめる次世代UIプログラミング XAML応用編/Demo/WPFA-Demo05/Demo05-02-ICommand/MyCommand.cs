using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
//ICommandは System.Windows.Input に含まれます
using System.Windows.Input;

namespace Demo05_02_ICommand
{
    class MyCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            MessageBox.Show("Commandが呼ばれました");
        }
    }
}
