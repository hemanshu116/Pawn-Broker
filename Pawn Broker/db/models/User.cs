using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pawn_Broker.constants;

namespace Pawn_Broker.db.models
{
    public class User : AbstractDataModel
    {
        public string username;
        public string password;
        public override void SetFields(SQLiteDataReader reader)
        {
            
            username = reader[Global.USERNAME] as string;
            password = reader[Global.PASSWORD] as string;
        }

        public override string ToString()
        {
            return "User{" +
                   
                   ", password='" + password + '\'' +
                   ", username='" + username + '\''+"}";

        }
    }
}
