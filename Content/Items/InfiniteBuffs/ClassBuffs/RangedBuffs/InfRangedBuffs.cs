<<<<<<< HEAD:Content/Items/InfiniteBuffs/ClassBuffs/RangedBuffs/InfRangedBuffs.cs
﻿using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace infinitybott.Content.Items.InfiniteBuffs.ClassBuffs.RangedBuffs
{
    internal class InfRangedBuffs : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Infinite Ranged Buffs");
            // Tooltip.SetDefault("Infinite Ammo Box, Ammo Reservation, and Archery\n-Hoho");
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
                .AddIngredient(ModContent.ItemType<InfAmmoBox>(), 1)
                .AddIngredient(ModContent.ItemType<InfAmmoReservation>(), 1)
                .AddIngredient(ModContent.ItemType<InfArchery>(), 1)
                .Register();

        }

        public override void UpdateInventory(Player player)
        {
            InfinitybottPlayer modPlayer = player.GetModPlayer<InfinitybottPlayer>();
            modPlayer.UseRangedBuffs();
        }

    }
}
=======
﻿using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace infinitybott.Content.Items.InfiniteBuffs.ClassBuffs.RangedBuffs
{
    internal class InfRangedBuffs : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Infinite Ranged Buffs");
            Tooltip.SetDefault("Infinite Ammo Box, Ammo Reservation, and Archery\n-Hoho");
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
                .AddIngredient(ModContent.ItemType<InfAmmoBox>(), 1)
                .AddIngredient(ModContent.ItemType<InfAmmoReservation>(), 1)
                .AddIngredient(ModContent.ItemType<InfArchery>(), 1)
                .Register();

        }

        public override void UpdateInventory(Player player)
        {
            InfinitybottPlayer modPlayer = player.GetModPlayer<InfinitybottPlayer>();
            modPlayer.UseRangedBuffs();
        }

    }
}
>>>>>>> parent of e8c7be1 (Merge pull request #2 from LemurMemur/Legacy-tModLoader-1.4.3.6---infinitybott-1.0.4):ClassBuffs/RangedBuffs/InfRangedBuffs.cs
