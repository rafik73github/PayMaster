using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayMaster.Models
{
    class FilterModel
    {

        public int FilterId { get; set; }
        public string DateFilterDescription { get; set; }
        public string DateFilterFirstDate { get; set; }
        public string DateFilterLastDate { get; set; }


        public FilterModel(string dateFilterDescription, string dateFilterFirstDate, string dateFilterLastDate)
        {
            this.DateFilterDescription = dateFilterDescription;
            this.DateFilterFirstDate = dateFilterFirstDate;
            this.DateFilterLastDate = dateFilterLastDate;
        }

        public FilterModel(int filterId, string dateFilterDescription, string dateFilterFirstDate, string dateFilterLastDate)
        {
            this.FilterId = filterId;
            this.DateFilterDescription = dateFilterDescription;
            this.DateFilterFirstDate = dateFilterFirstDate;
            this.DateFilterLastDate = dateFilterLastDate;
        }

    }
}
