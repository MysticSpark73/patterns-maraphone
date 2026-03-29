using Patterns.State.Abilities.Data;
using Patterns.State.Abilities.States;
using Patterns.State.Characters;

namespace Patterns.State.Abilities
{
    public abstract class AbilityBase
    {
        public bool IsInstant => _data.castTime.IsInstant;
        public bool IsChannelable => _data.channelDuration.IsChannelable;
        public bool IsOnCooldown => _globalCooldownManager.IsOnCooldown || _localCooldownManager.IsOnCooldown;
        
        protected AbilityCastStateBase _state;
        protected AbilityData _data;
        protected GlobalCooldownManager _globalCooldownManager;
        protected LocalCooldownManager _localCooldownManager;

        protected Dictionary<StateType, AbilityCastStateBase> _stateTypeToState;

        protected AbilityBase(AbilityData data, GlobalCooldownManager cooldownManager)
        {
            _data = data;
            _globalCooldownManager = cooldownManager;
            _localCooldownManager = new LocalCooldownManager(_data.cooldown);
            
            CreateStates();
            ChangeState(StateType.ReadyState);
        }

        public void ChangeState(StateType stateType)
        {
            if (_stateTypeToState.ContainsKey(stateType))
            {
                _state?.Exit();
                _state = _stateTypeToState[stateType];
                _state.Enter();
            }
            else
            {
                Console.Out.WriteLine($"Can't enter state with type {stateType}");
            }
        }

        private void CreateStates()
        {
            _stateTypeToState = new Dictionary<StateType, AbilityCastStateBase>()
            {
                { StateType.ReadyState, new AbilityReadyState(this) },
                { StateType.CastingState, new AbilityCastingState(this) }
            };
        }
    }
}