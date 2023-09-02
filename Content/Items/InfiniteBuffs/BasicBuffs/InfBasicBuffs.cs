using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace infinitybott.Content.Items.InfiniteBuffs.BasicBuffs
{
    [Autoload(false)]
    internal class InfBasicBuffs : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Infinite Basic Buffs");
            // Tooltip.SetDefault("Infinite Ironskin, Swiftness, Regeneration, and Exquisitely Stuffed\n-Hoho");
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
                .AddIngredient(ModContent.ItemType<InfIronskin>(), 1)
                .AddIngredient(ModContent.ItemType<InfSwiftness>(), 1)
                .AddIngredient(ModContent.ItemType<InfRegeneration>(), 1)
                .AddIngredient(ModContent.ItemType<InfStuffed>(), 1)
                .Register();

        }

        public override void UpdateInventory(Player player)
        {
            InfinitybottPlayer modPlayer = player.GetModPlayer<InfinitybottPlayer>();
            modPlayer.UseBasicBuffs();
        }

    }
}
