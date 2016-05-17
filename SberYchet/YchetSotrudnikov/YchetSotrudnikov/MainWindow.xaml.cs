<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows;
using System.Data;
using MySql.Data.MySqlClient;

namespace YchetSotrudnikov
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public abstract partial class MainWindow : Window
    {
        private MySqlConnection conn;
        private GridForm gf;
        private UserForm uf;
        class User
        {
            string IsBoss;
            string IsAdmin;
            string Name;
            string BossName;
            string Position;
            User (string Name, string BossName, string Position, string IsAdmin, string IsBoss)
            {
                this.Name = Name;
                this.BossName = BossName;
                this.Position = Position;
                this.IsAdmin = IsAdmin;
                this.IsBoss = IsBoss;
            }
        }
        
        public MainWindow()
        {
            AuthWindow AuWind = new AuthWindow();
            AuWind.Show();
        }


    }
}



=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows;
using System.Data;
using MySql.Data.MySqlClient;

namespace YchetSotrudnikov
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static MySqlConnection conn;
        private static MySqlDataAdapter adapter;
        private static DataSet ds = new DataSet();
        private static DataTable dt = new DataTable();
        private string login;
        private string password;
        private string IsAdmin;
        private string ISBoss;
        private static GridForm gf;
        private static UserForm uf;
        public MainWindow()
        {
            InitializeComponent();
        }

        public DataTable CreateTable(string query)
        {
            adapter = new MySqlDataAdapter(query, conn);
            adapter.Fill(dt);
            return dt;

        }

        private void GreetMeButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (!string.IsNullOrWhiteSpace(Login.Text) && !string.IsNullOrWhiteSpace(Password.Text))
                {
                    try
                    {
                        conn = new MySqlConnection(string.Format("Database=sberychet;Data Source=localhost;User Id=root;Password={0}", Password.Text));
                        //чтобы не создавать базу пользователей логин под именем пароль Password
                        ds.Tables.Add(CreateTable(string.Format("Select Name,BossName,Position,IsAdmin,IsBoss from workers where Name='{0}'", Login.Text)));
                        // UserOfBase user = new UserOfBase(ds.Tables[0].Rows[0].ItemArray[0].ToString(), Password.Text, ds.Tables[0].Rows[0].ItemArray[3].ToString(), ds.Tables[0].Rows[0].ItemArray[4].ToString(), conn);
                        this.login = Login.Text;
                        this.password = Password.Text;
                        this.IsAdmin = ds.Tables[0].Rows[0].ItemArray[3].ToString();
                        this.ISBoss = ds.Tables[0].Rows[0].ItemArray[4].ToString();

                        this.Hide();
                        if (IsAdmin.Equals("1"))
                        {
                            gf = new GridForm("Director", Password.Text, ds.Tables[0].Rows[0].ItemArray[3].ToString(), ds.Tables[0].Rows[0].ItemArray[4].ToString(), null);
                            gf.Show();
                            return;
                        }
                        if (ISBoss.Equals("1"))
                        {

                            gf = new GridForm(ds.Tables[0].Rows[0].ItemArray[0].ToString(), Password.Text, ds.Tables[0].Rows[0].ItemArray[3].ToString(), ds.Tables[0].Rows[0].ItemArray[4].ToString(), null);
                            gf.Show();
                            return;

                        }
                        else
                        {
                            uf = new UserForm(ds.Tables[0].Rows[0].ItemArray[0].ToString(), Password.Text, ds.Tables[0].Rows[0].ItemArray[3].ToString(), ds.Tables[0].Rows[0].ItemArray[4].ToString(), Login.Text);
                            uf.Show();
                            return;
                        }



                    }
                    catch (MySql.Data.MySqlClient.MySqlException)
                    {
                        MessageBox.Show("incorrect login/pass");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("enter login/pass");
                }
            }
        }
    }
}


>>>>>>> origin/master
