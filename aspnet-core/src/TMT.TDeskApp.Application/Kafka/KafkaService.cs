using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EventBus.Distributed;

namespace TMT.TDeskApp.Messages
{
    public class KafkaService :  IKafkaService, ITransientDependency
    {
        private readonly IDistributedEventBus _distributedEventBus;
        public KafkaService(IDistributedEventBus distributedEventBus)
        {
            _distributedEventBus = distributedEventBus;
        }
        public async Task CreateAsync(MessageEto input)
        {
            await _distributedEventBus.PublishAsync(input);
        }
    }
}
