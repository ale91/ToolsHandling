using Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WebApiClient;

namespace ViewModel
{
    public class ToolDetailsViewModel : DataContext
    {
        private readonly WebAPIClient _toolHttpClient;
        //private readonly Service _service = new Service(); // Istanza del servizio

        private Tools _tool;

        private bool _isEditMode;

        private bool _isDeleteMode;
        public Tools Tool
        {
            get { return _tool; }
            set
            {
                if (_tool != value)
                {
                    _tool = value; 
                    OnPropertyChanged(nameof(Tool));
                }
            }
        }

        public bool IsEditMode
        {
            get { return _isEditMode; }
            set
            {
                if (_isEditMode = value)
                {
                    _isEditMode = value;
                    OnPropertyChanged(nameof(IsEditMode));
                }
                
            }
        }

        public bool IsDeleteMode
        {
            get { return _isDeleteMode; }
            set
            {
                if (_isDeleteMode = value)
                {
                    _isDeleteMode = value;
                    OnPropertyChanged(nameof(IsDeleteMode));
                }
                
            }
        }

        
        public RelayCommand SaveCommand { get; } //Comando per il salvataggio
        public RelayCommand DeleteCommand { get; } // Comando per l'eliminazione
        public RelayCommand CancelCommand { get; } //Comando per annullare

        public ToolDetailsViewModel(Tools selectedTool, ScreenMode mode = ScreenMode.Details)
        {
            Tool = selectedTool;

            // Imposta le modalità in base al valore dell'intero
            IsEditMode = mode ==  ScreenMode.Edit;
            IsDeleteMode = mode == ScreenMode.Delete;

            SaveCommand = new RelayCommand(SaveTool);
            DeleteCommand = new RelayCommand(DeleteTool);
            CancelCommand = new RelayCommand(Cancel);
        }

        //Metodo per il salvataggio
        private void SaveTool(object parameter)
        {
            try
            {
                // Chiama il metodo del servizio per aggiornare il tool
                _toolHttpClient.UpdateTools(Tool);

                // Imposta il DialogResult della finestra attiva a true per chiuderla
                Window activeWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
                if (activeWindow != null)
                {
                    activeWindow.DialogResult = true;
                }
            }
            catch (Exception ex)
            {
                // Mostra un messaggio di errore in caso di problemi
                MessageBox.Show($"Errore durante il salvataggio: {ex.Message}", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteTool(object parameter)
        {
            if (Tool != null)
            {
                // Mostra un messaggio di conferma
                var result = MessageBox.Show($"Sei sicuro di voler eliminare il tool '{Tool.Description}'?",
                                             "Conferma Eliminazione",
                                             MessageBoxButton.YesNo,
                                             MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        // Elimina il tool tramite il servizio
                        _toolHttpClient.DeleteTools(Tool.IdTool);

                        // Mostra un messaggio di successo
                        MessageBox.Show("Tool eliminato con successo!", "Eliminazione", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        // Mostra un messaggio di errore in caso di problemi
                        MessageBox.Show($"Errore durante l'eliminazione: {ex.Message}", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleziona un tool da eliminare.", "Attenzione", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Cancel(object parameter)
        {
            var activeWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
            if (activeWindow != null)
            {
                activeWindow.DialogResult = false;
            }
        }

        /*
        private void CloseWindow(bool dialogResult)
        {
            var activeWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
            if (activeWindow != null)
            {
                activeWindow.DialogResult = dialogResult;
            }
        }
        */

       

    }
}
