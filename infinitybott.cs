using System;
using System.IO;
using Terraria;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.Chat;
using Microsoft.Xna.Framework;

namespace infinitybott
{
	public class infinitybott : Mod
	{
        public static Mod Instance;
        internal static infinitybott instance;
        public static ModKeybind Recall;
        public static ModKeybind Return;
        public static ModKeybind Teleportation;
        public static ModKeybind Peace;
        public static ModKeybind War;
        public const string ASSET_PATH = "infinitybott/Assets/";


        public override void Load()
        {

            Instance = this;
            string RecallText = Language.GetTextValue("Recall Potion Hotkey");
            Recall = KeybindLoader.RegisterKeybind(this, RecallText, "G");

            string ReturnText = Language.GetTextValue("Return Potion Hotkey");
            Return = KeybindLoader.RegisterKeybind(this, ReturnText, "H");

            string TeleportationText = Language.GetTextValue("Teleportation Potion Hotkey");
            Teleportation = KeybindLoader.RegisterKeybind(this, TeleportationText, "J");

            string PeaceText = Language.GetTextValue("Toggle Peace");
            Peace = KeybindLoader.RegisterKeybind(this, PeaceText, "K");

            string WarText = Language.GetTextValue("Toggle War");
            War = KeybindLoader.RegisterKeybind(this, WarText, "L");

            instance = this;

            Terraria.On_Player.HasUnityPotion += hook_HasUnityPotion;
            Terraria.On_Player.TakeUnityPotion += hook_TakeUnityPotion;
            /*
            //Need to Manually add some content to make ItemID order correct for rainbow in RecipeBrowser and CheatSheet

            AddContent<Content.Items.InfiniteBuffs.InfAllBuffs>();
            AddContent<Content.Items.InfiniteBuffs.BasicBuffs.InfBasicBuffs>();
            AddContent<Content.Items.InfiniteBuffs.ClassBuffs.InfClassBuffs>();
            AddContent<Content.Items.InfiniteBuffs.ArenaBuffs.InfArenaBuffs>();
            AddContent<Content.Items.InfiniteBuffs.ExplorationBuffs.InfExplorationBuffs>();
            AddContent<Content.Items.InfiniteBuffs.TravelBuffs.InfTravelBuffs>();
            AddContent<Content.Items.InfiniteBuffs.SpawningBuffs.InfSpawningBuffs>();
            AddContent<Content.Items.InfiniteBuffs.CombatBuffs.InfCombatBuffs>();
            AddContent<Content.Items.InfiniteBuffs.LuckBuffs.InfLuckBuffs>();
            */


        }

        private void hook_TakeUnityPotion(Terraria.On_Player.orig_TakeUnityPotion orig, Player self)
        {
            InfinitybottPlayer modPlayer = self.GetModPlayer<InfinitybottPlayer>();
            if (modPlayer.Inf_Wormhole) return;
            orig(self);
        }

        private bool hook_HasUnityPotion(Terraria.On_Player.orig_HasUnityPotion orig, Player self)
        {
            InfinitybottPlayer modPlayer = self.GetModPlayer<InfinitybottPlayer>();
            return (modPlayer.Inf_Wormhole || orig(self));
        }

        public override void Unload()
        {
            Instance = null;
            instance = null;
            Recall = null;
            Return = null;
            Teleportation = null;
            Peace = null;
            War = null;
        }

        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            InfinitybottPlayer modPlayer = Main.player[whoAmI].GetModPlayer<InfinitybottPlayer>();
            byte msgType = reader.ReadByte();
            switch (msgType)
            {
                case 0:
                    modPlayer.Inf_Calm = reader.ReadBoolean();
                    modPlayer.Inf_Battle = reader.ReadBoolean();
                    modPlayer.Inf_Peace_Candle = reader.ReadBoolean();
                    modPlayer.Inf_Water_Candle = reader.ReadBoolean();
                    modPlayer.Inf_Ult_Peace = reader.ReadBoolean();
                    modPlayer.Inf_Ult_War = reader.ReadBoolean();
                    modPlayer.Toggle_Peace = reader.ReadBoolean();
                    modPlayer.Toggle_War = reader.ReadBoolean();
                    break;
                default:
                    Logger.WarnFormat("MyMod: Unknown Message type: {0}", msgType);
                    break;
            }
        }
    }


}