<<<<<<< HEAD
﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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

namespace YchetSotrudnikov
{
    
    public partial class UserForm : Window
    {
        MySqlConnection conn;
        MySqlDataAdapter adapter;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        public UserForm(string login, string password, String isAdmin, String isBoss, string Name)
        {
            InitializeComponent();
            conn = new MySqlConnection(string.Format("Database=sberychet;Data Source=localhost;User Id=root;Password={0}", password));
            ds.Tables.Add(CreateTable(string.Format("Select Name,BossName,Position,IsAdmin,IsBoss from workers where Name='{0}'",Name)));
            textBlock.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            textBlock1.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            textBlock2.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
            
            if (ds.Tables[0].Rows[0].ItemArray[3].ToString().Equals("1"))
                checkBox.IsChecked = true; 
            if (ds.Tables[0].Rows[0].ItemArray[4].ToString().Equals("1"))
                checkBox1.IsChecked = true;

        }
        
        public DataTable CreateTable(string query)
        {
            adapter = new MySqlDataAdapter(query, conn);
            adapter.Fill(dt);
            return dt;

        }


    }
}
=======
﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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

namespace YchetSotrudnikov
{
    
    public partial class UserForm : Window
    {
        MySqlConnection conn;
        MySqlDataAdapter adapter;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        public UserForm(string login, string password, String isAdmin, String isBoss, string Name)
        {
            InitializeComponent();
            conn = new MySqlConnection(string.Format("Database=sberychet;Data Source=localhost;User Id=root;Password={0}", password));
            ds.Tables.Add(CreateTable(string.Format("Select Name,BossName,Position,IsAdmin,IsBoss from workers where Name='{0}'",Name)));
            textBlock.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            textBlock1.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            textBlock2.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
            
            if (ds.Tables[0].Rows[0].ItemArray[3].ToString().Equals("1"))
                checkBox.IsChecked = true; 
            if (ds.Tables[0].Rows[0].ItemArray[4].ToString().Equals("1"))
                checkBox1.IsChecked = true;

        }
        
        public DataTable CreateTable(string query)
        {
            adapter = new MySqlDataAdapter(query, conn);
            adapter.Fill(dt);
            return dt;

        }


    }
}
>>>>>>> origin/master
