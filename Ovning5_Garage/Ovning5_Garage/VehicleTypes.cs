using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5_Garage
{
    #region Enumerations
    enum Fueltypes
    {
        Gasoline,
        Diesel,
        Battery
    }

    enum Boattypes
    {
        Motorboat,
        SailingBoat,
        Ferry
    }

    enum LocomotiveEngineTypes
    {
        Electric=1,
        Diesel =2,
        DieselElectric =3,
        Steam =4,
        Metro =5,
        Tram =6,
        Railbike =7
    }

    enum Flags
    {
        Sweden=1,
        Norway=2,
        Denmark=3,
        Germany=4,
        Poland=5,
        Estonia=6,
        Finland=7
    }
    #endregion

    #region Classes
    class Airplane : Vehicle
    {
        public Airplane(string color, string owner, double weight, double width, double height, double length, int maxspeed, string manufacturer, int numberofengines, int crewsize, int numberofpassengers, string aviation, int maxaltitude, int numberofwheels, string regno, bool parked=true) : base(color, owner, weight, width, height, length, maxspeed, manufacturer, regno, parked)
        {
            this.NumberOfEngines = numberofengines;
            this.CrewSize = crewsize;
            this.NumberOfPassengers = numberofpassengers;
            this.Aviation = aviation;
            this.MaxAltitude = maxaltitude;
            this.NumberOfWheels = numberofwheels;
        }

        public int NumberOfEngines { get; }
        public int CrewSize { get; }
        public int NumberOfPassengers { get; }
        public string Aviation { get; }
        public int MaxAltitude { get;  }
        public int NumberOfWheels { get; }
    }

    class Motorcycle : Vehicle
    {
        public Motorcycle(string color, string owner, double weight, double width, double height, double length, int maxspeed, string manufacturer, string regno, double cylindervolume,  bool parked=true) : base(color, owner, weight, width, height, length, maxspeed, manufacturer, regno, parked)
        {
            this.CylinderVolume = cylindervolume;
        }

        public double CylinderVolume { get;  }
    }

    class Car : Vehicle
    {
        public Car(string color, string owner, double weight, double width, double height, double length, int maxspeed, string manufacturer, string regno, int numberofcylinders, Fueltypes fueltype, int numberofwheels, string model, string year, bool parked=true ) : base(color, owner, weight, width, height, length, maxspeed, manufacturer, regno, parked)
        {
            this.NumberOfCylinders = numberofcylinders;
            this.Fueltype = fueltype;
            this.NumberOfWheels = numberofwheels;
            this.Model = model;
            this.Year = year;
        }

        public string Year { get; set; }
        public int NumberOfWheels { get; }
        public int NumberOfCylinders { get;  }
        public Fueltypes Fueltype { get;  }
        public string Model { get; }
    }

    class Bus : Vehicle
    {
        public Bus(string color, string owner, double weight, double width, double height, double length, int maxspeed, string manufacturer, string regno, int numberofseats, int numberofwheels,  bool parked=true) : base(color, owner, weight, width, height, length, maxspeed, manufacturer, regno, parked)
        {
            this.NumberOfSeats = numberofseats;
            this.NumberOfWheels = numberofwheels;
        }

        public int NumberOfWheels { get; }
        public int NumberOfSeats { get;  }
    }

    class Boat : Vehicle
    {
        public Boat(string color, string owner, double weight, double width, double height, double length, int maxspeed, string manufacturer, int numberofengines, Flags flag, Boattypes boattype, string name, string registrationport, string regno, string imo, bool parked=true) : base(color, owner, weight, width, height, length, maxspeed, manufacturer, regno, parked)
        {
            this.NumberOfEngines = numberofengines;
            this.Flag = flag;
            this.Name = name;
            this.RegistrationPort = registrationport;
            this.IMO = imo;
            this.Boattype = boattype;
        }

        public int NumberOfEngines { get; }
        public Flags Flag { get; set; }
        public Boattypes Boattype { get; set; }
        public string RegistrationPort { get; set; }
        public string Name { get; set; }
        public string IMO { get; }
    }

    class Locomotive : Vehicle
    {
        public Locomotive(string color, string owner, double weight, double width, double height, double length, int maxspeed, string manufacturer, string series, int gauge, LocomotiveEngineTypes enginetype, string name, int numberofwheels, string regno, bool parked=true) : base(color, owner, weight, width, height, length, maxspeed, manufacturer, regno, parked)
        {
            this.Series = series;
            this.Gauge = gauge;
            this.Enginetype = enginetype;
            this.Name = name;
            this.NumberOfWheels = numberofwheels;
        }

        public int NumberOfWheels { get; }
        public string Series { get;  }
        public int Gauge { get; }
        public LocomotiveEngineTypes Enginetype { get;  }
        public string Name { get; set; }
    }
    #endregion
}
