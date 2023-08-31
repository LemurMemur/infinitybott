<<<<<<< HEAD:Content/Items/InfiniteBuffs/BasicBuffs/InfStuffed.cs
﻿using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace infinitybott.Content.Items.InfiniteBuffs.BasicBuffs
{
    internal class InfStuffed : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Infinite Exquisitely Stuffed");
            // Tooltip.SetDefault("Exquisitely Stuffed Buff\nDoes not stack with other Food Buffs\nFull details on Terraria wiki\n-Hoho");
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
                .AddIngredient(ItemID.SeafoodDinner, 30)
                .AddIngredient(ModContent.ItemType<InfSatisfied>(), 1)
                .Register();

        }

        public override void UpdateInventory(Player player)
        {
            InfinitybottPlayer modPlayer = player.GetModPlayer<InfinitybottPlayer>();
            modPlayer.Inf_Stuffed = true;
        }

    }
}
=======
﻿using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace infinitybott.Content.Items.InfiniteBuffs.BasicBuffs
{
    internal class InfStuffed : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Infinite Exquisitely Stuffed");
            Tooltip.SetDefault("Exquisitely Stuffed Buff\nDoes not stack with other Food Buffs\nFull details on Terraria wiki\n-Hoho");
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
                .AddIngredient(ItemID.SeafoodDinner, 30)
                .AddIngredient(ModContent.ItemType<InfSatisfied>(), 1)
                .Register();

        }

        public override void UpdateInventory(Player player)
        {
            InfinitybottPlayer modPlayer = player.GetModPlayer<InfinitybottPlayer>();
            modPlayer.Inf_Stuffed = true;
        }

    }
}
>>>>>>> parent of e8c7be1 (Merge pull request #2 from LemurMemur/Legacy-tModLoader-1.4.3.6---infinitybott-1.0.4):BasicBuffs/InfStuffed.cs
