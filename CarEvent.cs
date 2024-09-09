using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    class CarEvent
    {
        private string eventType;
        private int eventDay, eventMonth, eventYear;
        private string eventDescription;
        //this is a constructur
        public CarEvent(string eventType, int eventDay, int eventMonth, int eventYear, string eventDescription)
        {
            this.eventType = eventType;
            this.eventDay = eventDay;
            this.eventMonth = eventMonth;
            this.eventYear = eventYear;
            this.eventDescription = eventDescription;
        }
        //this is a copy constructor
        public CarEvent(CarEvent carEvent)
        {
            this.eventType=carEvent.eventType;
            this.eventDay=carEvent.eventDay;
            this.eventMonth=carEvent.eventMonth;
            this.eventYear=carEvent.eventYear;
            this.eventDescription=carEvent.eventDescription;
        }
        //the following methods are get methods for every member variable
        public string GetEventType()
        {
            return this.eventType;
        }
        public int GetEventDay()
        {
            return this.eventDay;
        }
        public int GetEventMonth()
        {
            return this.eventMonth;
        }
        public int GetEventYear()
        {
            return this.eventYear;
        }
        public string GetEventDescription()
        {
            return this.eventDescription;
        }

        //the following methods are Set methods for every member variable
        public void SetEventType(string eventType)
        {
            this.eventType = eventType;
        }
        public void SetEventDay(int eventDay)
        {
            this.eventDay = eventDay;
        }
        public void SetEventMonth(int eventMonth)
        {
            this.eventMonth = eventMonth;
        }

        public void SetEventYear(int eventYear)
        {
            this.eventYear = eventYear;
        }

        public void SetEventDescription(string description)
        {
            this.eventDescription = description;
        }

        //This method gets a car event and return true if the current object date is before the given car event parameter
        public bool IsBefore(CarEvent carEvent)
        {
            int[] days = { 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334, 365 };
            long currentDays = this.eventDay + days[this.eventMonth-1] + this.eventYear * 365;
            long otherDays = carEvent.eventDay + days[carEvent.eventMonth-1] + carEvent.eventYear * 356;
            return (currentDays < otherDays);
        }
    }
}
