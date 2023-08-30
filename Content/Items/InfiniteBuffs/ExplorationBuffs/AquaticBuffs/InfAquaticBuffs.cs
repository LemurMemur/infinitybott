using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace infinitybott.Content.Items.InfiniteBuffs.ExplorationBuffs.AquaticBuffs
{
    internal class InfAquaticBuffs : ModItem
    {
        public override void SetStaticDefaults() 
        {
            DisplayName.SetDefault("Infinite Aquatic Buffs");
            Tooltip.SetDefault("Infinite Flipper, Gills, and Water Walking\n-Hoho");
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
                .AddIngredient(ModContent.ItemType<InfFlipper>(), 1)
                .AddIngredient(ModContent.ItemType<InfGills>(), 1)
                .AddIngredient(ModContent.ItemType<InfWaterWalking>(), 1)
                .Register();

        }

        public override void UpdateInventory(Player player)
        {
            InfinitybottPlayer modPlayer = player.GetModPlayer<InfinitybottPlayer>();
            modPlayer.UseAquaticBuffs();
        }

    }
}
