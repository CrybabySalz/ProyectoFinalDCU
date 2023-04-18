using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogInRegister
{
    internal class conectionDB
    {
        public SqlConnection conection = new SqlConnection("server=JOHNDYSTANY22\\MSSQLSERVER01 ; database=DB_Multicapas ; integrated security = true");
        public SqlCommand comando;
        public void Open() { conection.Open(); }

        public void Close() { conection.Close();}
    }
}
