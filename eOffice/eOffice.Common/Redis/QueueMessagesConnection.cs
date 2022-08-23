using StackExchange.Redis;

namespace eOffice.Common.Redis
{
    public class QueueMessagesConnection
    {

        public IDatabase GetConnection()
        {
            var aa = ConnectionMultiplexer.Connect($"redis-16341.c56.east-us.azure.cloud.redislabs.com:16341,password=qO53loElfTDgZHaeBXIdRSmAeKbbrpro");

            return aa.GetDatabase();
        }

        public ISubscriber GetSubscriber()
        {
            var aa = ConnectionMultiplexer.Connect($"redis-16341.c56.east-us.azure.cloud.redislabs.com:16341,password=qO53loElfTDgZHaeBXIdRSmAeKbbrpro");

            return aa.GetSubscriber();
        }
    }
}
