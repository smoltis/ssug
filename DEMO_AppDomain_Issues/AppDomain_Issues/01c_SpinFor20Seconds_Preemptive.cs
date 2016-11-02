using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;


public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void SpinFor20Seconds_Preemptive()
    {
        //Thread Affinity will cause the thread to be preemptively scheduled
        System.Threading.Thread.BeginThreadAffinity();

        for (long k = 0; k < 2; k++) { 
            for (long i = 0; i < 4200000000; i++)
            {
            }
        }
        System.Threading.Thread.EndThreadAffinity();
    }
};
