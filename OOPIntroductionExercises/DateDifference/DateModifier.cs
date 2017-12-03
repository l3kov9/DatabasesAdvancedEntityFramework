using System;

namespace DateDifference
{
    public class DateModifier
    {
        private DateTime firstDate;
        private DateTime secondDate;

        public DateModifier(DateTime firstDate, DateTime secondDate)
        {
            this.firstDate = firstDate;
            this.secondDate = secondDate;
        }

        public int DifferenceInDays()
        {
            return Math.Abs((int)((this.firstDate - this.secondDate)).TotalDays);
        }
    }
}
