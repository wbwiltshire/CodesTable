/******************************************************************************************************
 *This template was generated on 11/08/2019 04:36:34 using Development Center version 0.9.2. *
******************************************************************************************************/
using System;
using System.Collections.Generic;

namespace CodesTable.Data.POCO
{ 
    public class AppSettingsConfiguration
    {
        public Serilog Serilog { get; set; }
        public Database Database { get; set; }
    }

    //Logging Objects
    public class Serilog
    {
        public string[] UsingStmt { get; set; }
        public string MinimumLevel { get; set; }
        public WriteTo[] WriteTo { get; set; }
    }
    public class WriteTo
    {
        public string[] Options { get; set; }
    }

    //Database Objects
    public class Database
    {
        public string Server { get; set; }
        public string Name { get; set; }
        public string ConnectionString { get; set; }
        public string[] StoredProcedures { get; set; }
    }

}