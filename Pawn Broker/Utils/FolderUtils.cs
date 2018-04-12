using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pawn_Broker.Properties;

namespace Pawn_Broker.Utils
{
    class FolderUtils
    {
        public static string GetAppDataPath()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                                 Path.DirectorySeparatorChar
                                 + "PawnBroker" + Path.DirectorySeparatorChar;
            DirectoryInfo dInfo = new DirectoryInfo(appDataPath);
            if (!dInfo.Exists) dInfo.Create();
            return appDataPath;
        }
    }
}
