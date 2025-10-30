using Patterns.Command.Devices;
using Patterns.Command.Logger;

namespace Patterns.Command.Commands
{
    public class SwitchLightCommand : CommandBase
    {
        private LightDevice _light;
        private bool _isLightOn;
        private bool? _cachedState;
        
        public SwitchLightCommand(CommandLogger commandLogger, LightDevice lightDevice, bool isOn) : base(commandLogger)
        {
            _light = lightDevice;
            _isLightOn = isOn;
        }

        public override void Execute()
        {
            base.Execute();
            _cachedState = _light.IsLightOn;
            _light.SwitchLight(_isLightOn);
        }

        public override void Undo()
        {
            if (_cachedState != null)
            {
                _light.SwitchLight(_cachedState.Value);
                _cachedState = null;
            }
        }
    }
}