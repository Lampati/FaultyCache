using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FaultyCache.Entities;
using FaultyCache.Services.Interfases;

namespace FaultyCache.Services
{
    public class RandomizerEventService : IEventService
    {
        const  int MAX_EVENTS = 100000;

        private List<Entities.Event> _list = CreateRandomEventData();

        private static List<Event> CreateRandomEventData()
        {
            Random rnd = new Random();
            List<Event> list = new List<Event>();
            for (int i = 1; i <= MAX_EVENTS; i++)
            {
                Event item = new Event();
                item.Title = "Title_" + i.ToString().PadLeft(6, '0');
                DateTime dob =
                item.StartDate = new DateTime(1900 + rnd.Next(1, 100), rnd.Next(1, 13), rnd.Next(1, 28)); ;
                item.Technology = "Technology_" + i.ToString().PadLeft(6, '0');
                item.Link = "Link_" + i.ToString().PadLeft(6, '0');
                list.Add(item);
            }
            return list;
        }

        public List<Entities.Event> GetEvents(ref int recordFiltered, int start, int length, string search)
        {
            List<Event> returnList = new List<Event>();
            if (search == null)
            {
                returnList = _list;
            }
            else
            {
                returnList = _list.FindAll(x => x.Title.ToUpper().Contains(search.ToUpper())
                       || x.Technology.ToUpper().Contains(search.ToUpper())
                       || x.Link.ToUpper().Contains(search.ToUpper()));                
            }

            recordFiltered = returnList.Count;
            
            //flanzani 08/09/2016
            // Only get one page of data. Math.Min for short lists
            returnList = returnList.GetRange(start, Math.Min(length, returnList.Count - start));

            return returnList;
        }

        
        public int GetCountEvents()
        {
            return MAX_EVENTS;
        }

    }
}
