using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FaultyCache.Models;
using FaultyCache.Services;
using FaultyCache.Services.Interfases;
using FaultyCache.Entities;

namespace FaultyCache.Controllers
{
    public class HomeController : Controller
    {
        private IEventService eventService = new RandomizerEventService();

        public ActionResult Index()
        {
            return View();
        }        
    

        //flanzani 09/09/2016
        //Tester method for output cache
        [OutputCache(Duration = 60, Location = System.Web.UI.OutputCacheLocation.Any, VaryByParam ="valor")]
        public ActionResult GetTime(string valor)
        {
            Random r = new Random();
            return Json( new { date = DateTime.Now.ToLongTimeString(), random = r.NextDouble()}, JsonRequestBehavior.AllowGet);
        }


        //[OutputCache(Duration = 60, Location = System.Web.UI.OutputCacheLocation.Any, VaryByParam = "iDisplayStart;iDisplayLength;sSearch")]
        [ParameterizedOutputCache(CacheProfile = "CacheEvents")]
        public ActionResult GetEventInformation(string sEcho, int iDisplayStart, int iDisplayLength, string sSearch)
        {
            int recordsFiltered = 0;

            List<EventModel> listEvents = eventService.GetEvents(ref recordsFiltered, iDisplayStart, iDisplayLength, sSearch)
                .Select(x => new EventModel(x))
                .ToList(); ;

            DataTableData data = new DataTableData();            
            data.iTotalRecords = eventService.GetCountEvents();
            data.iTotalDisplayRecords = recordsFiltered;
            data.aaData = listEvents
                .Select(x => x.ToDataTableStringArray())
                .ToList();

            return Json(data, JsonRequestBehavior.AllowGet);
        }
       
    }
}
