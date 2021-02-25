
namespace PayMaster.TimeTools
{
    class DefinedDateFilterModel
    {

        public int DateIndex { get; set; }
        public string DateText { get; set; }
        public string StartDateValue { get; set; }
        public string EndDateValue { get; set; }
        public DefinedDateFilterModel(int dateIndex, string dateText, string startDateValue, string endDateValue)
        {
            this.DateIndex = dateIndex;
            this.DateText = dateText;
            this.StartDateValue = startDateValue;
            this.EndDateValue = endDateValue;
        }

    }
}
