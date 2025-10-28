using System;
using System.Numerics;
using Patterns.ChainOfResponsibility.Data;

namespace Patterns.ChainOfResponsibility.Handlers
{
    public class LocalDataHandler : HandlerBase
    {
        private SaveData _saveData;
        public override bool Handle(SaveData? saveData)
        {
            if (!TryLoadSavedData()) return false;
            if (!TryLoadResources()) return false;
            if (!TryLoadAssets()) return false;
            
            return base.Handle(_saveData);
        }

        private bool TryLoadSavedData()
        {
            Console.Out.WriteLine("Loading Saved Data...");
            _saveData = new SaveData();
            _saveData.PlayerData = CreatePlayerData();
            _saveData.SkinData = CreateSkinData();
            return true;
        }

        private bool TryLoadResources()
        {
            Console.Out.WriteLine("Loading Game Resources...");
            return true;
        }

        private bool TryLoadAssets()
        {
            Console.Out.WriteLine("Loading Assets...");
            return true;
        }

        private PlayerData CreatePlayerData()
        {
            PlayerData playerData = new PlayerData();
            playerData.Position = Vector3.Zero;
            playerData.Rotation = Quaternion.Identity;
            playerData.Level = 5;
            playerData.Health = 500;
            return playerData;
        }

        private SkinData CreateSkinData()
        {
            SkinData skinData = new SkinData();
            skinData.CurrentSkin = "Warrior";
            return skinData;
        }
    }
}