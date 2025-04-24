using WebApiClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using Domain;
using System.Windows.Input;


namespace ToolsWPF.ViewModel
{
    public class MachineViewModel : DataContext
    {
        private readonly WebAPIClient _toolHttpClient;
        public ObservableCollection<Machines> _Machines;

        public ObservableCollection<Machines> Machines
        {
            get
            {
                return _Machines;
            }
            set
            {
                _Machines = value;
                OnPropertyChanged(nameof(Machines));
            }
        }

        public Machines _Machine { get; set; } //Macchina selezionata

        public Machines Machine
        {
            get
            {

                return _Machine;
            }
            set
            {
                _Machine = value;
            }
        }

        public MachineViewModel()
        {
            _toolHttpClient = new WebAPIClient();
            LoadMachines();

            MouseDoubleClick = new RelayCommand (OnMouseDoubleClick); //Inizializza il comando doppio clic
        }

        private void LoadMachines() //Carica lista macchine utilizzando GetAllMachines
        {
            //Carica lista macchine
            Machines = new ObservableCollection<Machines>(
                _toolHttpClient.GetAllMachines().Select(machine => new Machines
                {
                    MachineCode = machine.MachineCode,
                    Description = machine.Description,
                    ToolType = machine.ToolType
                })
            );
        }

        public RelayCommand MouseDoubleClick { get; set; } // Comando per il doppio clic

        private void OnMouseDoubleClick(object parameter)
        {

            if (Machine != null)
            {
                // Crea la finestra passando la macchina selezionata al costruttore
                var detailsWindow = new MachineToolsWindow(Machine);
                detailsWindow.ShowDialog();
            }
        }
               
    }
}
