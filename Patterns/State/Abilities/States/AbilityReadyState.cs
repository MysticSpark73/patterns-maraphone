
namespace Patterns.State.Abilities.States
{
    public class AbilityReadyState : AbilityCastStateBase
    {
        public AbilityReadyState(AbilityBase ability) : base(ability) { }

        public override bool Cast()
        {
            if (_ability.IsOnCooldown)
            {
                Console.Out.WriteLine($"Ability {_ability.GetType().Name} is on cooldown and can't be cast!");
                return false;
            }
            
            _ability.ChangeState(StateType.CastingState);
            return true;
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

        public override void Enter() { }

        public override void Exit() { }
    }
}