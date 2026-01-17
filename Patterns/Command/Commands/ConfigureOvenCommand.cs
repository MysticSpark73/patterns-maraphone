using Patterns.Command.Devices;
using Patterns.Command.Logger;

namespace Patterns.Command.Commands
{
    public class ConfigureOvenCommand : CommandBase
    {
        private SmartOven _oven;
        private bool _isOn;
        private int _temperature;
        private bool? _cachedState;
        private int? _cachedTemperature;
        
        public ConfigureOvenCommand(CommandLogger commandLogger, SmartOven smartOven, bool isOn, int temperature) :
            base(commandLogger)
        {
            _oven = smartOven;
            _isOn = isOn;
            _temperature = temperature;
        }

        public override void Execute()
        {
            base.Execute();
            _cachedState = _oven.IsOn;
            _cachedTemperature = _oven.Temperature;
            
            _oven.SetEnabled(_isOn);
            _oven.SetTemperature(_temperature);
            Console.Out.WriteLine($"The oven is set to {0}\nTemperature = {1}", _isOn ? "on" : "off", _temperature);
        }

        public override void Undo()
        {
            if (_cachedState != null)
            {
                _oven.SetEnabled(_cachedState.Value);
                _cachedState = null;
            }

            if (_cachedTemperature != null)
            {
                _oven.SetTemperature(_cachedTemperature.Value);
                _cachedTemperature = null;
            }
        }
    }
}