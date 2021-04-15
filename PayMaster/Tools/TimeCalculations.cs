using System;

namespace PayMaster.Tools
{
    class TimeCalculations
    {
        public string ReformatDateDMY(string date)
        {
            var dateFormat = DateTime.Parse(date);

            return dateFormat.ToString("dd.MM.yyyy");
        }
          
        public string GetToday()
        {
            var today = DateTime.Today;
            var todayString = today.ToString("yyyy-MM-dd");

            return todayString;
        }

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

        public string LastDayOfCurrentYear()
        {
            var today = DateTime.Today;
            var currentYearEnd = new DateTime(today.Year, 12, 31).ToString("yyyy-MM-dd");


            return currentYearEnd;
        }

    }
}
