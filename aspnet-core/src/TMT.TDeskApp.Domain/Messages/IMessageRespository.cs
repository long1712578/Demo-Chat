using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace TMT.TDeskApp.Messages
{
    public interface IMessageRespository : IRepository<Message, string>
    {
        Task<List<Message>> GetAll();
        Task SaveChangeAsync();
        Task Update(string content,string id);
    }
}
