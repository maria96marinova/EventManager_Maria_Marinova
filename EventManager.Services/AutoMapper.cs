using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using EventManager.Data.Data;
using EventManager.Services.Models;

namespace EventManager.Services
{
    public class AutoMapper:Profile
    {
        public AutoMapper():base()
        {
            this.CreateMap<Event, EventServiceBasicModel>();
            this.CreateMap<Event, EventServiceUserModel>();
        }
    }
}
