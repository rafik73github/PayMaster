using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayMaster.Models
{
    class DateFilterModel
    {

        public int DateFilterId { get; set; }
        public string DateFilterDescription { get; set; }
        public string DateFilterFirstDate { get; set; }
        public string DateFilterLastDate { get; set; }


        public DateFilterModel(string dateFilterDescription, string dateFilterFirstDate, string dateFilterLastDate)
        {
            this.DateFilterDescription = dateFilterDescription;
            this.DateFilterFirstDate = dateFilterFirstDate;
            this.DateFilterLastDate = dateFilterLastDate;
        }

        public DateFilterModel(int dateFilterId, string dateFilterDescription, string dateFilterFirstDate, string dateFilterLastDate)
        {
            this.DateFilterId = dateFilterId;
            this.DateFilterDescription = dateFilterDescription;
            this.DateFilterFirstDate = dateFilterFirstDate;
            this.DateFilterLastDate = dateFilterLastDate;
        }

    }
}
