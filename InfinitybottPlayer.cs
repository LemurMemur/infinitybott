using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ReLogic.Utilities;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Events;
using Terraria.GameContent.Tile_Entities;
using Terraria.GameContent.UI;
using Terraria.GameInput;
using Terraria.Graphics.Capture;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ObjectData;
using Terraria.Social;
using Terraria.UI;
using Terraria.UI.Chat;
using Terraria.UI.Gamepad;
using Terraria.Utilities;
using Terraria.WorldBuilding;
using Terraria;
using Terraria.Chat;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;
using infinitybott;

namespace infinitybott
{
    internal class InfinitybottPlayer : ModPlayer
    {
        // Maybe I could make this an array with an enumerated array but I think that might take longer for most of them
        // would use something like active[# buffs] to simplify some of this
        // Teleportation
        public bool ReturnAvailable = false;
        public Vector2 ReturnLocation = new Vector2(0, 0);
        public bool Inf_Recall = false;
        public bool Inf_Return = false;
        public bool Inf_Wormhole = false;
        public bool Inf_Teleportation = false;
        // Basic
        public bool Inf_Ironskin = false;
        public bool Inf_Swiftness = false;
        public bool Inf_Regeneration = false;
        public bool Inf_Fed = false;
        public bool Inf_Satisfied = false;
        public bool Inf_Stuffed = false;
        // Arena
        public bool Inf_Campfire = false;
        public bool Inf_Heart_Lantern = false;
        public bool Inf_Honey = false;
        public bool Inf_Star_Bottle = false;
        public bool Inf_Sunflower = false;
        public bool Inf_Bast = false;
        // Class Specific Buffs
        //  Slice of Cake is a general station (movement and mining speed), so I'm going to just include it with the other stations
        public bool Inf_Sugar_Rush = false;
        //  Melee
        public bool Inf_Sharpened = false;
        public bool Inf_Ichor = false;
        public bool Inf_Tipsy = false;
        //  Ranged
        public bool Inf_Ammo_Box = false;
        public bool Inf_Ammo_Reservation = false;
        public bool Inf_Archery = false;
        //  Magic
        public bool Inf_Clairvoyance = false;
        public bool Inf_Magic_Power = false;
        public bool Inf_Mana_Regeneration = false;
        //  Summon
        public bool Inf_Bewitched = false;
        public bool Inf_Summoning = false;
        public bool Inf_Strategist = false;
        // Luck Buffs
        public bool Inf_Lesser_Luck = false;
        public bool Inf_Medium_Luck = false;
        public bool Inf_Greater_Luck = false;
        public bool Inf_Ladybug_Luck = false;
        public bool Inf_Gnome_Luck = false;
        public bool Inf_Torch_Luck = false;
        // Exploration Buffs
        //  Gathering Buffs
        public bool Inf_Builder = false;
        public bool Inf_Mining = false;
        public bool Inf_Obsidian_Skin = false;
        public bool Inf_Spelunker = false;
        //  Visual Buffs
        public bool Inf_Dangersense = false;
        public bool Inf_Hunter = false;
        public bool Inf_Night_Owl = false;
        public bool Inf_Shine = false;
        public bool Inf_Invisibility = false;
        //  Flight Buffs
        public bool Inf_Featherfall = false;
        public bool Inf_Gravitation = false;
        //  Aquatic Buffs
        public bool Inf_Flipper = false;
        public bool Inf_Gills = false;
        public bool Inf_Water_Walking = false;
        //  Fishing Buffs
        public bool Inf_Fishing = false;
        public bool Inf_Sonar = false;
        public bool Inf_Crate = false;
        // Combat Buffs
        //  Offensive Buffs
        public bool Inf_Inferno = false;
        public bool Inf_Rage = false;
        public bool Inf_Titan = false;
        public bool Inf_Wrath = false;
        //  Defensive Buffs
        public bool Inf_Endurance = false;
        public bool Inf_Heartreach = false;
        public bool Inf_Lifeforce = false;
        public bool Inf_Thorns = false;
        public bool Inf_Warmth = false;
        // Spawn Rate Modifiers
        public bool Inf_Calm = false;
        public bool Inf_Battle = false;
        public bool Inf_Peace_Candle = false;
        public bool Inf_Water_Candle = false;
        public bool Inf_Ult_Peace = false;
        public bool Inf_Ult_War = false;
        public bool Toggle_Peace = true; // Default value ON, maybe I should put these 2 in the config instead
        public bool Toggle_War = false;

