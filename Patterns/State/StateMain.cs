using Patterns.Common;
using Patterns.State.Abilities.Data;
using Patterns.State.Characters;
using Patterns.State.Classes.Data;

namespace Patterns.State
{
    public class StateMain : IProgram
    {
        private CharacterBase _player;
        private CharacterBase _trainingDummy;
        
        public void Run(object[]? args = null)
        {
            CreateActors();
            SimulateCombat();
        }

        private void CreateActors()
        {
            _player = new CharacterBase(5000, 5000, ClassType.Warlock, new GlobalCooldownManager());
            _trainingDummy = new CharacterBase(10000, 0, ClassType.Warlock, new GlobalCooldownManager());
        }

        private async void SimulateCombat()
        {
            _player.CastSpell(AbilityDatabase.AbilityNames.Warlock.Corruption, _trainingDummy);
            _player.CastSpell(AbilityDatabase.AbilityNames.Warlock.Corruption, _trainingDummy);
            await Task.Delay(2000);
            _player.CastSpell(AbilityDatabase.AbilityNames.Warlock.Haunt, _trainingDummy);
            _player.CastSpell(AbilityDatabase.AbilityNames.Warlock.Malevolence, _trainingDummy);
            _player.CastSpell(AbilityDatabase.AbilityNames.Warlock.DrainSoul, _trainingDummy);
        }
    }
}