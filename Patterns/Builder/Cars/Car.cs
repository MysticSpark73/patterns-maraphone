using System.Drawing;
using Patterns.Builder.Cars.CarParts;

namespace Patterns.Builder.Cars
{
    public class Car
    {
        private CarEngineBase _engine;
        private Color _color;
        private TransmissionType _transmissionType;
        private int _seatsNumber;
        private bool _tripComputer;
        private bool _hasTrunk;
        private bool _turbo;
        private bool _winch;

        public Car(CarBlueprint blueprint)
        {
            _engine = blueprint.Engine;
            _color = blueprint.Color;
            _transmissionType = blueprint.TransmissionType;
            _seatsNumber = blueprint.SeatsNumber;
            _tripComputer = blueprint.TripComputer;
            _hasTrunk = blueprint.HasTrunk;
            _turbo = blueprint.Turbo;
            _winch = blueprint.Winch;
        }

        public string GetStats()
        {
            string res = $"{nameof(_engine)} : {_engine}\n" +
                         $"{nameof(_color)} : {_color}\n" +
                         $"{nameof(_transmissionType)} : {_transmissionType}\n" +
                         $"{nameof(_seatsNumber)} : {_seatsNumber}\n" +
                         $"{nameof(_tripComputer)} : {_tripComputer}\n" +
                         $"{nameof(_hasTrunk)} : {_hasTrunk}\n" +
                         $"{nameof(_turbo)} : {_turbo}\n" +
                         $"{nameof(_winch)} : {_winch}\n";
            return res;
        }
    }

    public enum TransmissionType : byte
    {
        TwoWheelDrive = 0,
        FourWheelDrive = 1,
        AWD = 2,
        
    }
}