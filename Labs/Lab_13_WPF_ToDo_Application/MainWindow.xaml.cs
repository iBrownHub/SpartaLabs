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

namespace Lab_13_WPF_ToDo_Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> items = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            Initialise();
        }

        private void Initialise()
        {
            items.Add("Task01");
            items.Add("Task02");
            items.Add("Task03");
            items.Add("Task04");
            items.Add("Task05");
            ListBoxTasks.ItemsSource = items;
        }

        private void ListBoxTasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
