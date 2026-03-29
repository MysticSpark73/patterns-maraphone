using Patterns.State.Abilities.States.Interfaces;

namespace Patterns.State.Abilities.States
{
    public abstract class AbilityCastStateBase : ICastable, ICancelable, IInterruptable, IChannelable, IEnterable, IExitable
    {
        protected AbilityBase _ability;

        public AbilityCastStateBase(AbilityBase ability)
        {
            _ability = ability;
        }
        public abstract void Cast();

        public abstract void Cancel();

        public abstract void Interrupt();

        public abstract void Channel();

        public abstract void Enter();

        public abstract void Exit();
    }
}