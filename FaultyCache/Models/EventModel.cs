using FaultyCache.Entities;
using FaultyCache.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaultyCache.Models
{
    public class EventModel : IDataTableable
    {
        public string Title { get; set; }

        public string Link { get; set; }

        public string Technology { get; set; }

        public DateTime StartDate { get; set; }

        public string[] ToDataTableStringArray()
        {
            return new string[] { Title, StartDate.ToString("yyyy/MM/dd"), Link, Technology };
        }
        public EventModel(Event ev)
        {
            Title = ev.Title;
            Link = ev.Link;
            Technology = ev.Technology;
            StartDate = ev.StartDate;
        }

        public EventModel()
        {

        }
    }
}