using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace infinitybott.Content.Items.InfiniteBuffs.LuckBuffs
{
    internal class InfMediumLuck : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Infinite Medium Luck Buff");
            Tooltip.SetDefault("+0.2 Luck\n-Hoho");
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
                .AddIngredient(ItemID.LuckPotion, 5)
                .AddIngredient(ModContent.ItemType<InfLesserLuck>(), 1)
                .Register();

        }

        public override void UpdateInventory(Player player)
        {
            InfinitybottPlayer modPlayer = player.GetModPlayer<InfinitybottPlayer>();
            modPlayer.Inf_Medium_Luck = true;
        }

    }
}
