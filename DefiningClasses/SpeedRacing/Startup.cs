using SpeedRacing.Models;
using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    public class Startup
    {
        public static void Main()
        {
            var totalCars = int.Parse(Console.ReadLine());
            var cars = new Dictionary<string, Car>();

            for (int i = 0; i < totalCars; i++)
            {
                var carInfo = Console.ReadLine()
                    .Split();
                var model = carInfo[0];
                var fuelAmount = double.Parse(carInfo[1]);
                var fuelPerKm = double.Parse(carInfo[2]);

                var car = new Car(model)
                {
                    FuelAmount = fuelAmount,
                    FuelConsumptionPerKm = fuelPerKm
                };

                if (cars.ContainsKey(model))
                {
                    break;
                }

                cars[model] = car;
            }

            while (true)
            {
                var command = Console.ReadLine().Split();
                if (command[0] == "End")
                {
                    break;
                }

                var model = command[1];
                var amountOfKm = double.Parse(command[2]);
                try
                {
                    cars[model].Drive(amountOfKm);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            foreach (var car in cars.Values)
            {
                Console.WriteLine($"{car.Model} - Fuel: {car.FuelAmount}, Distance: {car.DistanceTraveled}");
            }
        }
    }
}
