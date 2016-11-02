using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;


public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void EnterMonitorAndSleep()
    {
        object o = new object();

        lock (o)
        {
            System.Threading.Thread.Sleep(30000);
        }
    }
};
