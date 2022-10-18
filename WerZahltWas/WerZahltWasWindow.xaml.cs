using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using WerBezahltWas;
using WerZahltWas.Classen;

namespace WerZahltWas
{
    /// <summary>
    /// Interaction logic for WerZahltWasWindow.xaml
    /// </summary>
    public partial class WerZahltWasWindow : Window
    {
        SqlConnection con;
        public WerZahltWasWindow()
        {
            con = DB.DbCon();
            InitializeComponent();
            ShowSchulden();
            ShowUsers();
        }
        private void ShowSchulden(string userId = null)
        {
            if(userId == null)
            {
                string query = "Wer_Zaht_Was";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                using (adapter)
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    WerZahltWasListBox.ItemsSource = "";
                    WerZahltWasListBox.DisplayMemberPath = "WerSchuldetWas";
                    WerZahltWasListBox.SelectedValuePath = "Id";
                    WerZahltWasListBox.ItemsSource = table.DefaultView;
                }
            }
            else
            {
                string query = "Wer_Zahlt_Was_User";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.AddWithValue("@userId", userId);
                using (adapter)
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    WerZahltWasListBox.ItemsSource = "";
                    WerZahltWasListBox.DisplayMemberPath = "WerSchuldetWas";
                    WerZahltWasListBox.SelectedValuePath = "Id";
                    WerZahltWasListBox.ItemsSource = table.DefaultView;
                }
            }
        }
        private void ShowUsers()
        {
            string query = "select * from Person";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            using (adapter)
            {
                DataTable usersTable = new DataTable();
                adapter.Fill(usersTable);
                usersListBox.ItemsSource = "";
                usersListBox.DisplayMemberPath = "Name";
                usersListBox.SelectedValuePath = "Id";
                usersListBox.ItemsSource = usersTable.DefaultView;
            }
        }
        private void WerZahltWasUser(object sender, SelectionChangedEventArgs e)
        {
            ShowSchulden(usersListBox.SelectedValue.ToString());
        }
        private void OpenMainWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            //Application.Current.Shutdown();
            MainWindow mainWindow = new MainWindow();
            this.Hide();
            mainWindow.ShowDialog();
        }
    }
}
