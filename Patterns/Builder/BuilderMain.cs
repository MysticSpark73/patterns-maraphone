using System;
using Patterns.Builder.Builders;
using Patterns.Builder.Cars;
using Patterns.Builder.Cars.CarParts;
using Patterns.Builder.Directors;
using Patterns.Common;

namespace Patterns.Builder
{
    public class BuilderMain : IProgram
    {
        private CarDirector<Car, CarBuilder> _carDirector;
        public SportsCarsDirector<Car, CarBuilder> _sportsCarsDirector;

        private Car[] _cars;
    
        public void Run(object[]? args = null)
        {
            _cars = new Car[3];
            CreateDirectors();
            CreateCars();
            PrintInfo();
        }

        private void CreateDirectors()
        {
            _carDirector = new CarDirector<Car, CarBuilder>();
            _sportsCarsDirector = new SportsCarsDirector<Car, CarBuilder>();
        
            _carDirector.SetBuilder(new CarBuilder());
            _sportsCarsDirector.SetBuilder(new CarBuilder());
        }

        private void CreateCars()
        {
            _cars[0] = _carDirector.BuildCar(new ElectricCarEngine(115, 10000, 1300));
            _cars[1] = _carDirector.BuildCar(new CarEngine(6, 240, 2.3f, 4.1f, CarEngineBase.FuelType.Diesel));
            _cars[2] = _sportsCarsDirector.BuildCar(new CarEngine(12, 666, 3.5f, 5.2f, CarEngineBase.FuelType.Petrol));
        }

        private void PrintInfo()
        {
            for (int i = 0; i < _cars.Length; i++)
            {
                Console.WriteLine("/////////////////");
                Console.WriteLine();
                Console.WriteLine(_cars[i].GetStats());
            }
        }
    }
}