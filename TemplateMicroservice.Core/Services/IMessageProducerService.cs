using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMicroservice.Core.Services
{
    public interface IMessageProducerService
    {
        public Task PublishAsync<T>(T message, string topic_or_queue_name);
        public Task PublishRangeAsync<T>(IReadOnlyCollection<T> message, string topic_or_queue_name);
    }
}
