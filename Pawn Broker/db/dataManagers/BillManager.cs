using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pawn_Broker.constants;
using Pawn_Broker.db.models;

namespace Pawn_Broker.db.dataManagers
{
    public class BillManager : AbstractDataManager
    {
        private const string TABLE = "BILLS";

        public List<Bills> GetBills()
        {
            //Dictionary<string, object> whereClause = null;
            List<Bills> bills = Select<Bills>(TABLE, null);
            return bills;
        }
        private static string CreateTableString()
        {
            string createBill = "CREATE TABLE IF NOT EXISTS " + TABLE + "(_id integer primary key autoincrement,"
                                + Global.ADDRESS  + " text not null," +
                                Global.BILLNO + " text not null," +
                                Global.DATE + " text not null," +
                                Global.GROSSGM + " integer not null," +
                                Global.GROSSMG + " integer not null," +
                                Global.MOBILENUMBER + " text not null," +
                                Global.NAMEOFPAWNER + " text not null," +
                                Global.PRESENTVALUE + " integer not null," +
                                Global.PRINCIPLE + " integer not null);";

            return createBill;
        }
        private static string UniqueIndex()
        {
            return "CREATE UNIQUE INDEX IF NOT EXISTS " + TABLE + "_index on " + TABLE + " (" + Global.BILLNO + ")";
        }
        public static void CreateTableQueries(List<string> queryList)
        {
            queryList.Add(CreateTableString());
            queryList.Add(UniqueIndex());
        }
    }
}
