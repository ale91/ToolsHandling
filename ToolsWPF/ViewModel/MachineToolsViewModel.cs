using Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using WebApiClient;

namespace ToolsWPF.ViewModel
{
    public class MachineToolsViewModel : DataContext
    {       
        private ObservableCollection<Tools> _ToolsMountedToTheMachines = new ObservableCollection<Tools>(); //Lista completa
        private ObservableCollection<Tools> _FilteredToolsForCombobox = new ObservableCollection<Tools>(); //Lista filtrata
        private readonly WebAPIClient _toolHttpClient;

        private Tools _selectedTool;



        public RelayCommand MouseDoubleClick { get; set; }
        public RelayCommand SaveToolCommand { get; set; }


        public ObservableCollection<Tools> FilteredToolsForCombobox
        {
            get
            {
                return _FilteredToolsForCombobox;
            }
            set
            {
                _FilteredToolsForCombobox.Clear();

                foreach (var tool in value)
                {
                    _FilteredToolsForCombobox.Add(tool);
                }
                                
                OnPropertyChanged(nameof(FilteredToolsForCombobox));

            }
        }

        public ObservableCollection<Tools> ToolsMountedToTheMachines
        {
            get
            {
                return _ToolsMountedToTheMachines;
            }
            set
            {
                _ToolsMountedToTheMachines.Clear();

                foreach (var tool in value)
                {
                    _ToolsMountedToTheMachines.Add(tool);
                }

                
                OnPropertyChanged(nameof(ToolsMountedToTheMachines));
            }
        }

        public Tools SelectedTool
        {
            get
            {
                return _selectedTool;
            }
            set
            {
                _selectedTool = value;
                OnPropertyChanged(nameof(SelectedTool));
            }
        }
        
        public Machines Machine { get; set; }
        
        /*{
            get
            {
                return _machine;
            }
            set
            {
                if (_machine != value)
                {
                    _machine = value;
                    OnPropertyChanged(nameof(Machine));
                }
            }
        }
        */
        

        //Costruttore che accetta un parametro di tipo Machines
        public MachineToolsViewModel(Machines machine)
        {
            Machine = machine;
            _toolHttpClient = new WebAPIClient();

            GetToolsByMachineToolType();
            GetToolsByMachine();
                       

            MouseDoubleClick = new RelayCommand(OnMouseDoubleClick);
            SaveToolCommand = new RelayCommand(param => SaveSelectedTool());
        }

        private void OnMouseDoubleClick(object parameter)
        {

            if (Machine != null)
            {
                // Qui apri la finestra dei dettagli
                var detailsWindow = new MachineToolsWindow(Machine);
                detailsWindow.ShowDialog();
            }

        }


        private void GetToolsByMachineToolType()
        {
             
            //Controllo se Machine non è null, HasValue controlla se tooltype non è null
            if (Machine?.ToolType.HasValue ?? false)
            {
                // Usa il ToolType della macchina per filtrare i tool
                var tools = _toolHttpClient.GetToolsByToolType((int)Machine.ToolType)
                    .Where(tool => string.IsNullOrEmpty(tool.Machine)); //Esclude i tool già assegnati a una macchina

                //.Where(tool => !ToolsMountedToTheMachines.Any(mountedTool => mountedTool.IdTool == tool.IdTool)); //Esclude i tool già montati sulla macchina

                FilteredToolsForCombobox = new ObservableCollection<Tools>(tools);
            }
            else
            {
                //Nessun filtro, mostra lista vuota, se il tooltype non è specificato
                FilteredToolsForCombobox = new ObservableCollection<Tools>();
            }
        }


        //Recupero tools sulla macchina
        private void GetToolsByMachine()
        {            
            ToolsMountedToTheMachines = new ObservableCollection<Tools>(_toolHttpClient.GetToolsByMachine(Machine.MachineCode));
        }

        
        //Metodo per salvare il tool selezionato
        public void SaveSelectedTool()
        {
            if (SelectedTool != null && Machine != null)
            {
                //Imposta campo Machine tool selezionato con codice della macchina visualizzata
                SelectedTool.Machine = Machine.MachineCode;
                _toolHttpClient.UpdateTools(SelectedTool);

                //Per salvare il tool selezionato
                /*
                var service = new Service();
                service.UpdateTools(SelectedTool);
                */

                //Aggiorna la lista dei tool montati sulla macchina
                GetToolsByMachine();

                //Aggiorna la lista dei tool nella combobox
                GetToolsByMachineToolType();

                //Resetta il tool selezionato
                SelectedTool = null;

                //Notifica che il tool selezionato è stato aggiornato
                OnPropertyChanged(nameof(SelectedTool));
            }
        }
        
    }    
}
