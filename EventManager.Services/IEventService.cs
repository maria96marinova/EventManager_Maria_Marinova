using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EventManager.Services.Models;

namespace EventManager.Services
{
    public interface IEventService
    {
        Task<IEnumerable<EventServiceBasicModel>> All();
        Task<bool> Create(string name,string location, DateTime start, DateTime end, string userId);
        Task<IEnumerable<EventServiceUserModel>> EventsByUser(string userId);
        Task<bool> Edit(long id,string name, string location, DateTime start, DateTime end,string userId);
        Task<EventServiceUserModel> FindById(long id);
        Task<bool> Remove(long id,string userId);
    }
}
