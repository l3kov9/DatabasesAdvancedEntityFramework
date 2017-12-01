using System;

namespace SpeedRacing.Models
{
    public class Car
    {
        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKm { get; set; }

        public double DistanceTraveled { get; set; }

        public Car(string model)
        {
            this.Model = model;
        }

        public void Drive(double amountOfKm)
        {
            var fuelConsumed = amountOfKm * FuelConsumptionPerKm;

            if (this.FuelAmount >= fuelConsumed)
            {
                this.FuelAmount -= fuelConsumed;
                this.DistanceTraveled += amountOfKm;
            }
            else
            {
                throw new ArgumentException("Not enough fuel.");
            }
        }
    }
}
