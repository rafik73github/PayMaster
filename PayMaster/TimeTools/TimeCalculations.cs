using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayMaster.TimeTools
{
    class TimeCalculations
    {
              

        public string FirstDayOfMonth(int monthAgo)
        {
            var today = DateTime.Today;
            var month = new DateTime(today.Year, today.Month, 1);
            var first = month.AddMonths(monthAgo * -1).ToString("yyyy-MM-dd");
                        
            return first;
        }

        public string LastDayOfLastOfMonth()
        {
            var today = DateTime.Today;
            var month = new DateTime(today.Year, today.Month, 1);
            var last = month.AddDays(-1).ToString("yyyy-MM-dd");

            return last;
        }

        public string FirstDayOfCurrentYear()
        {
            var today = DateTime.Today;
            var currentYearStart = new DateTime(today.Year,1, 1).ToString("yyyy-MM-dd");
            

            return currentYearStart;
        }

    }
}
