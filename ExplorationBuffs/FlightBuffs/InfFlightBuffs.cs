using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace infinitybott.Content.Items.InfiniteBuffs.ExplorationBuffs.FlightBuffs
{
    internal class InfFlightBuffs : ModItem
    {
        public override void SetStaticDefaults() 
        {
            // DisplayName.SetDefault("Infinite Flight Buffs");
            // Tooltip.SetDefault("Infinite Featherfall and Gravitation\n-Hoho");
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
                .AddIngredient(ModContent.ItemType<InfFeatherfall>(), 1)
                .AddIngredient(ModContent.ItemType<InfGravitation>(), 1)
                .Register();

        }

        public override void UpdateInventory(Player player)
        {
            InfinitybottPlayer modPlayer = player.GetModPlayer<InfinitybottPlayer>();
            modPlayer.UseFlightBuffs();
        }

    }
}
