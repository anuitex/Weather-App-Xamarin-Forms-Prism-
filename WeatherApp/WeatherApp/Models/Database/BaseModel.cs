using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Models.Database
{
    public class BaseModel<TIdentifire>
    {
        [PrimaryKey]
        public TIdentifire Id { get; set; }
    }
}
