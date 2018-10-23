using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.util
{
    class DBConnect
    {
            private string server;
            private string user;
            private string password;
            private string database;

            public DBConnect(string server = "localhost", string user = "root",
                            string password = "", string database = "db")
            {
                this.server = server;
                this.user = user;
                this.password = password;
                this.database = database;
            }

            public string get()
            {
                return "Server=" + this.server + ";Database=" + this.database +
                       ";Uid=" + this.user + ";Pwd=" + this.password + ";SslMode=None";
                /* Output: Server=localhost;Database=footballmanager:Uid=root;Pwd=;SslMode=None */
            }
        }
    }

