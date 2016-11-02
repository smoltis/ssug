using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void SpinFor20Seconds_NoYield()
    {
        for (long x = 0; x < 2; x++)
        {
            for (long i = 0; i < 4200000000; i++)
            {

            }
        }
    }
};
