using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanSach
{
    class ConnectToDB
    {
        
        private static String _ConnectionString = @" Data Source=.\SQLEXPRESS;Initial Catalog=QuanLySach;Integrated Security=True";

        public static String ConnectionString
        {
            get { return _ConnectionString; }

        }
    }
}
