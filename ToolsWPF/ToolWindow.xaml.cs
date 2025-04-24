using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModel;
using WebApiClient;

namespace ToolsWPF
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class ToolWindow : Window
    {
        private readonly WebAPIClient _toolHttpClient;


        //private readonly Services.Service _service;

        public ToolWindow()
        {
            InitializeComponent();
            DataContext = new ToolViewModel();
           // _service = new Services.Service();

            //Carica inizialmente la lista dei Tools
            //LoadTools();
        }


        /*

        //Metodo per recuperare la lista dei tools e assegnarla alla griglia
        private void LoadTools()
        {
            List<DAO.Tools> tools = _service.GetAllTools();

            ToolsDataGrid.ItemsSource = tools;

        }

        //Evento che si attiva ad ogni modifica del testo nella casella di ricerca
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchTools(SearchTextBox.Text);
        }

        //Metodo che filtra i dati in base al testo inserito
        private void SearchTools(string searchText)
        {
            List<DAO.Tools> filteredTools = _service.GetAllTools();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                //Filtra per BoshCode
                filteredTools = filteredTools.Where(t => t.BoschCode.ToLower().Contains(searchText)).ToList();
            }

            ToolsDataGrid.ItemsSource = filteredTools;
        }

        //Metodo che si attiva alla pressione del tasto "Cerca"
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            //Recupera testo digitato
            string searchText = SearchTextBox.Text.ToLower();

            //Recupera lista completa Tools
            List<DAO.Tools> tools = _service.GetAllTools();

            //Se la stringa di ricerca è vuota visualizza l'elenco completo
            if (string.IsNullOrEmpty(searchText))
            {
                ToolsDataGrid.ItemsSource = tools;
                return;
            }

            //Filtra i Tools per BoshCode
            var filteredTools = tools.Where(t => t.BoschCode.ToLower().Contains(searchText));

            
            var filteredTools = tools.Where(t => t.Description.ToLower().Contains(searchText) ||
                                                 t.BoschCode.ToLower().Contains(searchText) ||
                                                 t.PrimarySupplier.ToLower().Contains(searchText) ||
                                                 t.SecondarySupplier.ToLower().Contains(searchText)).ToList();
            

            ToolsDataGrid.ItemsSource = filteredTools;
        }
        */
    }
}
