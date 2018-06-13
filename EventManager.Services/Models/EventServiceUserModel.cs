using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager.Services.Models
{
    public class EventServiceUserModel:EventServiceBasicModel
    {
        public long Id { get; set; }

        public string UserId { get; set; }
    }
}
