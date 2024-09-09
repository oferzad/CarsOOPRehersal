using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    class Car
    {
        //define member variables
        private string make; //יצרן
        private string model; //דגם
        private int year; //שנת ייצור
        private string owner; //בעלים
        private int licensePlate; //מספר רישוי
        #region שלב א2
        private static int lastLicensePlate = 100000; //מספר רישוי אחרון
        #region שלב ב
        private CarEvent[] events; //מערך של אירועים
        private const int MAX_EVENTS = 100; //מספר אירועים מקסימלי
        private int numEvents; //מספר אירועים
        #endregion

        //this is a constructor
        public Car(string make, string model, int year, string owner)
        {
            this.make = make;
            this.model = model;
            this.year = year;
            this.owner = owner;
            this.licensePlate = lastLicensePlate++;

            #region שלב ב
            this.events = new CarEvent[MAX_EVENTS];
            this.numEvents = 0;
            #endregion
        }

        //this is a copy constructor
        public Car(Car c)
        {
            this.make = c.make;
            this.model = c.model;
            this.year = c.year;
            this.owner = c.owner;
            this.licensePlate = lastLicensePlate++;
            #region שלב ב
            this.events = new CarEvent[MAX_EVENTS];
            this.numEvents = c.numEvents;
            for (int i = 0; i < this.numEvents; i++)
            {
                this.events[i] = new CarEvent(c.events[i]);
            }
            #endregion
        }

        //the following methods are get methods for every member variable
        public string GetMake()
        {
            return this.make;
        }

        public string GetModel()
        {
            return this.model;
        }
        public string GetOwner() 
        {
            return this.owner;
        }
        public int GetYear() 
        {
            return this.year;
        }
        public int GetLicensePlate() 
        {
            return this.licensePlate;
        }

        //the following methods are Set methods for every member variable
        public void SetYear(int year) 
        {
            this.year = year;
        }
        public void SetModel(string model)
        {
            this.model = model;
        }
        public void SetMake(string make)
        {
            this.make = make;
        }
        public void SetOwner(string owner) 
        {
            this.owner = owner;
        }
        #region שלב ב
        //This method returns a copy of the events array in order to prevent the user from changing the events array (and break Encapsulation)
        public CarEvent[] GetEvents() 
        {
            CarEvent[] copy = new CarEvent[this.numEvents];
            for (int i = 0; i < this.numEvents; i++)
            {
                copy[i] = new CarEvent(this.events[i]);
            }
            return copy;
        }

        //this method add an event to the array of events (if threre is enough space)
        public void AddEvent(CarEvent e)
        {
            if (this.numEvents < MAX_EVENTS)
            {
                this.events[this.numEvents++] = new CarEvent(e);
            }
        }
        
        //this is a static method that gets an array of Cars and returns the oldest event out of all Cars event arrays
        public static CarEvent GetOldestEvent(Car[] cars)
        {
            CarEvent oldest = null; //In case there are no events in all of the arrays
            for (int i = 0; i < cars.Length; i++)
            {
                Car c = cars[i];
                for (int j = 0; j < c.numEvents; j++)
                {
                    CarEvent e = c.events[j];
                    if (oldest == null || e.IsBefore(oldest))
                    {
                        oldest = e;
                    }
                }
            }
            return oldest;
        }
        #endregion
        #endregion
    }
}
