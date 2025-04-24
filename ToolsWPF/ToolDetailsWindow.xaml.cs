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
using System.Windows.Shapes;
using ViewModel;
using Domain;

namespace ToolsWPF
{
    /// <summary>
    /// Logica di interazione per ToolDetailsWindow.xaml
    /// </summary>
    public partial class ToolDetailsWindow : Window
    {
        private ToolDetailsViewModel _viewModel;

        public ToolDetailsWindow(Tools selectedTool)
        {
            InitializeComponent();
            _viewModel = new ToolDetailsViewModel(selectedTool);
            DataContext = _viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

