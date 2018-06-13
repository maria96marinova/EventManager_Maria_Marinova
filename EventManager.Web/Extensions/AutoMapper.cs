using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using EventManager.Services.Models;
using EventManager.Web.Models;

namespace EventManager.Web.Extensions
{
    public class AutoMapper:Profile
    {
        public AutoMapper():base()
        {
            this.CreateMap<EventServiceUserModel, EventFormModel>();
        }
    }
}
