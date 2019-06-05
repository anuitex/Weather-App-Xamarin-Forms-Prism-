using Acr.UserDialogs;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WeatherApp.Helpers
{
     public static class DatabaseConnectionHelper
    {
        public  static SQLiteConnection GetDatebaseConnection()
        {
            string documentsDirectoryPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsDirectoryPath, Constants.DatabaseName);
 
            if (!File.Exists(path))
            {
                 UserDialogs.Instance.PromptAsync(new PromptConfig
                {
                    InputType = InputType.Name,
                    OkText = "OK",
                    Title = "File not found!",
                }); 
            }

            var conn = new SQLiteConnection(path); 
            return conn;
        }
    }
}
