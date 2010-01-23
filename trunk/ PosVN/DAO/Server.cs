using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO
{
    public class Server
    {
        private string server_name;
        private string database_name;
        public string Mode="AUT";
        public string UserName;
        public string Password;
        public  string Server_name
        {
            get
            {
                return server_name;

            }
            set
            {
                server_name = value;
            }
        }
        public  string Database_name
        {
            get
            {
                return database_name;
            }
            set
            {
                database_name = value;
            }
        }
    }
}
