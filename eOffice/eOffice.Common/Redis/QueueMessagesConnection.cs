using StackExchange.Redis;

namespace eOffice.Common.Redis
{
    public class QueueMessagesConnection
    {
        private string _databaseConnectionString;
        private string _pubSubConnectionString;


        public QueueMessagesConnection(string databaseConnectionString, string pubSubConnectionString)
        {
            _databaseConnectionString = databaseConnectionString;
            _pubSubConnectionString = pubSubConnectionString;
        }

        public IDatabase GetConnection()
        {
            var connection = ConnectionMultiplexer.Connect(_databaseConnectionString);

            return connection.GetDatabase();
        }

        public ISubscriber GetSubscriber()
        {
            var connection = ConnectionMultiplexer.Connect(_pubSubConnectionString);

            return connection.GetSubscriber();
        }
    }
}
