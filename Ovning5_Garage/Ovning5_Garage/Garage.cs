using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5_Garage
{
    class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private T[] vehicles;
        public int Capacity { get; }
        public int Count { get; private set; }

        public Garage(int capacity)
        {
            this.vehicles = new T[capacity];

            this.Capacity = capacity;
            this.Count = 0;
        }

        public bool Add(T vehicle)
        {
            if (Count >= Capacity) return false;
            if (vehicle == null) return false;

            if (Find(vehicle.RegNo) != null) return false;  // Endast ett registreringsnummer tillåts i garaget

            for (int i = 0; i < Capacity; i++)
            {
                if (vehicles[i] == null)
                {
                    this.vehicles[i] = vehicle;
                    this.Count += 1;
                    return true;
                }
            }

            return false;
        }

        public T Remove(T vehicle)
        {
            for (int i = 0; i < Capacity; i++)
            {
                if (vehicles[i] == null)   // det kan finnas tomma platser, dom får man hoppa över
                    continue;

                if (vehicles[i].Equals(vehicle))
                {
                    this.vehicles[i] = null;
                    this.Count -= 1;
                    return vehicle;
                };
            }
            return null;
        }

        public T Find(string regno)
        {
            if (this.Count < 1)
                return null;

            foreach (var item in vehicles)
            {
                if (item == null)   // det kan finnas tomma platser, dom får man hoppa över
                    continue;

                if (item.RegNo == regno)
                    return item;
            }

            return null;
        }

        public void TogglePark(Vehicle v)
        {
            if (this.Count < 1)
                return;

            //if (v.Parked) v.Parked = false;
            //else v.Parked = true;

            v.Parked = !v.Parked;
        }

        #region LINQ methods
        public IEnumerable<T> ShowParkedVehicles() => vehicles.Where(vehicles => vehicles.Parked);
        public IEnumerable<T> ListColorVehicles(string color) => vehicles.Where(v => v != null && v.Color.ToUpper().Equals(color.ToUpper()));
        //public IEnumerable<T> ListAllVehicles() => vehicles;
        public IEnumerable<T> ListManufacturer(string manufacturer) => vehicles.Where(v => v!= null && v.Manufacturer.ToUpper().Equals(manufacturer.ToUpper()));
        #endregion

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Capacity; i++)
            {
                if (vehicles[i] != null)
                    yield return vehicles[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
