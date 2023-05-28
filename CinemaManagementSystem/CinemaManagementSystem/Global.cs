using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem
{
    class Global
    {
        private static int role = 0;
        public static string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""C:\Users\adm\3D Objects\RailwaySystem\moviemanagementsystem.mdb""";
        public static int Role
        {
            get { return role; }
            set { role = value; }
        }

    }
}
