using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pawn_Broker.db.helpers;
using Pawn_Broker.db.models;

namespace Pawn_Broker.db.dataManagers
{
    public class AbstractDataManager
    {
        protected static readonly string SPACE = " ";
        protected static readonly string SQL_KEYWORD_AND = " AND ";
        protected static readonly string SQL_KEYWORD_OR = " OR ";
        protected static readonly string SQL_KEYWORD_WHERE = " WHERE ";
        protected static readonly string SQL_KEYWORD_IN = " IN ";
        protected static readonly string INSERT = "INSERT OR IGNORE INTO ";
        protected static readonly string UPDATE = "UPDATE ";
        protected readonly SQLiteConnection sqLiteConnection;

        public AbstractDataManager()
        {
            sqLiteConnection = PawnBrokerHelper.GetInstance().GetConnection();
        }
        public List<T> Select<T>(string table, Dictionary<string, object> whereClause) where T : AbstractDataModel, new()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("*");

            builder.Append(" FROM ").Append(table);
            List<string> whereValues = null;
            if (whereClause != null && whereClause.Count > 0)
            {
                builder.Append(SQL_KEYWORD_WHERE);
                bool first = true;
                whereValues = new List<string>(whereClause.Count);
                foreach (KeyValuePair<string, object> entry in whereClause)
                {
                    if (!first)
                    {
                        builder.Append(SQL_KEYWORD_AND);
                    }
                    else
                    {
                        first = false;
                    }

                    builder.Append(entry.Key).Append(" = ");
                    builder.Append("?");
                    whereValues.Add(entry.Value.ToString());
                }
            }
            List<T> tList = new List<T>();
            if (sqLiteConnection.State != ConnectionState.Open)
            {
                sqLiteConnection.Open();
            }

            using (SQLiteTransaction mytransaction = sqLiteConnection.BeginTransaction())
            {
                using (SQLiteCommand command = sqLiteConnection.CreateCommand())
                {
                    command.Transaction = mytransaction;
                    command.CommandText = builder.ToString();
                    if (whereValues != null)
                    {
                        int i = 1;
                        foreach (string value in whereValues)
                        {
                            command.Parameters.Add(new SQLiteParameter("param" + i, value));
                            i++;
                        }
                    }
                    SQLiteDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        T t = new T();
                        t.SetFields(reader);
                        tList.Add(t);
                    }
                }
                mytransaction.Commit();
            }
            sqLiteConnection.Close();
            return tList;
        }
    }
}