        public override void OnEnterWorld() // REMEMBER TO COMMENT THIS OUT WHEN STUFF IS FIXED >:(
        {
            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                //Main.NewText("Hoho\nI've temporarily disabled the effects of Wormholes and Spawning Modifiers as they seem to be causing issues. They'll be back once I fix them.\nPlease let me know if you run into any other issues.\n-Saki", 255, 0, 255);
            }
            else
            {
                //ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("Hoho\nI've temporarily disabled the effects of Wormholes and Spawning Modifiers as they seem to be causing issues. They'll be back once I fix them.\nPlease let me know if you run into any other issues.\n-Saki"), Color.Magenta);
            }

        }
        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer) // not sure how to use this
        {
            /*
            ModPacket packet = Mod.GetPacket();
            packet.Write((byte)0);
            packet.Write((byte)Player.whoAmI);
            packet.Send(toWho, fromWho);
            */
        }

        public override void CopyClientState(ModPlayer clientClone)/* tModPorter Suggestion: Replace Item.Clone usages with Item.CopyNetStateTo */
        {
            InfinitybottPlayer clone = clientClone as InfinitybottPlayer;
            clone.Inf_Calm = Inf_Calm;
            clone.Inf_Battle = Inf_Battle;
            clone.Inf_Peace_Candle = Inf_Peace_Candle;
            clone.Inf_Water_Candle = Inf_Water_Candle;
            clone.Inf_Ult_Peace = Inf_Ult_Peace;
            clone.Inf_Ult_War = Inf_Ult_War;
            clone.Toggle_Peace = Toggle_Peace;
            clone.Toggle_War = Toggle_War;
        }

        public override void SendClientChanges(ModPlayer clientPlayer)
        {
            InfinitybottPlayer clone = clientPlayer as InfinitybottPlayer;
            bool NeedsUpdateSpawning =
                clone.Inf_Calm == Inf_Calm ||
                clone.Inf_Battle == Inf_Battle ||
                clone.Inf_Peace_Candle == Inf_Peace_Candle ||
                clone.Inf_Water_Candle == Inf_Water_Candle ||
                clone.Inf_Ult_Peace == Inf_Ult_Peace ||
                clone.Inf_Ult_War == Inf_Ult_War ||
                clone.Toggle_Peace == Toggle_Peace ||
                clone.Toggle_War == Toggle_War
           ;
            if (NeedsUpdateSpawning) // Maybe i should make a package handler module if i create more things that need updates
            {
                ModPacket packet = Mod.GetPacket();
                packet.Write((byte)0); // type spawning
                packet.Write(Inf_Calm);
                packet.Write(Inf_Battle);
                packet.Write(Inf_Peace_Candle);
                packet.Write(Inf_Water_Candle);
                packet.Write(Inf_Ult_Peace);
                packet.Write(Inf_Ult_War);
                packet.Write(Toggle_Peace);
                packet.Write(Toggle_War);
                packet.Send();
            }
        }

        public override void ResetEffects()
        {
            // Recall and Wormhole
            //RecallBackAvailable = false; // i think this bad
            //RecallBackLocation = new Vector2(0, 0);
            Inf_Recall = false;
            Inf_Return = false;
            Inf_Wormhole = false;
            Inf_Teleportation = false;
            // Basic
            Inf_Ironskin = false;
            Inf_Swiftness = false;
            Inf_Regeneration = false;
            Inf_Fed = false;
            Inf_Satisfied = false;
            Inf_Stuffed = false;
            // Arena
            Inf_Campfire = false;
            Inf_Heart_Lantern = false;
            Inf_Honey = false;
            Inf_Star_Bottle = false;
            Inf_Sunflower = false;
            Inf_Bast = false;
            // Class Specific Buffs
            // Slice of Cake is a general station (movement and mining speed), so I'm going to just include it with the other stations
            Inf_Sugar_Rush = false;
            // Melee
            Inf_Sharpened = false;
            Inf_Ichor = false;
            Inf_Tipsy = false;
            // Ranged
            Inf_Ammo_Box = false;
            Inf_Ammo_Reservation = false;
            Inf_Archery = false;
            // Magic
            Inf_Clairvoyance = false;
            Inf_Magic_Power = false;
            Inf_Mana_Regeneration = false;
            // Summon
            Inf_Bewitched = false;
            Inf_Summoning = false;
            Inf_Strategist = false;
            // Luck Buffs
            Inf_Lesser_Luck = false;
            Inf_Medium_Luck = false;
            Inf_Greater_Luck = false;
            Inf_Ladybug_Luck = false;
            Inf_Gnome_Luck = false;
            Inf_Torch_Luck = false;
            // Exploration Buffs
            //  Gathering Buffs
            Inf_Builder = false;
            Inf_Mining = false;
            Inf_Obsidian_Skin = false;
            Inf_Spelunker = false;
            //  Visual Buffs
            Inf_Dangersense = false;
            Inf_Hunter = false;
            Inf_Night_Owl = false;
            Inf_Shine = false;
            Inf_Invisibility = false;
            //  Flight Buffs
            Inf_Featherfall = false;
            Inf_Gravitation = false;
            //  Aquatic Buffs
            Inf_Flipper = false;
            Inf_Gills = false;
            Inf_Water_Walking = false;
            //  Fishing Buffs
            Inf_Fishing = false;
            Inf_Sonar = false;
            Inf_Crate = false;
            // Combat Buffs
            //  Offensive Buffs
            Inf_Inferno = false;
            Inf_Rage = false;
            Inf_Titan = false;
            Inf_Wrath = false;
            //  Defensive Buffs
            Inf_Endurance = false;
            Inf_Heartreach = false;
            Inf_Lifeforce = false;
            Inf_Thorns = false;
            Inf_Warmth = false;
            // Spawn Rate Modifiers
            Inf_Calm = false;
            Inf_Battle = false;
            Inf_Peace_Candle = false;
            Inf_Water_Candle = false;
            Inf_Ult_Peace = false;
            Inf_Ult_War = false;
        }

        public void UseTravelBuffs() // they're not actually buffs but i'm going to name this method buffs for consistency
        {
            Inf_Recall = true;
            Inf_Return = true;
            Inf_Wormhole = true;
            Inf_Teleportation = true;
        }

        public void UseBasicBuffs()
        {
            Inf_Ironskin = true;
            Inf_Swiftness = true;
            Inf_Regeneration = true;
            Inf_Stuffed = true;
        }

        public void UseArenaBuffs()
        {
            Inf_Campfire = true;
            Inf_Heart_Lantern = true;
            Inf_Honey = true;
            Inf_Star_Bottle = true;
            Inf_Sunflower = true;
            Inf_Bast = true;
        }

        public void UseMeleeBuffs()
        {
            Inf_Sharpened = true;
            Inf_Ichor = true;
            Inf_Tipsy = true;
        }
        public void UseRangedBuffs()
        {
            Inf_Ammo_Box = true;
            Inf_Ammo_Reservation = true;
            Inf_Archery = true;
        }
        public void UseMagicBuffs()
        {
            Inf_Clairvoyance = true;
            Inf_Magic_Power = true;
            Inf_Mana_Regeneration = true;
        }
        public void UseSummonBuffs()
        {
            Inf_Bewitched = true;
            Inf_Summoning = true;
            Inf_Strategist = true;
        }
        public void UseClassBuffs()
        {
            UseMeleeBuffs();
            UseRangedBuffs();
            UseMagicBuffs();
            UseSummonBuffs();
            Inf_Sugar_Rush = true;
        }

        public void UseLuckBuffs()
        {
            Inf_Lesser_Luck = true;
            Inf_Medium_Luck = true;
            Inf_Greater_Luck = true;
            Inf_Ladybug_Luck = true;
            Inf_Gnome_Luck = true;
            Inf_Torch_Luck = true;
        }

        public void UseGatheringBuffs()
        {
            Inf_Builder = true;
            Inf_Mining = true;
            Inf_Obsidian_Skin = true;
            Inf_Spelunker = true;
        }
        public void UseVisualBuffs()
        {
            Inf_Dangersense = true;
            Inf_Hunter = true;
            Inf_Night_Owl = true;
            Inf_Shine = true;
            Inf_Invisibility = true;
        }
        public void UseFlightBuffs()
        {
            Inf_Featherfall = true;
            Inf_Gravitation = true;
        }
        public void UseAquaticBuffs()
        {
            Inf_Flipper = true;
            Inf_Gills = true;
            Inf_Water_Walking = true;
        }
        public void UseFishingBuffs()
        {
            Inf_Fishing = true;
            Inf_Sonar = true;
            Inf_Crate = true;
        }
        public void UseExplorationBuffs()
        {
            UseGatheringBuffs();
            UseVisualBuffs();
            UseFlightBuffs();
            UseAquaticBuffs();
            UseFishingBuffs();
        }

        public void UseOffensiveBuffs()
        {
            Inf_Inferno = true;
            Inf_Rage = true;
            Inf_Titan = true;
            Inf_Wrath = true;
        }
        public void UseDefensiveBuffs()
        {
            Inf_Endurance = true;
            Inf_Heartreach = true;
            Inf_Lifeforce = true;
            Inf_Thorns = true;
            Inf_Warmth = true;
        }
        public void UseCombatBuffs()
        {
            UseOffensiveBuffs();
            UseDefensiveBuffs();
        }

        public void UseSpawningBuffs()
        {
            Inf_Ult_Peace = true;
            Inf_Ult_War = true;
        }

        public void UseAllBuffs()
        {
            UseTravelBuffs();
            UseBasicBuffs();
            UseArenaBuffs();
            UseClassBuffs();
            UseLuckBuffs();
            UseExplorationBuffs();
            UseCombatBuffs();
            UseSpawningBuffs();
        }

        public void InfinitybottInfernoEffect() // This is all taken from the tModLoader source code, with minor adjustments to be compatible here. No damage or stat changes were made.
        {
            if (infinitybottConfig.Toggle_Inf_Inferno_Visual) Player.inferno = true;
            Lighting.AddLight((int)(Player.Center.X / 16f), (int)(Player.Center.Y / 16f), 0.65f, 0.4f, 0.1f);
            int num12 = 323;
            float num18 = 200f;
            bool flag = Player.infernoCounter % 60 == 0;
            int damage = 20;
            if (Player.whoAmI != Main.myPlayer)
            {
                return;
            }
            for (int k = 0; k < 200; k++)
            {
                NPC nPC = Main.npc[k];
                if (nPC.active && !nPC.friendly && nPC.damage > 0 && !nPC.dontTakeDamage && !nPC.buffImmune[num12] && Player.CanNPCBeHitByPlayerOrPlayerProjectile(nPC) && Vector2.Distance(Player.Center, nPC.Center) <= num18)
                {
                    if (nPC.FindBuffIndex(num12) == -1)
                    {
                        nPC.AddBuff(num12, 120);
                    }
                    if (flag)
                    {
                        Player.ApplyDamageToNPC(nPC, damage, 0f, 0);
                    }
                }
            }
            if (!Player.hostile)
            {
                return;
            }
            for (int l = 0; l < 255; l++)
            {
                Player player = Main.player[l];
                if (player == Player || !player.active || player.dead || !player.hostile || player.buffImmune[num12] || (player.team == Player.team && player.team != 0) || !(Vector2.Distance(Player.Center, player.Center) <= num18))
                {
                    continue;
                }
                if (player.FindBuffIndex(num12) == -1)
                {
                    player.AddBuff(num12, 120);
                }
                if (flag)
                {
                    PlayerDeathReason reason = PlayerDeathReason.ByOther(16, Player.whoAmI);
                    player.Hurt(reason, damage, 0, pvp: true);
                    if (Main.netMode != 0)
                    {
                        Player.HurtInfo info = new Player.HurtInfo
                        {
                            DamageSource = reason,
                            PvP = true,
                            Damage = damage
                        };
                        NetMessage.SendPlayerHurt(l, info);
                    }
                }
            }
        }


        public override void UpdateEquips() // This is where the actual stat changes and effects happen. Most of this code is taken from the tModLoader decompiled source code.
        {
            if (Inf_Ironskin)
            {
                Player.buffImmune[BuffID.Ironskin] = true;
                Player.statDefense += 8; // +8 defense
            }
            if (Inf_Swiftness)
            {
                Player.buffImmune[BuffID.Swiftness] = true;
                Player.moveSpeed += 0.25f; // 25% bonus run speed
            }
            if (Inf_Regeneration)
            {
                Player.buffImmune[BuffID.Regeneration] = true;
                Player.lifeRegen += 4; // +2 health / second
            }
            if (Inf_Stuffed) // Highest Well Fed
            {
                Player.buffImmune[BuffID.WellFed] = true;
                Player.buffImmune[BuffID.WellFed2] = true;
                Player.buffImmune[BuffID.WellFed3] = true;
                Player.wellFed = true;
                Player.statDefense += 4;
                Player.GetCritChance(DamageClass.Generic) += 4f;
                Player.GetDamage(DamageClass.Generic) += 0.1f;
                Player.GetAttackSpeed(DamageClass.Melee) += 0.1f;
                Player.GetKnockback(DamageClass.Summon) += 1f;
                Player.moveSpeed += 0.4f;
                Player.pickSpeed -= 0.15f;
            }
            else if (Inf_Satisfied) // Middle Well Fed
            {
                Player.buffImmune[BuffID.WellFed] = true;
                Player.buffImmune[BuffID.WellFed2] = true;
                Player.buffImmune[BuffID.WellFed3] = true;
                Player.wellFed = true;
                Player.statDefense += 3;
                Player.GetCritChance(DamageClass.Generic) += 3f;
                Player.GetDamage(DamageClass.Generic) += 0.075f;
                Player.GetAttackSpeed(DamageClass.Melee) += 0.075f;
                Player.GetKnockback(DamageClass.Summon) += 0.75f;
                Player.moveSpeed += 0.3f;
                Player.pickSpeed -= 0.1f;
            }
            else if (Inf_Fed) // Basic Well Fed
            {
                Player.buffImmune[BuffID.WellFed] = true;
                Player.buffImmune[BuffID.WellFed2] = true;
                Player.buffImmune[BuffID.WellFed3] = true;
                Player.wellFed = true;
                Player.statDefense += 2;
                Player.GetCritChance(DamageClass.Generic) += 2f;
                Player.GetDamage(DamageClass.Generic) += 0.05f;
                Player.GetAttackSpeed(DamageClass.Melee) += 0.05f;
                Player.GetKnockback(DamageClass.Summon) += 0.5f;
                Player.moveSpeed += 0.2f;
                Player.pickSpeed -= 0.05f;
            }

            // Arena buffs
            if (Inf_Campfire)
            {
                Player.buffImmune[BuffID.Campfire] = true;

                //Player.lifeRegen += 1; // +0.5 health / second
                //Player.lifeRegenTime = (int) (Player.lifeRegenTime * 1.1f); // 1.1x regen speed 
                // Because of the int cast, I have no clue if the second line actually does anything.
                // It's not included in the vanilla campfire buff code, but says 1.1x speed on the wiki.

                // Above block is wrong, instead is implemented in NaturalLifeRegen override

                // Nevermind, above line is also wrong, simply tell Terraria that there is a campfire on scene
                // Campfire buff doesn't actually do anything in the source code, all the stat changes just come from this next boolean
                Main.SceneMetrics.HasCampfire = true;
                // Same changes to Gnomes and Heart Lanterns
            }
            if (Inf_Heart_Lantern)
            {
                Player.buffImmune[BuffID.HeartLamp] = true;
                //Player.lifeRegen += 2; // +1 health / second
                // See campfire comments for notes
                Main.SceneMetrics.HasHeartLantern = true;
            }
            if (Inf_Honey)
            {
                Player.buffImmune[BuffID.Honey] = true;
                Player.honey = true;
            }
            if (Inf_Star_Bottle)
            {
                Player.buffImmune[BuffID.StarInBottle] = true;
                Player.manaRegenBonus += 2; // +2 mana / second
            }
            if (Inf_Sunflower)
            {
                Player.buffImmune[BuffID.Sunflower] = true;
                Player.moveSpeed += 0.1f;
                Player.moveSpeed *= 1.1f;
                Player.sunflower = true;
            };
            if (Inf_Bast)
            {
                Player.buffImmune[BuffID.CatBast] = true;
                Player.statDefense += 5; // +5 defense
            }

            // Class buffs
            if (Inf_Sugar_Rush)
            {
                Player.buffImmune[BuffID.SugarRush] = true;
                Player.pickSpeed -= 0.2f;
                Player.moveSpeed += 0.2f;
            }
            // Melee
            if (Inf_Sharpened)
            {
                Player.buffImmune[BuffID.Sharpened] = true;
                Player.GetArmorPenetration(DamageClass.Melee) += 12f;
            }
            if (Inf_Ichor) Player.meleeEnchant = 5;
            if (Inf_Tipsy)
            {
                Player.buffImmune[BuffID.Tipsy] = true;
                Player.tipsy = true;
                //Player.statDefense -= 4; // Remove because will eventually end up reducing defense for non-melee classes as well
                Player.GetCritChance(DamageClass.Melee) += 2;
                Player.GetDamage(DamageClass.Melee) += 0.1f;
                Player.GetAttackSpeed(DamageClass.Melee) += 0.1f;
            }
            // Ranged
            if (Inf_Ammo_Box)
            {
                Player.buffImmune[BuffID.AmmoBox] = true;
                Player.ammoBox = true;
            }
            if (Inf_Ammo_Reservation)
            {
                Player.buffImmune[BuffID.AmmoReservation] = true;
                Player.ammoPotion = true;
            }
            if (Inf_Archery)
            {
                Player.buffImmune[BuffID.Archery] = true;
                Player.archery = true;
                Player.arrowDamage *= 1.2f;
            }
            // Magic
            if (Inf_Clairvoyance)
            {
                Player.buffImmune[BuffID.Clairvoyance] = true;
                Player.GetCritChance(DamageClass.Magic) += 2f;
                Player.GetDamage(DamageClass.Magic) += 0.05f;
                Player.statManaMax2 += 20;
                Player.manaCost -= 0.02f;
            }
            if (Inf_Magic_Power)
            {
                Player.buffImmune[BuffID.MagicPower] = true;
                Player.GetDamage(DamageClass.Magic) += 0.2f;
            }
            if (Inf_Mana_Regeneration) Player.manaRegenBuff = true;
            // Summon
            if (Inf_Bewitched)
            {
                Player.buffImmune[BuffID.Bewitched] = true;
                Player.maxMinions++;
            }
            if (Inf_Summoning)
            {
                Player.buffImmune[BuffID.Summoning] = true;
                Player.maxMinions++;
            }
            if (Inf_Strategist)
            {
                Player.buffImmune[BuffID.WarTable] = true;
                Player.maxTurrets++;
            }
            // Luck
            if (Inf_Lesser_Luck)
            {
                Player.buffImmune[BuffID.Lucky] = true;
                Player.luckPotion = 1;
            }
            if (Inf_Medium_Luck)
            {
                Player.buffImmune[BuffID.Lucky] = true;
                Player.luckPotion = 2;
            }
            if (Inf_Greater_Luck)
            {
                Player.buffImmune[BuffID.Lucky] = true;
                Player.luckPotion = 3;
            }
            if (Inf_Ladybug_Luck) Player.ladyBugLuckTimeLeft = 86400;
            if (Inf_Gnome_Luck)
            {
                //Player.HasGardenGnomeNearby = true;
                Main.SceneMetrics.HasGardenGnome = true;
                // This is simply reusing Terraria source code so the effect is indistinguishable from actually having a gnome
                // See Campfire for notes
            }
            if (Inf_Torch_Luck) Player.torchLuck = 1;
            // Exploration Buffs
            //  Aquatic Buffs
            if (Inf_Flipper)
            {
                Player.buffImmune[BuffID.Flipper] = true;
                Player.ignoreWater = true;
                Player.accFlipper = true;
            }
            if (Inf_Gills && infinitybottConfig.Toggle_Inf_Gills)
            {
                Player.buffImmune[BuffID.Gills] = true;
                Player.gills = true;
            }
            if (Inf_Water_Walking)
            {
                Player.buffImmune[BuffID.WaterWalking] = true;
                Player.waterWalk = true;
            }
            //  Fishing Buffs
            if (Inf_Crate && infinitybottConfig.Toggle_Inf_Crate)
            {
                Player.buffImmune[BuffID.Crate] = true;
                Player.cratePotion = true;
            }
            if (Inf_Fishing)
            {
                Player.buffImmune[BuffID.Fishing] = true;
                Player.fishingSkill += 15;
            }
            if (Inf_Sonar)
            {
                Player.buffImmune[BuffID.Sonar] = true;
                Player.sonarPotion = true;
            }
            //  Flight Buffs
            if (Inf_Featherfall)
            {
                Player.buffImmune[BuffID.Featherfall] = true;
                if (infinitybottConfig.Toggle_Inf_Featherfall) Player.slowFall = true;
            }
            if (Inf_Gravitation)
            {
                Player.buffImmune[BuffID.Gravitation] = true;
                if (infinitybottConfig.Toggle_Inf_Gravitation) Player.gravControl = true;
            }
            //  Gathering Buffs
            if (Inf_Builder)
            {
                Player.buffImmune[BuffID.Builder] = true;
                Player.tileSpeed += 0.25f;
                Player.wallSpeed += 0.25f;
                Player.blockRange++;
            }
            if (Inf_Mining)
            {
                Player.buffImmune[BuffID.Mining] = true;
                Player.pickSpeed -= 0.25f;
            }
            if (Inf_Obsidian_Skin)
            {
                Player.buffImmune[BuffID.ObsidianSkin] = true;
                Player.lavaImmune = true;
                Player.fireWalk = true;
                Player.buffImmune[24] = true;
            }
            if (Inf_Spelunker)
            {
                Player.buffImmune[BuffID.Spelunker] = true;
                Player.findTreasure = true;
            }
            //  Visual Buffs
            if (Inf_Dangersense)
            {
                Player.buffImmune[BuffID.Dangersense] = true;
                Player.dangerSense = true;
            }
            if (Inf_Hunter)
            {
                Player.buffImmune[BuffID.Hunter] = true;
                Player.detectCreature = true;
            }
            if (Inf_Invisibility)
            {
                Player.buffImmune[BuffID.Invisibility] = true;
                if (infinitybottConfig.Toggle_Inf_Invisibility) Player.invis = true;
            }
            if (Inf_Night_Owl)
            {
                Player.buffImmune[BuffID.NightOwl] = true;
                Player.nightVision = true;
            }
            if (Inf_Shine)
            {
                Player.buffImmune[BuffID.Shine] = true;
                Lighting.AddLight((int)(Player.position.X + (float)(Player.width / 2)) / 16, (int)(Player.position.Y + (float)(Player.height / 2)) / 16, 0.8f, 0.95f, 1f);
            }
            // Combat Buffs
            //  Offensive Buffs
            if (Inf_Inferno)
            {
                Player.buffImmune[BuffID.Inferno] = true;
                if (infinitybottConfig.Toggle_Inf_Inferno) InfinitybottInfernoEffect(); // this is really long in the source code so I just included it as its own function. Added a couple edits so it works in the mod and so the visual is toggleable
            }
            if (Inf_Rage)
            {
                Player.buffImmune[BuffID.Rage] = true;
                Player.GetCritChance(DamageClass.Generic) += 10f;
            }
            if (Inf_Titan)
            {
                Player.buffImmune[BuffID.Titan] = true;
                Player.kbBuff = true;
            }
            if (Inf_Wrath)
            {
                Player.buffImmune[BuffID.Wrath] = true;
                Player.GetDamage(DamageClass.Generic) += 0.1f;
            }
            //  Defensive Buffs
            if (Inf_Endurance)
            {
                Player.buffImmune[BuffID.Endurance] = true;
                Player.endurance += 0.1f;
            }
            if (Inf_Heartreach)
            {
                Player.buffImmune[BuffID.Heartreach] = true;
                Player.lifeMagnet = true;
            }
            if (Inf_Lifeforce)
            {
                Player.buffImmune[BuffID.Lifeforce] = true;
                Player.lifeForce = true;
                Player.statLifeMax2 += Player.statLifeMax / 5 / 20 * 20;
            }
            if (Inf_Thorns)
            {
                Player.buffImmune[BuffID.Thorns] = true;
                if (Player.thorns < 1f)
                {
                    Player.thorns = 1f;
                }
            }
            if (Inf_Warmth)
            {
                Player.buffImmune[BuffID.Warmth] = true;
                Player.resistCold = true;
            }
            // Spawn Rate Modifiers
            // Found in SpawnRateModifier.cs

        }
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (infinitybott.Recall.JustPressed && Inf_Recall)
            {
                Player.RemoveAllGrapplingHooks();
                ReturnLocation = Player.position;
                ReturnAvailable = true;
                Player.Spawn(PlayerSpawnContext.RecallFromItem);
                Player.Teleport(Player.position); // This is just to get the teleport sound and visual effects,
                                                  // because i'm lazy and don't feel like researching and including all the code for it
            }
            if (infinitybott.Return.JustPressed && ReturnAvailable && Inf_Return)
            {
                Player.RemoveAllGrapplingHooks();
                ReturnAvailable = false;
                Player.Teleport(ReturnLocation);
            }
            if (infinitybott.Teleportation.JustPressed && Inf_Teleportation)
            {
                Player.TeleportationPotion();
            }

            if (infinitybott.Peace.JustPressed)
            {
                if (Toggle_Peace) Main.NewText("Peace turned off", 0, 255, 255);
                else Main.NewText("Peace turned on", 0, 255, 255);
                Toggle_Peace = !Toggle_Peace;
            }

            if (infinitybott.War.JustPressed)
            {
                if (Toggle_War) Main.NewText("War turned off", 255, 0, 0);
                else Main.NewText("War turned on (Always overrides Peace)", 255, 0, 0);
                Toggle_War = !Toggle_War;
            }

        }
    }
}
