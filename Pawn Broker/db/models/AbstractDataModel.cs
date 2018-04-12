using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pawn_Broker.db.models
{
   public abstract class AbstractDataModel
    {
        public int _id;

        public abstract void SetFields(SQLiteDataReader reader);
    }
}
