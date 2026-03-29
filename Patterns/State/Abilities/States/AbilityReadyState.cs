namespace Patterns.State.Abilities.States
{
    public class AbilityReadyState : AbilityCastStateBase
    {
        public AbilityReadyState(AbilityBase ability) : base(ability) { }

        public override void Cast()
        {
            if (_ability.IsInstant)
            {
                //todo: go to CooldownState
            }
            else
            {
                _ability.ChangeState(StateType.CastingState);
            }
        }

        public override void Cancel()
        {
            //do nothing
        }

        public override void Interrupt()
        {
            //do nothing
        }

        public override void Channel()
        {
            //do nothing
        }

        public override void Enter()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}