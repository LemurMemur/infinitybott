<<<<<<< HEAD:Content/Items/InfiniteBuffs/CombatBuffs/OffensiveBuffs/InfOffensiveBuffs.cs
﻿using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace infinitybott.Content.Items.InfiniteBuffs.CombatBuffs.OffensiveBuffs
{
    internal class InfOffensiveBuffs : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Infinite Offensive Buffs");
            // Tooltip.SetDefault("Infinite Inferno, Rage, Titan, and Wrath buffs\n-Hoho");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.value = Item.buyPrice(0);
            Item.maxStack = 1;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<OffensiveBuffs.InfInferno>(), 1)
                .AddIngredient(ModContent.ItemType<OffensiveBuffs.InfRage>(), 1)
                .AddIngredient(ModContent.ItemType<OffensiveBuffs.InfTitan>(), 1)
                .AddIngredient(ModContent.ItemType<OffensiveBuffs.InfWrath>(), 1)
                .Register();

        }

        public override void UpdateInventory(Player player)
        {
            InfinitybottPlayer modPlayer = player.GetModPlayer<InfinitybottPlayer>();
            modPlayer.UseOffensiveBuffs();
        }

    }
}
=======
﻿using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace infinitybott.Content.Items.InfiniteBuffs.CombatBuffs.OffensiveBuffs
{
    internal class InfOffensiveBuffs : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Infinite Offensive Buffs");
            Tooltip.SetDefault("Infinite Inferno, Rage, Titan, and Wrath buffs\n-Hoho");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.value = Item.buyPrice(0);
            Item.maxStack = 1;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<OffensiveBuffs.InfInferno>(), 1)
                .AddIngredient(ModContent.ItemType<OffensiveBuffs.InfRage>(), 1)
                .AddIngredient(ModContent.ItemType<OffensiveBuffs.InfTitan>(), 1)
                .AddIngredient(ModContent.ItemType<OffensiveBuffs.InfWrath>(), 1)
                .Register();

        }

        public override void UpdateInventory(Player player)
        {
            InfinitybottPlayer modPlayer = player.GetModPlayer<InfinitybottPlayer>();
            modPlayer.UseOffensiveBuffs();
        }

    }
}
>>>>>>> parent of e8c7be1 (Merge pull request #2 from LemurMemur/Legacy-tModLoader-1.4.3.6---infinitybott-1.0.4):CombatBuffs/OffensiveBuffs/InfOffensiveBuffs.cs
