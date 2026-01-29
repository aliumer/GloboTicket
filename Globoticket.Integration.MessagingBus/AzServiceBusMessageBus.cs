using Globoticket.Integration.Messages;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using Newtonsoft.Json;
using System.Text;

namespace Globoticket.Integration.MessagingBus
{
    public class AzServiceBusMessageBus : IMessageBus
    {
        private string ConnectionString = "Endpoint=sb://globoticket.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=Hi0hqUzgNIhGOcceT/gW4B23fHSlbVM+FPAxjq3zZTc=";
        public async Task PublishMessage(IntegrationBaseMessage message, string topicName)
        {
            ISenderClient topicClient = new TopicClient(ConnectionString, topicName);
            var messageBody = JsonConvert.SerializeObject(message);
            var serviceBusMessage = new Message(Encoding.UTF8.GetBytes(messageBody))
            {
                CorrelationId = Guid.NewGuid().ToString(),
            };

            await topicClient.SendAsync(serviceBusMessage);
            Console.WriteLine($"Sent message to topic: {topicClient.Path}");
            await topicClient.CloseAsync();
        }
    }
}
