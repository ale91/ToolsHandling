using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModel;
using Domain;

namespace ToolsWPF.ViewModel
{
    public class MainViewModel : DataContext
    {
        public ICommand OpenToolsCommand { get; }
        public ICommand OpenMachinesCommand { get; }

        public MainViewModel()
        {
            OpenToolsCommand = new RelayCommand(OpenTools);
            OpenMachinesCommand = new RelayCommand(OpenMachines);
        }

        private void OpenTools(object parameter)
        {
            //Crea nuova istanza di ToolWindow 
            var toolWindow = new ToolWindow
            {
                //Imposto il DataContext su ToolViewModel
                DataContext = new ToolViewModel()
            };

            //Mostra la finestra
            toolWindow.Show();
        }

        private void OpenMachines(object parameter)
        {
            // Crea nuova istanza di MachineWindow
            var machineWindow = new MachineWindow
            {
                // Imposta il DataContext su MachineViewModel
                DataContext = new MachineViewModel()
            };

            // Mostra la finestra
            machineWindow.Show();
        }
    }

}
