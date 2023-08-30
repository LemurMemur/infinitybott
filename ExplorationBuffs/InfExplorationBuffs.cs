using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace infinitybott.Content.Items.InfiniteBuffs.ExplorationBuffs
{
    [Autoload(false)]
    internal class InfExplorationBuffs : ModItem
    {
        public override void SetStaticDefaults() 
        {
            // DisplayName.SetDefault("Infinite Exploration Buffs");
            // Tooltip.SetDefault("Infinite Aquatic, Fishing, Flight, Gathering, and Visual\n-Hoho");
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
                .AddIngredient(ModContent.ItemType<AquaticBuffs.InfAquaticBuffs>(), 1)
                .AddIngredient(ModContent.ItemType<FishingBuffs.InfFishingBuffs>(), 1)
                .AddIngredient(ModContent.ItemType<FlightBuffs.InfFlightBuffs>(), 1)
                .AddIngredient(ModContent.ItemType<GatheringBuffs.InfGatheringBuffs>(), 1)
                .AddIngredient(ModContent.ItemType<VisualBuffs.InfVisualBuffs>(), 1)
                .Register();

        }

        public override void UpdateInventory(Player player)
        {
            InfinitybottPlayer modPlayer = player.GetModPlayer<InfinitybottPlayer>();
            modPlayer.UseExplorationBuffs();
        }

    }
}
