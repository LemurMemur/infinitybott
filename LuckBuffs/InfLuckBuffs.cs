using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace infinitybott.Content.Items.InfiniteBuffs.LuckBuffs
{
    [Autoload(false)]
    internal class InfLuckBuffs : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Infinite Luck Buffs");
            // Tooltip.SetDefault("+1.1 Luck\n-Hoho");
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
                .AddIngredient(ModContent.ItemType<InfGreaterLuck>(), 1)
                .AddIngredient(ModContent.ItemType<InfGnomeBuff>(), 1)
                .AddIngredient(ModContent.ItemType<InfLadybugLuck>(), 1)
                .AddIngredient(ModContent.ItemType<InfTorchLuck>(), 1)
                .Register();

        }

        public override void UpdateInventory(Player player)
        {
            InfinitybottPlayer modPlayer = player.GetModPlayer<InfinitybottPlayer>();
            modPlayer.UseLuckBuffs();
        }

    }
}
