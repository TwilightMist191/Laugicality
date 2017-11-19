using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria.UI;
using Terraria.DataStructures;
using Terraria.GameContent.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using System;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.UI.Chat;
using Terraria.ModLoader;
using Laugicality.Etherial;

namespace Laugicality //Laugicality.cs
{
    class Laugicality : Mod
    {
        internal static ModHotKey ToggleMystic;
        internal static ModHotKey ToggleSoulStoneV;
        internal static ModHotKey ToggleSoulStoneM;
        private double pressedHotkeyTime;

        public Laugicality()
        {
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true,
                AutoloadBackgrounds = true
            };
        }
        //Calling Mod References
        Mod calMod = ModLoader.GetMod("Calamity");

        //Recipe Groups
        public override void AddRecipeGroups()
        {
            //Emblems
            RecipeGroup group = new RecipeGroup(() => Lang.misc[37] + " Emblem", new int[]
            {
                ItemID.RangerEmblem,
                ItemID.WarriorEmblem,
                ItemID.SorcererEmblem,
                ItemID.SummonerEmblem,
                ItemType("NullEmblem"),
                ItemType("MysticEmblem"),
                ItemType("NinjaEmblem")
            });
            RecipeGroup.RegisterGroup("Emblems", group);


            //Gems
            RecipeGroup Ggroup = new RecipeGroup(() => Lang.misc[37] + " Gem", new int[]
            {
                ItemID.Amethyst,
                ItemID.Topaz,
                ItemID.Ruby,
                ItemID.Sapphire,
                ItemID.Emerald,
                ItemID.Ruby,
                ItemID.Diamond,
                ItemID.Amber
            });
            RecipeGroup.RegisterGroup("Gems", Ggroup);

            //Gen
            RecipeGroup Sgroup = new RecipeGroup(() => Lang.misc[37] + " Silver Bar", new int[]
            {
                ItemID.SilverBar,
                ItemID.TungstenBar
            });
            RecipeGroup.RegisterGroup("SilverBars", Sgroup);


        }

        //BossChecklist
        public override void PostSetupContent()
        {
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if (bossChecklist != null)
            {
                bossChecklist.Call("AddBossWithInfo", "The Annihilator", 9.2f, (Func<bool>)(() => LaugicalityWorld.downedAnnihilator), string.Format("The Steam-O-Vision [i:{0}] will summon it at night", ItemType("MechanicalMonitor")));
                bossChecklist.Call("AddBossWithInfo", "Slybertron", 9.3f, (Func<bool>)(() => LaugicalityWorld.downedSlybertron), string.Format("The Steam Crown [i:{0}] calls to its King", ItemType("SteamCrown")));
                bossChecklist.Call("AddBossWithInfo", "Steam Train", 9.4f, (Func<bool>)(() => LaugicalityWorld.downedSteamTrain), string.Format("A Suspicious Train Whistle [i:{0}] might get its attention.", ItemType("SuspiciousTrainWhistle")));
                bossChecklist.Call("AddBossWithInfo", "Dune Sharkron", 2.3f, (Func<bool>)(() => LaugicalityWorld.downedDuneSharkron), string.Format("A Tasty Morsel [i:{0}] in the daytime will attract this Shark's attention.", ItemType("TastyMorsel")));
                bossChecklist.Call("AddBossWithInfo", "Hypothema", 2.4f, (Func<bool>)(() => LaugicalityWorld.downedHypothema), string.Format("There's a chill in the air... [i:{0}]", ItemType("ChilledMesh")));
                bossChecklist.Call("AddBossWithInfo", "Ragnar", 2.5f, (Func<bool>)(() => LaugicalityWorld.downedRagnar), string.Format("This Molten Mess [i:{0}] guards the underground.", ItemType("MoltenMess")));
                bossChecklist.Call("AddBossWithInfo", "Etheria", 10.51f, (Func<bool>)(() => LaugicalityWorld.downedTrueEtheria), string.Format("The guardian of the Etherial will consume its prey. [i:{0}]", ItemType("EmblemOfEtheria")));
            }
        }
        
        //Hotkeys
        public override void Load()
        {
            if (!Main.dedServ)
            {
                Filters.Scene["Laugicality:Etherial"] = new Filter(new EtherialShader("FilterMiniTower").UseColor(0.4f, 0.1f, 1.0f).UseOpacity(0.5f), EffectPriority.VeryHigh);
                SkyManager.Instance["Laugicality:Etherial"] = new EtherialVisual();
            }
                ToggleMystic = RegisterHotKey("Toggle Mysticism", "Mouse2");
            ToggleSoulStoneV = RegisterHotKey("Toggle Accessory Visual FX", "V");
            ToggleSoulStoneM = RegisterHotKey("Toggle Accessory Mobility FX", "C");
        }
        public override void UpdateMusic(ref int music)
        {
            if(Main.myPlayer != -1 && !Main.gameMenu)
            {
                if (Main.player[Main.myPlayer].active && Main.player[Main.myPlayer].GetModPlayer<LaugicalityPlayer>(this).etherial && Main.player[Main.myPlayer].GetModPlayer<LaugicalityPlayer>(this).etherialMusic)
                {
                    music = this.GetSoundSlot(SoundType.Music, "Sounds/Music/Etherial");
                }
                if (Main.player[Main.myPlayer].active && Main.player[Main.myPlayer].GetModPlayer<LaugicalityPlayer>(this).ZoneObsidium)
                {
                    music = this.GetSoundSlot(SoundType.Music, "Sounds/Music/Obsidium");
                }

            }
        }
    }

}
