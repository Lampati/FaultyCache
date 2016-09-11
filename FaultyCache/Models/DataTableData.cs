using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FaultyCache.Entities;

namespace FaultyCache.Models
{

    //flanzani 2016/09/08
    //WARNING!! Do not capitalize this properties or datatables will break on client side.
    public class DataTableData
    {
        
        public int iTotalRecords { get; set; }
        public int iTotalDisplayRecords { get; set; }
        public List<string[]> aaData { get; set; }
    }


}