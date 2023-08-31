<<<<<<< HEAD:Content/Items/InfiniteBuffs/CombatBuffs/InfCombatBuffs.cs
﻿using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace infinitybott.Content.Items.InfiniteBuffs.CombatBuffs
{
    [Autoload(false)]
    internal class InfCombatBuffs : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Infinite Combat Buffs");
            // Tooltip.SetDefault("General offensive and defensive buffs\n-Hoho");
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
                .AddIngredient(ModContent.ItemType<OffensiveBuffs.InfOffensiveBuffs>(), 1)
                .AddIngredient(ModContent.ItemType<DefensiveBuffs.InfDefensiveBuffs>(), 1)
                .Register();

        }

        public override void UpdateInventory(Player player)
        {
            InfinitybottPlayer modPlayer = player.GetModPlayer<InfinitybottPlayer>();
            modPlayer.UseCombatBuffs();
        }

    }
}
=======
﻿using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace infinitybott.Content.Items.InfiniteBuffs.CombatBuffs
{
    [Autoload(false)]
    internal class InfCombatBuffs : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Infinite Combat Buffs");
            Tooltip.SetDefault("General offensive and defensive buffs\n-Hoho");
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
                .AddIngredient(ModContent.ItemType<OffensiveBuffs.InfOffensiveBuffs>(), 1)
                .AddIngredient(ModContent.ItemType<DefensiveBuffs.InfDefensiveBuffs>(), 1)
                .Register();

        }

        public override void UpdateInventory(Player player)
        {
            InfinitybottPlayer modPlayer = player.GetModPlayer<InfinitybottPlayer>();
            modPlayer.UseCombatBuffs();
        }

    }
}
>>>>>>> parent of e8c7be1 (Merge pull request #2 from LemurMemur/Legacy-tModLoader-1.4.3.6---infinitybott-1.0.4):CombatBuffs/InfCombatBuffs.cs
