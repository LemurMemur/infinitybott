<<<<<<< HEAD:Content/Items/InfiniteBuffs/ArenaBuffs/InfBast.cs
﻿using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace infinitybott.Content.Items.InfiniteBuffs.ArenaBuffs
{
    internal class InfBast : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Infinite Bast Statue Buff");
            // Tooltip.SetDefault("+5 Defense\n-Hoho");
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
                .AddIngredient(ItemID.CatBast, 2)
                .Register();

        }

        public override void UpdateInventory(Player player)
        {
            InfinitybottPlayer modPlayer = player.GetModPlayer<InfinitybottPlayer>();
            modPlayer.Inf_Bast = true;
        }

    }
}
=======
﻿using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace infinitybott.Content.Items.InfiniteBuffs.ArenaBuffs
{
    internal class InfBast : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Infinite Bast Statue Buff");
            Tooltip.SetDefault("+5 Defense\n-Hoho");
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
                .AddIngredient(ItemID.CatBast, 2)
                .Register();

        }

        public override void UpdateInventory(Player player)
        {
            InfinitybottPlayer modPlayer = player.GetModPlayer<InfinitybottPlayer>();
            modPlayer.Inf_Bast = true;
        }

    }
}
>>>>>>> parent of e8c7be1 (Merge pull request #2 from LemurMemur/Legacy-tModLoader-1.4.3.6---infinitybott-1.0.4):ArenaBuffs/InfBast.cs
