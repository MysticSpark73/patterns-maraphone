using System;
using Patterns.ChainOfResponsibility.Data;

namespace Patterns.ChainOfResponsibility.Handlers
{
    public class LoadPlayerHandler : HandlerBase
    {
        public override bool Handle(SaveData? saveData)
        {
            if (!TryLoadPlayer(saveData)) return false;
            if (!TryApplySavedSkin(saveData)) return false;
            return base.Handle(saveData);
        }

        private bool TryLoadPlayer(SaveData? saveData)
        {
            if (saveData == null) return false;
            
            Console.Out.WriteLine("Loading Player...\nPosition : {0}\nRotation : {1}\nLevel : {2}\nHealth : {3}",
                saveData.PlayerData.Position, saveData.PlayerData.Rotation, saveData.PlayerData.Level, saveData.PlayerData.Health);
            return true;
        }

        private bool TryApplySavedSkin(SaveData? saveData)
        {
            if (saveData == null) return false;
            
            Console.Out.WriteLine("Applied skin to Player : {0}", saveData.SkinData.CurrentSkin);
            return true;
        }
    }
}