using System.Data.SQLite;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;

namespace лаба_24
{
    public partial class MainWindow : Window
    {
        private SQLiteConnection connection = null!;
        private SQLiteDataAdapter adapter = null!;
        private DataTable dataTable = null!;

        public MainWindow()
        {
            InitializeComponent();
            InitializeDatabase();
            LoadData();
        }

        private void InitializeDatabase()
        {
            string databasePath = "C:\\Mac\\Home\\Downloads\\database";
            connection = new SQLiteConnection($"Data Source={databasePath};Version=3;");
            connection.Open();
        }

        private void LoadData()
        {
            string selectQuery = "SELECT * FROM Возвраты";
            adapter = new SQLiteDataAdapter(selectQuery, connection);
            dataTable = new DataTable();
            adapter.Fill(dataTable);
            DataGridReturns.ItemsSource = dataTable.DefaultView;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridReturns.SelectedItem != null)
            {
                DataRowView row = (DataRowView)DataGridReturns.SelectedItem;
                int id = Convert.ToInt32(row["КодВозврата"]);
                string deleteQuery = "DELETE FROM Возвраты WHERE КодВозврата = @id";
                SQLiteCommand command = new SQLiteCommand(deleteQuery, connection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
                LoadData();
            }
        }
    }
}