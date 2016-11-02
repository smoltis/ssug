using KafkaNet;
using KafkaNet.Model;
using KafkaNet.Protocol;
using System;
using Microsoft.SqlServer.Server;
using System.Data.SqlTypes;

public partial class KafkaClientUtils
{
    [Microsoft.SqlServer.Server.SqlProcedure(Name = "SQLCLRDemosendToKafka")]
    public static void SendToKafka([SqlFacet(MaxSize =-1)] SqlString msg, SqlString topic, SqlString uri)
    {

        var options = new KafkaOptions
           (new Uri(uri.Value));

        using (var router = new BrokerRouter(options))
        {

            using (var client = new KafkaNet.Producer(router))
            {
                client.SendMessageAsync(topic.Value, new[]
                   { new Message(msg.Value) }).Wait();
            }
        }
        options = null;
    }
}
