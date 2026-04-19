using Patterns.State.Abilities.Data;
using Patterns.State.Abilities.States;
using Patterns.State.Characters;

namespace Patterns.State.Abilities
{
    public abstract class AbilityBase : ICastable, IDisposable
    {
        public bool IsInstant => _data.castTime.IsInstant;
        public bool IsChannelable => _data.channelDuration.IsChannelable;
        public bool HasDuration => _data.duration.HasDuration;
        public bool IsOnCooldown => _globalCooldownManager.IsOnCooldown || _localCooldownManager.IsOnCooldown;
        public string Name => _data.name;
        public CastTime CastTime => _data.castTime;
        public ChannelDuration ChannelDuration => _data.channelDuration;
        
        protected AbilityCastStateBase _state;
        protected AbilityData _data;
        protected GlobalCooldownManager _globalCooldownManager;
        protected LocalCooldownManager _localCooldownManager;
        protected AbilityCastData? _castData;

        protected Dictionary<StateType, AbilityCastStateBase> _stateTypeToState;

        protected AbilityBase(AbilityData data, GlobalCooldownManager cooldownManager)
        {
            _data = data;
            _globalCooldownManager = cooldownManager;
            _localCooldownManager = new LocalCooldownManager(_data.cooldown);
            
            CreateStates();
            ChangeState(StateType.ReadyState);
        }

        public virtual void Cast()
        {
            _state.Cast();
        }

        public void ChangeState(StateType stateType)
        {
            if (_stateTypeToState.ContainsKey(stateType))
            {
                _state?.Exit();
                _state = _stateTypeToState[stateType];
                _state.Enter();
                Console.Out.WriteLine($"{GetType()} ability state changed to {stateType}");
            }
            else
            {
                Console.Out.WriteLine($"Can't enter state with type {stateType}");
            }
        }

        public virtual void OnCastStart()
        {
            if (_data.IsAffectedByGlobalCooldown)
            {
                _globalCooldownManager.StartCooldownTimer();
            }
        }

        public virtual void OnCast()
        {
            _castData = null;
        }

        public virtual void OnChannelStart() { }

        public virtual void OnChannelFinish() { }

        public virtual void StartCooldown() => _localCooldownManager.StartCooldownTimer();

        public virtual bool RequestCast(AbilityCastData abilityCastData)
        {
            if (abilityCastData.target == null)
            {
                Console.Out.WriteLine($"Can't cast {GetType()}! Spell requires target!");
                return false;
            }

            _castData = abilityCastData;
            Cast();
            return true;
        }

        private void CreateStates()
        {
            _stateTypeToState = new Dictionary<StateType, AbilityCastStateBase>()
            {
                { StateType.ReadyState, new AbilityReadyState(this) },
                { StateType.CastingState, new AbilityCastingState(this) },
                { StateType.ChannelingState, new AbilityChannelingState(this) }
            };
        }

        public void Dispose()
        {
            _localCooldownManager.Dispose();
        }
    }
}