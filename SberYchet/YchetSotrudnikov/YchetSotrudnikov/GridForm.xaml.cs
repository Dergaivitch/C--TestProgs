<<<<<<< HEAD
﻿using System;
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
using MySql.Data.MySqlClient;
using System.Data;

namespace YchetSotrudnikov
{
    public partial class GridForm : MainWindow
    {
        // UserOfBase a;
        string login;
        string password;
        string IsBoss;
        String IsAdmin;
        UserForm OnlyOneUserView;
        private static MySqlDataAdapter adapter;
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();

        public GridForm(string login, string password, String isAdmin, String isBoss, string gridQuerry)
        {
            InitializeComponent();
            // a = new UserOfBase(login, password, isAdmin, isBoss);
            this.login = login;
            this.password = password;
            this.IsAdmin = isAdmin;
            this.IsBoss = isBoss;
            
            conn = new MySqlConnection(string.Format("Database=sberychet;Data Source=localhost;User Id=root;Password=Password", password));
            dataGrid1.BeginInit();
            if (gridQuerry == null)
            {
                if (login.Equals("Director"))
                    ds.Tables.Add(CreateTable("Select Name,BossName,Position,IsAdmin,IsBoss from workers"));
                else
                    ds.Tables.Add(CreateTable(string.Format("Select Name,BossName,Position,IsAdmin,IsBoss from workers where BossName ='{0}'", login)));
            }
            else ds.Tables.Add(CreateTable(gridQuerry));
            

                if (!isAdmin.Equals("1"))
                dataGrid1.IsReadOnly = true;
            else dataGrid1.IsReadOnly = false;
            dataGrid1.DataContext = ds.Tables[0];
            dataGrid1.Items.Refresh();
            dataGrid1.EndInit();
        }
        //submit button click，update DB
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = dataGrid1.DataContext as DataTable;
            MySqlCommandBuilder com = new MySqlCommandBuilder(adapter);
            adapter.Update(dt);
        }


        public DataTable CreateTable(string query)
        {
            adapter = new MySqlDataAdapter(query, conn);
            adapter.Fill(dt);
            return dt;

        }

     /*   
        public Boolean isUser()
        {

            return false;
        }
        public Boolean isBoss()
        {
            return false;
        }
        public Boolean isAdmin()
        {
            return false;
        }
        */

        public void GetCellValurOnEvent()
        {
            DataRowView dataRow = (DataRowView)dataGrid1.SelectedItem;

            int index = dataGrid1.CurrentCell.Column.DisplayIndex;

            string cellValue = dataRow.Row.ItemArray[index].ToString();
            MessageBox.Show(cellValue);

        }
        
       

        private void dataGrid1_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            ds.Reset();
            ds.Tables.Add(CreateTable("Select Name,BossName,Position,IsAdmin,IsBoss from workers"));
            dataGrid1.DataContext = ds.Tables[0];


            DataRowView dataRow = (DataRowView)dataGrid1.SelectedItem;
            try
            {
                int index = dataGrid1.CurrentCell.Column.DisplayIndex;
                string RowIsBossValue = dataRow.Row.ItemArray[4].ToString();


                if (RowIsBossValue.Equals("1"))
                {
                    ds.Reset();
                    ds.Tables.Add(CreateTable(string.Format("Select * from workers where BossName='{0}'", dataRow.Row.ItemArray[0].ToString())));
                    dataGrid1.DataContext = ds.Tables[0];

                }
                else
                {
                    if (!(OnlyOneUserView == null) && (OnlyOneUserView.IsEnabled)) //disposed
                        OnlyOneUserView.Close();
                    OnlyOneUserView = new UserForm(login, password, IsAdmin, IsBoss, dataRow.Row.ItemArray[0].ToString());
                    OnlyOneUserView.Show();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("за пределами таблицы");
            }

        }
    }

}
=======
﻿using System;
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
using MySql.Data.MySqlClient;
using System.Data;

namespace YchetSotrudnikov
{
    public partial class GridForm : Window
    {
        // UserOfBase a;
        string login;
        string password;
        string IsBoss;
        String IsAdmin;
        GridForm NextLvlGridForm;
        UserForm OnlyOneUserView;
        private MySqlConnection conn;
        private static MySqlDataAdapter adapter;
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();

        public GridForm(string login, string password, String isAdmin, String isBoss, string gridQuerry)
        {
            InitializeComponent();
            // a = new UserOfBase(login, password, isAdmin, isBoss);
            this.login = login;
            this.password = password;
            this.IsAdmin = isAdmin;
            this.IsBoss = isBoss;
            
            conn = new MySqlConnection(string.Format("Database=sberychet;Data Source=localhost;User Id=root;Password=Password", password));
            dataGrid1.BeginInit();
            if (gridQuerry == null)
            {
                if (login.Equals("Director"))
                    ds.Tables.Add(CreateTable("Select Name,BossName,Position,IsAdmin,IsBoss from workers"));
                else
                    ds.Tables.Add(CreateTable(string.Format("Select Name,BossName,Position,IsAdmin,IsBoss from workers where BossName ='{0}'", login)));
            }
            else ds.Tables.Add(CreateTable(gridQuerry));
            

                if (!isAdmin.Equals("1"))
                dataGrid1.IsReadOnly = true;
            else dataGrid1.IsReadOnly = false;
            dataGrid1.DataContext = ds.Tables[0];
            dataGrid1.Items.Refresh();
            dataGrid1.EndInit();
        }
        //submit button click，update DB
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = dataGrid1.DataContext as DataTable;
            MySqlCommandBuilder com = new MySqlCommandBuilder(adapter);
            adapter.Update(dt);
        }


        public DataTable CreateTable(string query)
        {
            adapter = new MySqlDataAdapter(query, conn);
            adapter.Fill(dt);
            return dt;

        }

     /*   
        public Boolean isUser()
        {

            return false;
        }
        public Boolean isBoss()
        {
            return false;
        }
        public Boolean isAdmin()
        {
            return false;
        }
        */

        public void GetCellValurOnEvent()
        {
            DataRowView dataRow = (DataRowView)dataGrid1.SelectedItem;

            int index = dataGrid1.CurrentCell.Column.DisplayIndex;

            string cellValue = dataRow.Row.ItemArray[index].ToString();
            MessageBox.Show(cellValue);

        }
        
        private void data1_MouseDoubleClick(object sender, MouseButtonEventArgs e)//нельзя сделать по двойному клику, так как открывается 
                                                                                  //редактирование ячейки и нельзя вызвать новую форму в это время
                                                                                  // так что выделить яейку и нажать правой кнопкой(эвент по поднятию)
        {
            DataRowView dataRow = (DataRowView)dataGrid1.SelectedItem;
            try
            {
                int index = dataGrid1.CurrentCell.Column.DisplayIndex;
                string RowIsBossValue = dataRow.Row.ItemArray[4].ToString();


                if (RowIsBossValue.Equals("1"))
                {
                    MessageBox.Show(dataRow.Row.ItemArray[0].ToString());
                    new GridForm(login, password, IsAdmin, IsBoss, string.Format("Select * from workers where BossName='{0}'", dataRow.Row.ItemArray[0].ToString())).Show();
                }
                else
                {
                    if (!(OnlyOneUserView == null) && (OnlyOneUserView.IsEnabled)) //disposed
                        OnlyOneUserView.Close();
                    OnlyOneUserView = new UserForm(login, password, IsAdmin, IsBoss, dataRow.Row.ItemArray[0].ToString());
                    OnlyOneUserView.Show();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("за пределами таблицы");
            }
            
        }
    }

}
>>>>>>> origin/master
