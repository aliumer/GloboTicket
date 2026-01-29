using Globoticket.Integration.Messages;

namespace Globoticket.Integration.MessagingBus
{
    public interface IMessageBus
    {
        Task PublishMessage(IntegrationBaseMessage message, string topicName);

    }
}
