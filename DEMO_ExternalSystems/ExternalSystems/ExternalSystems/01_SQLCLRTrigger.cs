using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;
using MindFlavor.RESP;

public partial class Triggers
{
    [Microsoft.SqlServer.Server.SqlTrigger(Name = "AddressTypeCLRTrigger", Target = "dbo.AddressType", Event = "FOR UPDATE, INSERT")]
    public static void mySQLCLRTrigger ()
    {
        string strJson = null;

        using (SqlConnection conn = new SqlConnection("context connection=true"))
        {

            string sqlQuery = @"
                                SELECT 
	                                   i.[AddressTypeID]
                                      ,i.[Name]
                                      ,i.[rowguid]
                                      ,i.[ModifiedDate]
	                                  ,d.[AddressTypeID] as [OldAddressTypeID] 
                                      ,d.[Name] as [OldName]
                                      ,d.[rowguid] as [OldRowguid]
                                      ,d.[ModifiedDate] as [OldModifiedDate]
                                FROM INSERTED i 
	                                LEFT JOIN DELETED d ON i.[AddressTypeID]=d.[AddressTypeID]
                                FOR JSON PATH";

            SqlCommand cmdSqlGetData = new SqlCommand(sqlQuery, conn);

            conn.Open();

            using (SqlDataReader drTriggerData = cmdSqlGetData.ExecuteReader())
            {

                if (drTriggerData.Read())
                {
                    strJson = (string)drTriggerData[0];
                }
            }
        }



        using (RedisConnection rc = GetRedisConnection("127.0.0.1", 6379))
        {
            rc.Publish("foo", strJson);
        }


    }

    private static RedisConnection GetRedisConnection(string address, int port)
    {
        RedisConnection redisConnection = null;

        System.Net.IPAddress ip;
        if (!System.Net.IPAddress.TryParse(address, out ip))
        {
            ip = System.Net.Dns.GetHostEntry(address).AddressList[0];
        }

        System.Net.IPEndPoint ie = new System.Net.IPEndPoint(ip, port);

        redisConnection = new RedisConnection(ie);
        redisConnection.Open();

        return redisConnection;
    }

}

