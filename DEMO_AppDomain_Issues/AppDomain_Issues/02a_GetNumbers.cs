using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Collections;

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction(
        FillRowMethodName="GetNumbers_Fill",
        TableDefinition="Number INT")]
    public static IEnumerable GetNumbers(
        SqlInt32 Starting, 
        SqlInt32 Ending)
    {
        for (int i = Starting.Value; i <= Ending.Value; i++)
        {
            yield return (i);
        }
    }

    public static void GetNumbers_Fill(object o, out SqlInt32 Number)
    {
        Number = new SqlInt32((int)o);
    }
};

