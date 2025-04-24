using Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ToolsWPF;
using WebApiClient;

namespace ViewModel
{
    public class ToolViewModel : DataContext
    {
        private readonly WebAPIClient _toolHttpClient;
        private ObservableCollection<Tools> _Tools { get; set; } = new ObservableCollection<Tools>();
        
        

        public ObservableCollection<Tools> Tools
        {
            get
            {
                return _Tools;
            }
            set
            {
                _Tools.Clear();

                foreach (var tool in value)
                {
                    _Tools.Add(tool);
                }

                OnPropertyChanged(nameof(Tools));
            }
        }

        public Tools _Tool { get; set; }
        public Tools Tool
        {
            get
            {

                return _Tool;
            }
            set
            {
                _Tool = value;
            }
        }

        //Proprietà per il nome del Tool
        public string ToolName { get; set; }

        //Proprietà per la descrizione
        public string ToolDescription { get; set; }

        string _SearchText;

        //Costruttore
        public ToolViewModel()
        {
            _toolHttpClient = new WebAPIClient();
            
            SearchToolCommand = new RelayCommand(SearchTools);
            Tools = new ObservableCollection<Tools>(_toolHttpClient.GetAllTools());

            MouseDoubleClick = new RelayCommand(OnMouseDoubleClick);

            EditToolCommand = new RelayCommand(ShowEditToolView, parameter => Tool !=null);

            DeleteToolCommand = new RelayCommand(DeleteTool, parameter => Tool != null);
        }

        public string SearchText
        {
            get
            {
                return _SearchText;
            }
            set
            {
                _SearchText = value;
                OnPropertyChanged("SearchText");
                SearchTools(); //aggiornamento in tempo reale mentre si digita
            }
        }

        private void SearchTools(object sender = null)
        {
            ObservableCollection<Tools> filteredTools = new ObservableCollection<Tools>(_toolHttpClient.GetAllTools());

            var searchText = SearchText.ToLower();

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                //Filtra per BoshCode
                filteredTools = new ObservableCollection<Tools>(filteredTools.Where(t => t.BoschCode != null && t.BoschCode.ToLower().Contains(searchText)).ToList());
            }

            Tools = filteredTools;
            
        }

        private void ShowEditToolView(object parameter)
        {
            if (Tool != null)
            {
                var editWindow = new ToolDetailsWindow(Tool); // Modalità modifica
                editWindow.DataContext = new ToolDetailsViewModel(Tool, ScreenMode.Edit);

                bool? result = editWindow.ShowDialog();

                if (result == true)
                {
                    Tools = new ObservableCollection<Tools>(_toolHttpClient.GetAllTools());
                }
            }
        }

        private void DeleteTool(object parameter)
        {
            if (Tool != null)
            {
                var deleteWindow = new ToolDetailsWindow(Tool); // Modalità eliminazione
                deleteWindow.DataContext = new ToolDetailsViewModel(Tool, ScreenMode.Delete);
                bool? result = deleteWindow.ShowDialog();

                if (result == true)
                {
                    Tools = new ObservableCollection<Tools>(_toolHttpClient.GetAllTools());
                }
            }
        }

        public RelayCommand SearchToolCommand { get; set; }

        public RelayCommand MouseDoubleClick { get; set; }

        public RelayCommand EditToolCommand { get; set; } //Comando e logica per aprire finestra modifica

        public RelayCommand DeleteToolCommand { get; set; } //Comando e logica per il tasto elimina


        private void OnMouseDoubleClick(object parameter)
        {
            
            if (Tool != null)
            {
                // Qui apri la finestra dei dettagli
                var detailsWindow = new ToolDetailsWindow(Tool);
                detailsWindow.ShowDialog();
            }
            
        }

        /*
        public void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            //Recupera testo digitato
            string searchText = SearchText.ToLower();

            //Recupera lista completa Tools
            List<DAO.Tools> tools = _service.GetAllTools();

            //Se la stringa di ricerca è vuota visualizza l'elenco completo
            if (string.IsNullOrEmpty(searchText))
            {
                Tools = tools;
                return;
            }

            //Filtra i Tools per BoshCode
            var filteredTools = tools.Where(t => t.BoschCode.ToLower().Contains(searchText));

            Tools = filteredTools.ToList();
        }
        */
    }
}
