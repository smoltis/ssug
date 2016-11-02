Use intrabet
GO

CREATE PROCEDURE [dbo].[SQLCLRDemosendToKafka]
@msg NVARCHAR (max), @topic nvarchar(4000), @uri = nvarchar(4000)
AS EXTERNAL NAME [KafkaProducer].[KafkaClientUtils].[SendToKafka]
GO

EXEC [dbo].[SQLCLRDemosendToKafka] @msg="Hi Hello! Welcome to Kafka!",@topic = 'testtopic',@uri = 'http://localhost:9092'
GO