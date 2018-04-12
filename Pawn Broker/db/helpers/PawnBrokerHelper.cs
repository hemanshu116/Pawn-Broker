using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Pawn_Broker.db.dataManagers;
using Pawn_Broker.Properties;
using Pawn_Broker.Utils;

namespace Pawn_Broker.db.helpers
{
    public class PawnBrokerHelper
    {
        private static PawnBrokerHelper _instance;
        private SQLiteConnection _mDbConnection;

        private PawnBrokerHelper()
        {
        }

        public static PawnBrokerHelper GetInstance()
        {
            return _instance ?? (_instance = new PawnBrokerHelper());
        }

        public SQLiteConnection GetConnection()
        {
            string appPath = FolderUtils.GetAppDataPath();
            string dbFile = $"{appPath}{Settings.Default.AppName}.sqlite";
            return _mDbConnection ??
                   (_mDbConnection = new SQLiteConnection($"Data Source = {dbFile};Version = 3;pooling=true;"));
        }

        public void DatabaseCreate()
        {
            GetConnection();
            _mDbConnection.Open();
            List<string> createTableQueries = new List<string>();
            UserDataManager.CreateTableQueries(createTableQueries);

            using (SQLiteTransaction mytransaction = _mDbConnection.BeginTransaction())
            {
                using (SQLiteCommand command = _mDbConnection.CreateCommand())
                {
                    command.Transaction = mytransaction;
                    foreach (string query in createTableQueries)
                    {
                        command.CommandText = query;
                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($@"Error in {query}");
                            Console.WriteLine($@"Message {ex.Message}");
                        }
                    }
                }
                mytransaction.Commit();
            }
            _mDbConnection.Close();
        }
    }
}