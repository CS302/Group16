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
using System.Data.OleDb;
using WorkersLibrary;

namespace WorkersEditor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Workers.accdb");
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

            OleDbCommand select = new OleDbCommand("SELECT * FROM drivers", con);
            con.Open();
            OleDbDataReader reader = select.ExecuteReader();
            while(reader.Read())
            {
                Workers.Add(new Driver(reader["DrName"].ToString(), Convert.ToInt32(reader["Age"]), Convert.ToInt32(reader["SNN"]), reader["CarType"].ToString(), Convert.ToInt32(reader["Hours"])));
            }

            select = new OleDbCommand("SELECT * FROM managers", con);
            reader = select.ExecuteReader();
            while (reader.Read())
            {
                Workers.Add(new Manager(reader["ManName"].ToString(), Convert.ToInt32(reader["Age"]), Convert.ToInt32(reader["SNN"]), Convert.ToInt32(reader["ProjCount"])));
            }
            con.Close();
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

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            Worker delWorker = workersList.SelectedItem as Worker;
            if (delWorker != null)
            {
                
                OleDbCommand delete = new OleDbCommand("DELETE FROM drivers WHERE SNN = @snn", con);
                delete.Parameters.AddWithValue("@snn", delWorker.Snn);

                con.Open();
                delete.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Удалили \n" + delWorker.Name);
                Workers.Remove(delWorker);
                workersList.SelectedIndex = 0;
            }
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxProjCount.Text == string.Empty)
            {
                Driver dr = new Driver(TextBoxName.Text, Convert.ToInt32(TextBoxAge.Text), Convert.ToInt32(TextBoxSNN.Text), TextBoxCarType.Text, Convert.ToInt32(TextBoxHours.Text));
                OleDbCommand insert = new OleDbCommand("INSERT INTO drivers (`SNN`, `DrName`, `Age`, `CarType`, `Hours`) VALUES (@snn, @drName, @age, @carType, @hours)", con);
                insert.Parameters.AddWithValue("@snn", dr.Snn);
                insert.Parameters.AddWithValue("@drName", dr.Name);
                insert.Parameters.AddWithValue("@age", dr.Age);
                insert.Parameters.AddWithValue("@carType", dr.CarType);
                insert.Parameters.AddWithValue("@hours", dr.Hours);

                con.Open();
                insert.ExecuteNonQuery();
                con.Close();
                Workers.Add(dr);
                MessageBox.Show("Добавили \n" + dr.Name);
                ClearTextBoxes();
            }
            else
            {
                // вставить код для добавления менеджера
            }
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxProjCount.Text == string.Empty)
            {
                Driver dr = new Driver(TextBoxName.Text, Convert.ToInt32(TextBoxAge.Text), Convert.ToInt32(TextBoxSNN.Text), TextBoxCarType.Text, Convert.ToInt32(TextBoxHours.Text));
                WorkersDataSetTableAdapters.driversTableAdapter drivers = new WorkersDataSetTableAdapters.driversTableAdapter();
                con.Open();
                drivers.UpdateBySNNQuery(dr.Snn, dr.Name, dr.Age, dr.CarType, dr.Hours, dr.Snn);
                con.Close();
                MessageBox.Show("Добавили \n" + dr.Name);
                ClearTextBoxes();
            }
            else
            {
                // вставить код для добавления менеджера
            }
        }

        private void ClearTextBoxes()
        {
            TextBoxAge.Text = string.Empty;
            TextBoxCarType.Text = string.Empty;
            TextBoxName.Text = string.Empty;
            TextBoxProjCount.Text = string.Empty;
            TextBoxSNN.Text = string.Empty;
            TextBoxHours.Text = string.Empty;
        }
    }
}
