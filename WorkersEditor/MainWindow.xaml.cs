using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WorkersLibrary;

namespace WorkersEditor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Worker> Workers { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Workers = new ObservableCollection<Worker>();
            Workers.Add(new Driver("John", 27, 6435, "BMW", 256));
            Workers.Add(new Manager("Hulk", 25, 465138, 25));
            Workers.Add(new Manager("Helena", 25, 478656, 12));
            Workers.Add(new Driver("Jason", 45, 46513, "BMW", 256));
            Workers.Add(new Manager("Mary", 27, 461577, 15));

            DataContext = this;

        }

        private void workersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Worker worker = (sender as ListBox).SelectedItem as Worker;
            if (worker != null)
            {
                detailsPanel.DataContext = worker;
                if (worker is Driver)
                {
                    man_Panel.Visibility = System.Windows.Visibility.Collapsed;
                    dr_Panel.Visibility = System.Windows.Visibility.Visible;
                }
                if (worker is Manager)
                {
                    man_Panel.Visibility = System.Windows.Visibility.Visible;
                    dr_Panel.Visibility = System.Windows.Visibility.Collapsed;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Worker delWorker = workersList.SelectedItem as Worker;
            if (delWorker != null)
            {
                Workers.Remove(delWorker);
                workersList.SelectedIndex = 0;
            }

        }
    }
}
