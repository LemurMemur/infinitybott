using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace infinitybott.Content.Items.InfiniteBuffs
{
    [Autoload(false)]
    internal class InfAllBuffs : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("All Buffs");
            // Tooltip.SetDefault("Grants all vanilla buffs\n\"LFG!\"\n-Hoho");
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
                .AddIngredient(ModContent.ItemType<BasicBuffs.InfBasicBuffs>(), 1)
                .AddIngredient(ModContent.ItemType<ClassBuffs.InfClassBuffs>(), 1)
                .AddIngredient(ModContent.ItemType<ArenaBuffs.InfArenaBuffs>(), 1)
                .AddIngredient(ModContent.ItemType<ExplorationBuffs.InfExplorationBuffs>(), 1)
                .AddIngredient(ModContent.ItemType<TravelBuffs.InfTravelBuffs>(), 1)
                .AddIngredient(ModContent.ItemType<SpawningBuffs.InfSpawningBuffs>(), 1)
                .AddIngredient(ModContent.ItemType<CombatBuffs.InfCombatBuffs>(), 1)
                .AddIngredient(ModContent.ItemType<LuckBuffs.InfLuckBuffs>(), 1)
                .Register();

        }

        public override void UpdateInventory(Player player)
        {
            InfinitybottPlayer modPlayer = player.GetModPlayer<InfinitybottPlayer>();
            modPlayer.UseAllBuffs();
        }

    }
}
