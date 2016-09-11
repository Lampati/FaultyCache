using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FaultyCache.Entities;

namespace FaultyCache.Services.Interfases
{
    public interface IEventService
    {
        List<Event> GetEvents(ref int recordFiltered, int start, int length, string search);

        int GetCountEvents();

        
    }
}
