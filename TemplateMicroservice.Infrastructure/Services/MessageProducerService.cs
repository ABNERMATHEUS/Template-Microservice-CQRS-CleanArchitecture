using Azure.Messaging.ServiceBus;
using System.Text.Json;
using TemplateMicroservice.Core.Services;

namespace TemplateMicroservice.Infrastructure.Services
{
    public sealed class MessageProducerService : IMessageProducerService
    {
        private readonly ServiceBusClient _serviceBusClient;

        public MessageProducerService(ServiceBusClient serviceBusClient)
        {
            _serviceBusClient=serviceBusClient;
        }

        public async Task PublishAsync<T>(T message, string topic_or_queue_name)
        {
            var sender = _serviceBusClient.CreateSender(topic_or_queue_name);
            var messageServiceBus = new ServiceBusMessage(JsonSerializer.Serialize(message));
            await sender.SendMessageAsync(messageServiceBus);
        }

        public async Task PublishRangeAsync<T>(IReadOnlyCollection<T> message, string topic_or_queue_name)
        {
            var sender = _serviceBusClient.CreateSender(topic_or_queue_name);
            foreach (var item in message)
            {
                var messageServiceBus = new ServiceBusMessage(JsonSerializer.Serialize(item));
                await sender.SendMessageAsync(messageServiceBus);
            }
        }
    }
}
