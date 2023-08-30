using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace infinitybott.Content.Items.InfiniteBuffs.ExplorationBuffs.FishingBuffs
{
    internal class InfFishingBuffs : ModItem
    {
        public override void SetStaticDefaults() 
        {
            DisplayName.SetDefault("Infinite Fishing Buffs");
            Tooltip.SetDefault("Infinite Crate, Fishing, and Sonar\n-Hoho");
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
                .AddIngredient(ModContent.ItemType<InfCrate>(), 1)
                .AddIngredient(ModContent.ItemType<InfFishing>(), 1)
                .AddIngredient(ModContent.ItemType<InfSonar>(), 1)
                .Register();

        }

        public override void UpdateInventory(Player player)
        {
            InfinitybottPlayer modPlayer = player.GetModPlayer<InfinitybottPlayer>();
            modPlayer.UseFishingBuffs();
        }

    }
}
