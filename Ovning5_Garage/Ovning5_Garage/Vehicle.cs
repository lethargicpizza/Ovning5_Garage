using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5_Garage
{
    class Vehicle
    {
        public Vehicle(string color, string owner, double weight, double width, double height, double length, int maxspeed, string manufacturer, string regno, bool parked=true)
        {
            this.Color = color;
            this.Owner = owner;
            this.Weight = weight;
            this.Width = width;
            this.Height = height;
            this.Length = length;
            this.MaxSpeed = maxspeed;
            this.Manufacturer = manufacturer;
            this.RegNo = regno;
            this.Parked = parked;
        }

        public string Color { get; }
        public double Weight { get;  }
        public double Width { get;  }
        public double Height { get;  }
        public double Length { get;  }
        public int MaxSpeed { get;  }
        public string Manufacturer { get; }
        public string RegNo { get; }
        public bool Parked { get; set; }
        public string Owner { get; set; }
    }
}
