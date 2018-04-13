using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pawn_Broker.constants;
using Pawn_Broker.db.models;

namespace Pawn_Broker.db.dataManagers
{
    class UserDataManager : AbstractDataManager
    {
        private const string TABLE = "USER";

        public User AuthenticateUser(string username, string password)
        {
            Dictionary<string, object> whereClause = new Dictionary<string, object>
            {
                { Global.USERNAME, username},
                { Global.PASSWORD,password}
            };
            List<User> users = Select<User>(TABLE, whereClause);
            return users.Count != 1 ? null : users[0];
        }

        private static string CreateTableString()
        {
            string createUser = "CREATE TABLE IF NOT EXISTS " + TABLE + "(_id integer primary key autoincrement," + Global.USERNAME + " text not null, "
                                  + Global.PASSWORD + " text not null) ";

            return createUser;
        }

        private static string UniqueIndex()
        {
            return "CREATE UNIQUE INDEX IF NOT EXISTS " + TABLE + "_index on " + TABLE + " (" + Global.USERNAME + ")";
        }
        private static string DummyUser()
        {
            return "INSERT OR IGNORE INTO " + TABLE + "(" + Global.USERNAME +","+ Global.PASSWORD + ") values ('hemanshu', 'password')";
        }

        public static void CreateTableQueries(List<string> queryList)
        {
            queryList.Add(CreateTableString());
            queryList.Add(UniqueIndex());
            queryList.Add(DummyUser());
        }
    }
}
