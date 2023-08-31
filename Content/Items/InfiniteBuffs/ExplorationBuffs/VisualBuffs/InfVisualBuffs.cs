using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace infinitybott.Content.Items.InfiniteBuffs.ExplorationBuffs.VisualBuffs
{
    internal class InfVisualBuffs : ModItem
    {
        public override void SetStaticDefaults() 
        {
            DisplayName.SetDefault("Infinite Visual Buffs");
            Tooltip.SetDefault("Infinite Dangersense, Hunter, Invisibility, Night Owl, and Shine\n-Hoho");
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
                .AddIngredient(ModContent.ItemType<InfDangersense>(), 1)
                .AddIngredient(ModContent.ItemType<InfHunter>(), 1)
                .AddIngredient(ModContent.ItemType<InfInvisibility>(), 1)
                .AddIngredient(ModContent.ItemType<InfNightOwl>(), 1)
                .AddIngredient(ModContent.ItemType<InfShine>(), 1)
                .Register();

        }

        public override void UpdateInventory(Player player)
        {
            InfinitybottPlayer modPlayer = player.GetModPlayer<InfinitybottPlayer>();
            modPlayer.UseVisualBuffs();
        }

    }
}
