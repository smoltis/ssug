using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Collections.Generic;

public partial class StoredProcedures
{
    private static Dictionary<long,long> _KVP = new Dictionary<long,long>();

    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void LargeAllocation()
    {
        DateTime start = DateTime.Now;
        Random rnd = new Random();
        long k = 0;
        for (int j = 0; j < 320 * 2; j++)
        {
            //yield about every 1/16 of a second
            if (j > 0)
                System.Threading.Thread.Sleep(0);

            for (long i = 0; i < 13125000 * 2; i++)
            {
                if (!_KVP.ContainsKey(k))
                {
                    _KVP.Add(k, i);
                    k++;
                }
            }
        }
    }
}
