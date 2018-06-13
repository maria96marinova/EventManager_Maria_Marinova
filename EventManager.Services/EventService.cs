using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EventManager.Services.Models;
using EventManager.Data;
using AutoMapper.QueryableExtensions;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using EventManager.Data.Data;

namespace EventManager.Services
{
    public class EventService : IEventService
    {
        private readonly ApplicationDbContext db;

        public EventService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<EventServiceBasicModel>> All()
         => await this.db.Events.ProjectTo<EventServiceBasicModel>()
                                .OrderBy(e=>e.Start)
                                .ThenBy(e=>e.Name)
                                .ToListAsync();

        public async Task<bool> Create(string name, string location, DateTime start, DateTime end, string userId)
        {
            if (!await this.UserIdExists(userId))
            {
                return false;
            }

            var eventItem = new Event
            {
                Name = name,
                Location=location,
                Start = start,
                End = end,
                UserId = userId
            };

            await this.db.Events.AddAsync(eventItem);

            await this.db.SaveChangesAsync();

            return true;


        }

        public async Task<bool> Edit(long id, string name, string location, DateTime start, DateTime end,string userId)
        {
            if (!await this.EventExists(id))
            {
                return false;
            }

            var eventItem = await this.db.Events.Where(e => e.Id == id).FirstOrDefaultAsync();
            if (eventItem.UserId!=userId)
            {
                return false;
            }

            eventItem.Name = name;
            eventItem.Location = location;
            eventItem.Start = start;
            eventItem.End = end;
            await this.db.SaveChangesAsync();
            return true;

        }

        public async Task<IEnumerable<EventServiceUserModel>> EventsByUser(string userId)
         => await this.db.Events.Where(e => e.UserId == userId).ProjectTo<EventServiceUserModel>()
            .ToListAsync();

        private async Task<bool> UserIdExists(string id)
         => await this.db.Users.AnyAsync(u => u.Id == id);

        private async Task<bool> EventExists(long id)
            => await this.db.Events.AnyAsync(e => e.Id == id);

        public async Task<EventServiceUserModel> FindById(long id)
            => await this.db.Events.Where(e => e.Id == id).ProjectTo<EventServiceUserModel>().FirstOrDefaultAsync();

        public async Task<bool> Remove(long id,string userId)
        {
            if (!await this.EventExists(id))
            {
                return false;
            }

            var eventToRemove = await this.db.Events.Where(e => e.Id == id).FirstOrDefaultAsync();

            if (eventToRemove.UserId!=userId)
            {
                return false;
            }

            this.db.Events.Remove(eventToRemove);

            await this.db.SaveChangesAsync();


            return true;

        }
        
    }
}
