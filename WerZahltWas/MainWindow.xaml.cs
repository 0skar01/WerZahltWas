using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WerZahltWas.Classen;

namespace WerBezahltWas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection con;
        public MainWindow()
        {
            con = DB.DbCon();
            InitializeComponent();
            ShowUsers();
            ShowLastTransactions();
        }
        private void ShowLastTransactions(string userId = null)
        {
            string query = (userId == null) ? "Get_Transactions" : "Get_User_Transactions";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            if(userId != null)
            {
                adapter.SelectCommand.Parameters.AddWithValue("@userId", userId);
            }
            using (adapter)
            {
                DataTable usersTable = new DataTable();
                adapter.Fill(usersTable);
                transactionInfoListBox.ItemsSource = "";
                TransactionsListBox.ItemsSource = "";
                TransactionsListBox.DisplayMemberPath = "Transactions";
                TransactionsListBox.SelectedValuePath = "Id";
                TransactionsListBox.ItemsSource = usersTable.DefaultView;
            }
            //if (userId == null)
            //{
            //    string query = "Get_Transactions";
            //    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            //    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            //    using (adapter)
            //    {
            //        DataTable usersTable = new DataTable();
            //        adapter.Fill(usersTable);
            //        transactionInfoListBox.ItemsSource = "";
            //        TransactionsListBox.ItemsSource = "";
            //        TransactionsListBox.DisplayMemberPath = "Transactions";
            //        TransactionsListBox.SelectedValuePath = "Id";
            //        TransactionsListBox.ItemsSource = usersTable.DefaultView;
            //    }
            //}
            //else
            //{
            //    string query = "Get_User_Transactions";
            //    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            //    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            //    adapter.SelectCommand.Parameters.AddWithValue("@userId", userId);
            //    using (adapter)
            //    {
            //        DataTable usersTable = new DataTable();
            //        adapter.Fill(usersTable);
            //        transactionInfoListBox.ItemsSource = "";
            //        TransactionsListBox.ItemsSource = "";
            //        TransactionsListBox.DisplayMemberPath = "Transactions";
            //        TransactionsListBox.SelectedValuePath = "Id";
            //        TransactionsListBox.ItemsSource = usersTable.DefaultView;
            //    }
            //}
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
        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            if(AddUserTextBox.Text.Trim() != "")
            {
                SqlCommand cmd = new SqlCommand("Add_User", con);
                using (cmd)
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@name", AddUserTextBox.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            AddUserTextBox.Text = "";
            ShowUsers();
        }
        private void SelectUser(object sender, SelectionChangedEventArgs e)
        {   
            if(usersListBox.SelectedValuePath != null && usersListBox.SelectedValue != null)
            {
                ShowLastTransactions(usersListBox.SelectedValue.ToString());           
            }
        }
        private void ShowTransactionButton_Click(object sender, RoutedEventArgs e)
        {
            ShowLastTransactions();
        }
        private void AddTransactionButton_Click(object sender, RoutedEventArgs e)
        {
            WerZahltWas.AddTransactionWindow win = new WerZahltWas.AddTransactionWindow();
            win.Show();
            this.Hide();
        }
        private void ShowTransactionInfo(object sender, SelectionChangedEventArgs e)
        {
            if(TransactionsListBox.SelectedValue != null)
            {
                string query = "GET_Transaction_Info";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.AddWithValue("@transactionId", TransactionsListBox.SelectedValue);
                using (adapter)
                {
                    DataTable TranactionInfoTable = new DataTable();
                    adapter.Fill(TranactionInfoTable);
                    transactionInfoListBox.ItemsSource = "";
                    transactionInfoListBox.DisplayMemberPath = "Schuld";
                    transactionInfoListBox.SelectedValuePath = "Id";
                    transactionInfoListBox.ItemsSource = TranactionInfoTable.DefaultView;
                }
            }
        }
        private void WerZahltWas(object sender, RoutedEventArgs e)
        {
            WerZahltWas.WerZahltWasWindow win = new WerZahltWas.WerZahltWasWindow();
            win.Show();
            this.Hide();
        }
        private void CloseProgram(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
