using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;

namespace WindowsFormsApp5
{
    internal class Sql
    {
        public string ConnectinString { get; set; }

        public string Connect()
        {
            ConnectinString = "Data Source=192.168.101.129,1433;Initial Catalog=IDZ1;User ID=admin;Password=4552;";
            return ConnectinString;
        }
    }
}
