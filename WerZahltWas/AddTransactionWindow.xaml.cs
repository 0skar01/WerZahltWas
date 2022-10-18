using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Configuration;
using System.Windows.Controls.Primitives;
using WerZahltWas.Classen;
using WerBezahltWas;

namespace WerZahltWas
{
    /// <summary>
    /// Interaction logic for AddTransactionWindow.xaml
    /// </summary>
    public partial class AddTransactionWindow : Window
    {
        SqlConnection con;

        public AddTransactionWindow()
        {
            con = DB.DbCon();
            InitializeComponent();          
            ShowUsers();
        }
        private void ShowUsers()
        {
            string query = "select * from Person";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            using (adapter)
            {
                DataTable usersTable = new DataTable();
                adapter.Fill(usersTable);
                bezahlterComboBox.ItemsSource = "";
                bezahlterComboBox.DisplayMemberPath = "Name";
                bezahlterComboBox.SelectedValuePath = "Id";
                bezahlterComboBox.ItemsSource = usersTable.DefaultView;
            }
        }
        private void ShowAnteil()
        {
            if (gleichRadioButton.IsChecked != true && anteilBetragTextBox0 != null && anteilBetragTextBox1 != null && anteilBetragTextBox2 != null && anteilBetragTextBox3 != null && anteilBetragTextBox4 != null && anteilBetragTextBox5 != null && anteilBetragTextBox6 != null && anteilBetragTextBox7 != null && anteilBetragTextBox8 != null)
            {
                anteilBetragTextBox0.Visibility = Visibility.Visible;
                anteilBetragTextBox1.Visibility = Visibility.Visible;
                if (beguenstigter2.Visibility == Visibility.Visible) anteilBetragTextBox2.Visibility = Visibility.Visible;
                if (beguenstigter3.Visibility == Visibility.Visible) anteilBetragTextBox3.Visibility = Visibility.Visible;
                if (beguenstigter4.Visibility == Visibility.Visible) anteilBetragTextBox4.Visibility = Visibility.Visible;
                if (beguenstigter5.Visibility == Visibility.Visible) anteilBetragTextBox5.Visibility = Visibility.Visible;
                if (beguenstigter6.Visibility == Visibility.Visible) anteilBetragTextBox6.Visibility = Visibility.Visible;
                if (beguenstigter7.Visibility == Visibility.Visible) anteilBetragTextBox7.Visibility = Visibility.Visible;
                if (beguenstigter8.Visibility == Visibility.Visible) anteilBetragTextBox8.Visibility = Visibility.Visible;
                anteilBetragLabel.Visibility = Visibility.Visible;
            }
            
        }
        private void SchowAnteilBetrag(object sender, RoutedEventArgs e)
        {
            ShowAnteil();
        }
        private void HideAnteilBetrag(object sender, RoutedEventArgs e)
        {
            if (anteilBetragTextBox0 != null && anteilBetragLabel != null && anteilBetragTextBox1 != null && anteilBetragTextBox2 != null && anteilBetragTextBox3 != null && anteilBetragTextBox4 != null && anteilBetragTextBox5 != null && anteilBetragTextBox6 != null && anteilBetragTextBox7 != null && anteilBetragTextBox8 != null)
            {
                anteilBetragTextBox0.Visibility = Visibility.Hidden;
                anteilBetragTextBox1.Visibility = Visibility.Hidden;
                anteilBetragTextBox2.Visibility = Visibility.Hidden;
                anteilBetragTextBox3.Visibility = Visibility.Hidden;
                anteilBetragTextBox4.Visibility = Visibility.Hidden;
                anteilBetragTextBox5.Visibility = Visibility.Hidden;
                anteilBetragTextBox6.Visibility = Visibility.Hidden;
                anteilBetragTextBox7.Visibility = Visibility.Hidden;
                anteilBetragTextBox8.Visibility = Visibility.Hidden;
                anteilBetragLabel.Visibility = Visibility.Hidden;
            }
        }
        private void FillBeguenstigter(List<int> list, ComboBox comboBox)
        {
            string query = (list.Count == 1) ? $"select * from Person where Id != {list[0]}" :
                (list.Count == 2) ? $"select * from Person where Id != {list[0]} And Id != {list[1]}" :
                (list.Count == 3) ? $"select * from Person where Id != {list[0]} And Id != {list[1]} And Id != {list[2]}" :
                (list.Count == 4) ? $"select * from Person where Id != {list[0]} And Id != {list[1]} And Id != {list[2]} And Id != {list[3]}" :
                (list.Count == 5) ? $"select * from Person where Id != {list[0]} And Id != {list[1]} And Id != {list[2]} And Id != {list[3]} And Id != {list[4]}" :
                (list.Count == 6) ? $"select * from Person where Id != {list[0]} And Id != {list[1]} And Id != {list[2]} And Id != {list[3]} And Id != {list[4]} And Id != {list[5]}" :
                (list.Count == 7) ? $"select * from Person where Id != {list[0]} And Id != {list[1]} And Id != {list[2]} And Id != {list[3]} And Id != {list[4]} And Id != {list[5]} And Id != {list[6]}" :
                (list.Count == 8) ? $"select * from Person where Id != {list[0]} And Id != {list[1]} And Id != {list[2]} And Id != {list[3]} And Id != {list[4]} And Id != {list[5]} And Id != {list[6]}  And Id != {list[7]}" :
                (list.Count == 9) ? $"select * from Person where Id != {list[0]} And Id != {list[1]} And Id != {list[2]} And Id != {list[3]} And Id != {list[4]} And Id != {list[5]} And Id != {list[6]}  And Id != {list[7]} And Id != {list[8]}" : "";

            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            using (adapter)
            {
                DataTable usersTable = new DataTable();
                adapter.Fill(usersTable);
                comboBox.ItemsSource = "";
                comboBox.DisplayMemberPath = "Name";
                comboBox.SelectedValuePath = "Id";
                comboBox.ItemsSource = usersTable.DefaultView;
            }
        }
        private void ShowBeguenstigter(object sender, SelectionChangedEventArgs e)
        {
            List<int> list = new List<int>();
            if ((ComboBox)sender == bezahlterComboBox)
            {
                list.Add((int)bezahlterComboBox.SelectedValue);
                beguenstigter2.ItemsSource = ""; beguenstigter3.ItemsSource = ""; beguenstigter4.ItemsSource = ""; beguenstigter5.ItemsSource = ""; beguenstigter6.ItemsSource = ""; beguenstigter7.ItemsSource = ""; beguenstigter8.ItemsSource = "";
                FillBeguenstigter(list, beguenstigter1);
            }
            if ((ComboBox)sender == beguenstigter1 && beguenstigter1.SelectedValue != null)
            {
                list.Add((int)beguenstigter1.SelectedValue);
                list.Add((int)bezahlterComboBox.SelectedValue);
                beguenstigter3.ItemsSource = ""; beguenstigter4.ItemsSource = ""; beguenstigter5.ItemsSource = ""; beguenstigter6.ItemsSource = ""; beguenstigter7.ItemsSource = ""; beguenstigter8.ItemsSource = "";
                FillBeguenstigter(list, beguenstigter2);
            }
            if ((ComboBox)sender == beguenstigter2 && beguenstigter2.SelectedValue != null)
            {
                list.Add((int)bezahlterComboBox.SelectedValue);
                list.Add((int)beguenstigter1.SelectedValue);
                list.Add((int)beguenstigter2.SelectedValue);
                beguenstigter4.ItemsSource = ""; beguenstigter5.ItemsSource = ""; beguenstigter6.ItemsSource = ""; beguenstigter7.ItemsSource = ""; beguenstigter8.ItemsSource = "";
                FillBeguenstigter(list, beguenstigter3);
            }
            if ((ComboBox)sender == beguenstigter3 && beguenstigter3.SelectedValue != null) 
            {
                list.Add((int)bezahlterComboBox.SelectedValue);
                list.Add((int)beguenstigter1.SelectedValue);
                list.Add((int)beguenstigter2.SelectedValue);
                list.Add((int)beguenstigter3.SelectedValue);
                beguenstigter5.ItemsSource = ""; beguenstigter6.ItemsSource = ""; beguenstigter7.ItemsSource = ""; beguenstigter8.ItemsSource = "";
                FillBeguenstigter(list, beguenstigter4);
            }
            if ((ComboBox)sender == beguenstigter4 && beguenstigter4.SelectedValue != null)
            {
                list.Add((int)bezahlterComboBox.SelectedValue);
                list.Add((int)beguenstigter1.SelectedValue);
                list.Add((int)beguenstigter2.SelectedValue);
                list.Add((int)beguenstigter3.SelectedValue);
                list.Add((int)beguenstigter4.SelectedValue);
                beguenstigter6.ItemsSource = ""; beguenstigter7.ItemsSource = ""; beguenstigter8.ItemsSource = "";
                FillBeguenstigter(list, beguenstigter5);
            }
            if ((ComboBox)sender == beguenstigter5 && beguenstigter5.SelectedValue != null)
            {
                list.Add((int)bezahlterComboBox.SelectedValue);
                list.Add((int)beguenstigter1.SelectedValue);
                list.Add((int)beguenstigter2.SelectedValue);
                list.Add((int)beguenstigter3.SelectedValue);
                list.Add((int)beguenstigter4.SelectedValue);
                list.Add((int)beguenstigter5.SelectedValue);
                beguenstigter7.ItemsSource = ""; beguenstigter8.ItemsSource = "";
                FillBeguenstigter(list, beguenstigter6);
            }
            if ((ComboBox)sender == beguenstigter6 && beguenstigter6.SelectedValue != null)
            {
                list.Add((int)bezahlterComboBox.SelectedValue);
                list.Add((int)beguenstigter1.SelectedValue);
                list.Add((int)beguenstigter2.SelectedValue);
                list.Add((int)beguenstigter3.SelectedValue);
                list.Add((int)beguenstigter4.SelectedValue);
                list.Add((int)beguenstigter5.SelectedValue);
                list.Add((int)beguenstigter6.SelectedValue);
                beguenstigter8.ItemsSource = "";
                FillBeguenstigter(list, beguenstigter7);
            }
            if ((ComboBox)sender == beguenstigter7 && beguenstigter7.SelectedValue != null)
            {
                list.Add((int)bezahlterComboBox.SelectedValue);
                list.Add((int)beguenstigter1.SelectedValue);
                list.Add((int)beguenstigter2.SelectedValue);
                list.Add((int)beguenstigter3.SelectedValue);
                list.Add((int)beguenstigter4.SelectedValue);
                list.Add((int)beguenstigter5.SelectedValue);
                list.Add((int)beguenstigter6.SelectedValue);
                list.Add((int)beguenstigter7.SelectedValue);
                FillBeguenstigter(list, beguenstigter8);
            }

            
            
        }
        private void addBeguenstigterButton1_Click(object sender, RoutedEventArgs e)
        {
            if ((Button)sender == addBeguenstigterButton1)
            {
                beguenstigter2.Visibility = Visibility.Visible;
                beguenstigterLabel2.Visibility = Visibility.Visible;
                addBeguenstigterButton2.Visibility = Visibility.Visible;
            }
            else if ((Button)sender == addBeguenstigterButton2)
            {
                beguenstigter3.Visibility = Visibility.Visible;
                beguenstigterLabel3.Visibility = Visibility.Visible;
                addBeguenstigterButton3.Visibility = Visibility.Visible;
            }
            if ((Button)sender == addBeguenstigterButton3)
            {
                beguenstigter4.Visibility = Visibility.Visible;
                beguenstigterLabel4.Visibility = Visibility.Visible;
                addBeguenstigterButton4.Visibility = Visibility.Visible;
            }
            if ((Button)sender == addBeguenstigterButton4)
            {
                beguenstigter5.Visibility = Visibility.Visible;
                beguenstigterLabel5.Visibility = Visibility.Visible;
                addBeguenstigterButton5.Visibility = Visibility.Visible;
            }
            if ((Button)sender == addBeguenstigterButton5)
            {
                beguenstigter6.Visibility = Visibility.Visible;
                beguenstigterLabel6.Visibility = Visibility.Visible;
                addBeguenstigterButton6.Visibility = Visibility.Visible;
            }
            if ((Button)sender == addBeguenstigterButton6)
            {
                beguenstigter7.Visibility = Visibility.Visible;
                beguenstigterLabel7.Visibility = Visibility.Visible;
                addBeguenstigterButton7.Visibility = Visibility.Visible;
            }
            if ((Button)sender == addBeguenstigterButton7)
            {
                beguenstigter8.Visibility = Visibility.Visible;
                beguenstigterLabel8.Visibility = Visibility.Visible;
                addBeguenstigterButton8.Visibility = Visibility.Visible;
            }

            ShowAnteil();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<int> check = EingabenCheck();
            if (check[0] == 1)
            {
                if (check[10] == 0)
                {
                    AddGleichTransaction(check);
                }
                else if(check[10] == 1)
                {
                    float anteile = 0;
                    for(int i = 1; i < check[1] + 2; i++)
                    {
                        anteile += anteileList[i];
                    }
                    int plus1 = (int)anteileList[0] + 1; int minus1 = (int)anteileList[0] - 1;
                    if ((int)anteileList[0] == (int)anteile || plus1 == (int)anteile || minus1 == (int)anteile)
                    {
                        AddAnteilTransaction(check);
                    }
                    else
                    {
                        check[0] = 0;
                    }
                }
            }
            MessageBox.Show((check[0] == 0) ? "please check your entries" : "the entries are correct and will be registered");
            if(check[0] == 1)
            {
                this.Close();
            }
            else
            {
                anteileList.Clear();
            }
        }
        private void AddAnteilTransaction(List<int> check)
        {
            SqlCommand cmd = new SqlCommand("Add_Transaction_With_Anteile", con);
            using (cmd)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("bezahlte", bezahlterComboBox.SelectedValue);
                string beguenstigteList = "";
                for (int i = 2; i < check[1] + 2; i++)
                {
                    beguenstigteList += (i == (check[1] + 1)) ? $"{check[i]}" : $"{check[i]};";
                }
                cmd.Parameters.AddWithValue("@beguenstigteList", beguenstigteList);
                
                cmd.Parameters.AddWithValue("@betrag", anteileList[0]);
                string betraegeList = "";
                for(int i = 2; i < check[1] + 2; i++)
                {
                    betraegeList += (i == (check[1] + 1)) ? $"{anteileList[i]}" : $"{anteileList[i]};";
                }
                betraegeList = betraegeList.Replace(',', '.');
                cmd.Parameters.AddWithValue("@betragAnteile", betraegeList);
                cmd.Parameters.AddWithValue("@bezeichnung", bezeichnungTextBox.Text);
                cmd.Parameters.AddWithValue("@anzahlBeguenstigte", check[1]);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        private void AddGleichTransaction(List<int> check)
        {
            SqlCommand cmd = new SqlCommand("Add_Transaction", con);
            using (cmd)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@bezahlte", bezahlterComboBox.SelectedValue);
                string beguenstigteList = "";
                for (int i = 2; i < check[1]+2; i++)
                {
                    beguenstigteList += (i == (check[1]+1))? $"{check[i]}" : $"{check[i]};";
                }            
                cmd.Parameters.AddWithValue("@beguenstigteList", beguenstigteList);
                cmd.Parameters.AddWithValue("@betrag", anteileList[0]);
                cmd.Parameters.AddWithValue("@bezeichnung", bezeichnungTextBox.Text);
                cmd.Parameters.AddWithValue("@anzahlBeguenstigte", check[1]);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        // anteileList [gesamtB, bezahler Anteil, 1st beg Anteil, .....] count 10, default value -90
        List<float> anteileList = new List<float>();
        private List<int> EingabenCheck()
        {
            // check [1 gueltig, beguenstigteZahl, 1st begueId, ...., 1 Verschiedene Anteile] Count 11, default value 0
            List<int> check = new List<int>();
            for(int i = 0; i < 11; i++)
            {
                check.Add(0);
            }
            float gesamt = -90, beza = -90, gu1 = -90, gu2 = -90, gu3 = -90, gu4 = -90, gu5 = -90, gu6 = -90, gu7 = -90, gu8 = -90;
            if (gleichRadioButton.IsChecked != true)
            {
                check[10] = 1;
                if(bezahlterComboBox.SelectedValue != null && beguenstigter1.SelectedValue != null && float.TryParse(gesamtBetragTextBox.Text, out gesamt) && float.TryParse(anteilBetragTextBox0.Text, out beza) && float.TryParse(anteilBetragTextBox1.Text, out gu1))
                {
                    check[2] = ((int)beguenstigter1.SelectedValue);
                    if (beguenstigter2.Visibility == Visibility.Visible && beguenstigter2.SelectedValue != null)
                    {
                        if(float.TryParse(anteilBetragTextBox2.Text, out gu2))
                        {
                            check[3] = ((int)beguenstigter2.SelectedValue);
                            if (beguenstigter3.Visibility == Visibility.Visible && beguenstigter3.SelectedValue != null)
                            {
                                if (float.TryParse(anteilBetragTextBox3.Text, out gu3))
                                {
                                    check[4] = ((int)beguenstigter3.SelectedValue);
                                    if (beguenstigter4.Visibility == Visibility.Visible && beguenstigter4.SelectedValue != null)
                                    {
                                        if (float.TryParse(anteilBetragTextBox4.Text, out gu4))
                                        {
                                            check[5] = ((int)beguenstigter4.SelectedValue);
                                            if (beguenstigter5.Visibility == Visibility.Visible && beguenstigter5.SelectedValue != null)
                                            {
                                                if (float.TryParse(anteilBetragTextBox5.Text, out gu5))
                                                {
                                                    check[6] = ((int)beguenstigter5.SelectedValue);
                                                    if (beguenstigter6.Visibility == Visibility.Visible && beguenstigter6.SelectedValue != null)
                                                    {
                                                        if (float.TryParse(anteilBetragTextBox6.Text, out gu6))
                                                        {
                                                            check[7] = ((int)beguenstigter6.SelectedValue);
                                                            if (beguenstigter7.Visibility == Visibility.Visible && beguenstigter7.SelectedValue != null)
                                                            {
                                                                if (float.TryParse(anteilBetragTextBox7.Text, out gu7))
                                                                {
                                                                    check[8] = ((int)beguenstigter7.SelectedValue);
                                                                    if (beguenstigter8.Visibility == Visibility.Visible && beguenstigter8.SelectedValue != null)
                                                                    {
                                                                        if (float.TryParse(anteilBetragTextBox8.Text, out gu8))
                                                                        {
                                                                            check[9] = ((int)beguenstigter8.SelectedValue);
                                                                            check[0] = 1;
                                                                            check[1] = 8;
                                                                        }                                                                      
                                                                    }
                                                                    else
                                                                    {
                                                                        check[0] = 1;
                                                                        check[1] = 7;
                                                                    }
                                                                }  
                                                            }
                                                            else
                                                            {
                                                                check[0] = 1;
                                                                check[1] = 6;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        check[0] = 1;
                                                        check[1] = 5;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                check[0] = 1;
                                                check[1] = 4;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        check[0] = 1;
                                        check[1] = 3;
                                    }
                                }
                            }
                            else
                            {
                                check[0] = 1;
                                check[1] = 2;
                            }
                        }
                    }
                    else
                    {
                        check[0] = 1;
                        check[1] = 1;
                    }
                }
                anteileList.Add(gesamt);
                anteileList.Add(beza);
                anteileList.Add(gu1);
                anteileList.Add(gu2);
                anteileList.Add(gu3);
                anteileList.Add(gu4);
                anteileList.Add(gu5);
                anteileList.Add(gu6);
                anteileList.Add(gu7);
                anteileList.Add(gu8);
                switch (check[1])
                {
                    case 1:
                        if (anteileList[0] < 0 || anteileList[1] < 0 || anteileList[2] < 0)
                        {
                            check[0] = 0;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case 2:
                        if (anteileList[0] < 0 || anteileList[1] < 0 || anteileList[2] < 0 || anteileList[3] < 0)
                        {
                            check[0] = 0;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case 3:
                        if (anteileList[0] < 0 || anteileList[1] < 0 || anteileList[2] < 0 || anteileList[3] < 0 || anteileList[4] < 0)
                        {
                            check[0] = 0;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case 4:
                        if (anteileList[0] < 0 || anteileList[1] < 0 || anteileList[2] < 0 || anteileList[3] < 0 || anteileList[4] < 0 || anteileList[5] < 0)
                        {
                            check[0] = 0;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case 5:
                        if (anteileList[0] < 0 || anteileList[1] < 0 || anteileList[2] < 0 || anteileList[3] < 0 || anteileList[4] < 0 || anteileList[5] < 0 || anteileList[6] < 0)
                        {
                            check[0] = 0;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case 6:
                        if (anteileList[0] < 0 || anteileList[1] < 0 || anteileList[2] < 0 || anteileList[3] < 0 || anteileList[4] < 0 || anteileList[5] < 0 || anteileList[6] < 0 || anteileList[7] < 0)
                        {
                            check[0] = 0;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case 7:
                        if (anteileList[0] < 0 || anteileList[1] < 0 || anteileList[2] < 0 || anteileList[3] < 0 || anteileList[4] < 0 || anteileList[5] < 0 || anteileList[6] < 0 || anteileList[7] < 0 || anteileList[8] < 0)
                        {
                            check[0] = 0;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case 8:
                        if (anteileList[0] < 0 || anteileList[1] < 0 || anteileList[2] < 0 || anteileList[3] < 0 || anteileList[4] < 0 || anteileList[5] < 0 || anteileList[6] < 0 || anteileList[7] < 0 || anteileList[8] < 0 || anteileList[9] < 0)
                        {
                            check[0] = 0;
                            break;
                        }
                        else
                        {
                            break;
                        }
                }
            }
            else
            {
                if (bezahlterComboBox.SelectedValue != null && beguenstigter1.SelectedValue != null && float.TryParse(gesamtBetragTextBox.Text, out gesamt) && gesamt > 0)
                {
                    check[2] = ((int)beguenstigter1.SelectedValue);
                    if(beguenstigter2.Visibility == Visibility.Visible && beguenstigter2.SelectedValue != null)
                    {
                        check[3] = ((int)beguenstigter2.SelectedValue);
                        if (beguenstigter3.Visibility == Visibility.Visible && beguenstigter3.SelectedValue != null)
                        {
                            check[4] = ((int)beguenstigter3.SelectedValue);
                            if (beguenstigter4.Visibility == Visibility.Visible && beguenstigter4.SelectedValue != null)
                            {
                                check[5] = ((int)beguenstigter4.SelectedValue);
                                if (beguenstigter5.Visibility == Visibility.Visible && beguenstigter5.SelectedValue != null)
                                {
                                    check[6] = ((int)beguenstigter5.SelectedValue);
                                    if (beguenstigter6.Visibility == Visibility.Visible && beguenstigter6.SelectedValue != null)
                                    {
                                        check[7] = ((int)beguenstigter6.SelectedValue);
                                        if (beguenstigter7.Visibility == Visibility.Visible && beguenstigter7.SelectedValue != null)
                                        {
                                            check[8] = ((int)beguenstigter7.SelectedValue);
                                            if (beguenstigter8.Visibility == Visibility.Visible && beguenstigter8.SelectedValue != null)
                                            {
                                                check[9] = ((int)beguenstigter8.SelectedValue);
                                                check[0] = 1;
                                                check[1] = 8;
                                            }
                                            else
                                            {
                                                check[0] = 1;
                                                check[1] = 7;
                                            }
                                        }
                                        else
                                        {
                                            check[0] = 1;
                                            check[1] = 6;
                                        }
                                    }
                                    else
                                    {
                                        check[0] = 1;
                                        check[1] = 5;
                                    }
                                }
                                else
                                {
                                    check[0] = 1;
                                    check[1] = 4;
                                }
                            }
                            else
                            {
                                check[0] = 1;
                                check[1] = 3;
                            }
                        }
                        else
                        {
                            check[0] = 1;
                            check[1] = 2;
                        }
                    }
                    else
                    {
                        check[0] = 1;
                        check[1] = 1;
                    }
                }
                anteileList.Add(gesamt);
            }
            return check;
        }
        private void OpenMainWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Hide();
            mainWindow.ShowDialog();
        }
    }
}
