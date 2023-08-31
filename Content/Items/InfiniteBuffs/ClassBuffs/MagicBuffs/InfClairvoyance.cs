<<<<<<< HEAD:Content/Items/InfiniteBuffs/ClassBuffs/MagicBuffs/InfClairvoyance.cs
﻿using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace infinitybott.Content.Items.InfiniteBuffs.ClassBuffs.MagicBuffs
{
    internal class InfClairvoyance : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Infinite Clairvoyance Buff");
            // Tooltip.SetDefault("+20 maximum Mana\n+5% Magic damage\n+2% Magic critical strike chance\n-2% Mana usage\n-Hoho");
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
                .AddIngredient(ItemID.CrystalBall, 2)
                .Register();

        }

        public override void UpdateInventory(Player player)
        {
            InfinitybottPlayer modPlayer = player.GetModPlayer<InfinitybottPlayer>();
            modPlayer.Inf_Clairvoyance = true;
        }

    }
}
=======
﻿using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace infinitybott.Content.Items.InfiniteBuffs.ClassBuffs.MagicBuffs
{
    internal class InfClairvoyance : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Infinite Clairvoyance Buff");
            Tooltip.SetDefault("+20 maximum Mana\n+5% Magic damage\n+2% Magic critical strike chance\n-2% Mana usage\n-Hoho");
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
                .AddIngredient(ItemID.CrystalBall, 2)
                .Register();

        }

        public override void UpdateInventory(Player player)
        {
            InfinitybottPlayer modPlayer = player.GetModPlayer<InfinitybottPlayer>();
            modPlayer.Inf_Clairvoyance = true;
        }

    }
}
>>>>>>> parent of e8c7be1 (Merge pull request #2 from LemurMemur/Legacy-tModLoader-1.4.3.6---infinitybott-1.0.4):ClassBuffs/MagicBuffs/InfClairvoyance.cs
