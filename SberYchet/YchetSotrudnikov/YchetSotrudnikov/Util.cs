<<<<<<< HEAD
﻿using MySql.Data.MySqlClient;
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
using System.Windows.Shapes;

namespace YchetSotrudnikov
{
    /// <summary>
    /// Interaction logic for UtilWindow.xaml
    /// </summary>
    
        public class UserOfBase
        {
        string isAdmin;
        string login;
        string password;
        String isBoss;
        public UserOfBase(string login, string password, String isAdmin, String isBoss)
            {
                this.isAdmin = isAdmin;
                this.isBoss = isBoss;
                this.login = login;
                this.password = password;
            }
        

        }
        
    }

=======
﻿using MySql.Data.MySqlClient;
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
using System.Windows.Shapes;

namespace YchetSotrudnikov
{
    /// <summary>
    /// Interaction logic for UtilWindow.xaml
    /// </summary>
    
        public class UserOfBase
        {
        string isAdmin;
        string login;
        string password;
        String isBoss;
        public UserOfBase(string login, string password, String isAdmin, String isBoss)
            {
                this.isAdmin = isAdmin;
                this.isBoss = isBoss;
                this.login = login;
                this.password = password;
            }
        

        }
        
    }

>>>>>>> origin/master
