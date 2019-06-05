using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace WeatherApp.iOS.Helpers
{
   public class DatabaseAccessHelper
    {
        public static void PrepareDatabase()
        {
            string documentsDirectoryPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsDirectoryPath, Constants.DatabaseName);
            CopyDatabaseIfNotExists(path);
        }

        private static void CopyDatabaseIfNotExists(string dbPath)
        {
            if (!File.Exists(dbPath))
            {
                var existingDb = NSBundle.MainBundle.PathForResource("city", "db");
                File.Copy(existingDb, dbPath);
            }
        }
    }
}