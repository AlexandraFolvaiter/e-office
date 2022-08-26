using StackExchange.Redis;

namespace eOffice.Common.Redis
{
    public class QueueMessagesConnection
    {
        private string _pubSubConnectionString;


        public QueueMessagesConnection(string pubSubConnectionString)
        {
            _pubSubConnectionString = pubSubConnectionString;
        }

        public IDatabase GetConnection()
        {
            var connection = ConnectionMultiplexer.Connect(_pubSubConnectionString);

            return connection.GetDatabase();
        }

        public ISubscriber GetSubscriber()
        {
            var connection = ConnectionMultiplexer.Connect(_pubSubConnectionString);

            return connection.GetSubscriber();
        }
    }
}
