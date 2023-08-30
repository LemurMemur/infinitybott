using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace infinitybott.Content.Items.InfiniteBuffs.TravelBuffs
{
    internal class InfReturn : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Infinite Return");
            Tooltip.SetDefault("Recall, with the option to return once\nBoth must be bound to keys to use\n-Hoho");
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
                .AddIngredient(ItemID.PotionOfReturn, 30)
                .AddIngredient(ModContent.ItemType<InfRecall>(), 1)
                .Register();

        }

        public override void UpdateInventory(Player player)
        {
            InfinitybottPlayer modPlayer = player.GetModPlayer<InfinitybottPlayer>();
            modPlayer.Inf_Recall = true;
            modPlayer.Inf_Return = true;
        }

    }
}
