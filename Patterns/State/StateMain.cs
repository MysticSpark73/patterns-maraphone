using Patterns.Common;
using Patterns.State.Abilities.Data;
using Patterns.State.Characters;
using Patterns.State.Classes.Data;
using Patterns.State.Extensions;

namespace Patterns.State
{
    public class StateMain : IProgram
    {
        private CharacterBase _player;
        private CharacterBase _trainingDummy;
        
        public void Run(object[]? args = null)
        {
            CreateActors();
            SimulateCombat().RunSync();
        }

        private void CreateActors()
        {
            Console.Out.WriteLine("Creating Actors!!!");
            _player = new CharacterBase(5000, 5000, ClassType.Warlock, new GlobalCooldownManager());
            _trainingDummy = new CharacterBase(10000, 0, ClassType.Warlock, new GlobalCooldownManager());
        }

        private async Task SimulateCombat()
        {
            await Console.Out.WriteLineAsync("Simulating combat!!!");
            _player.CastSpell(AbilityDatabase.AbilityNames.Warlock.Corruption, _trainingDummy);
            _player.CastSpell(AbilityDatabase.AbilityNames.Warlock.Corruption, _trainingDummy);
            await Task.Delay(2000);
            _player.CastSpell(AbilityDatabase.AbilityNames.Warlock.Haunt, _trainingDummy);
            await Task.Delay(2000);
            _player.CastSpell(AbilityDatabase.AbilityNames.Warlock.Malevolence, _trainingDummy);
            _player.CastSpell(AbilityDatabase.AbilityNames.Warlock.DrainSoul, _trainingDummy);
            await Task.Delay(2000);
            _player.CastSpell(AbilityDatabase.AbilityNames.Warlock.Haunt, _trainingDummy);
            await Task.Delay(100);
            _player.TryInterruptSpell();
            _player.TryCancelSpell();
            await Task.Delay(2000);
            _player.CastSpell(AbilityDatabase.AbilityNames.Warlock.Haunt, _trainingDummy);
            await Task.Delay(1000);
            _player.TryCancelSpell();
            await Task.Delay(20000);
            await Console.Out.WriteLineAsync("Simulation Finished!");
            await Console.Out.WriteLineAsync($"Training dummy HP = {_trainingDummy.CurrentHealth}");
        }
    }
}