using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager.Services.Models
{
    public class EventServiceBasicModel
    {
        public string Name { get; set; }

        public string Location { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }
    }
}
