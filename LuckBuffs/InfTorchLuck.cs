using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace infinitybott.Content.Items.InfiniteBuffs.LuckBuffs
{
    internal class InfTorchLuck : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Infinite Torch Luck Buff");
            // Tooltip.SetDefault("+0.2 Luck\n-Hoho");
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
                .AddIngredient(ItemID.BoneTorch, 30)
                .AddIngredient(ItemID.DesertTorch, 30)
                .AddIngredient(ItemID.JungleTorch, 30)
                .AddIngredient(ItemID.IceTorch, 30)
                .AddIngredient(ItemID.HallowedTorch, 30)
                .AddIngredient(ItemID.CrimsonTorch, 30)
                .Register();
            CreateRecipe()
                .AddIngredient(ItemID.BoneTorch, 30)
                .AddIngredient(ItemID.DesertTorch, 30)
                .AddIngredient(ItemID.JungleTorch, 30)
                .AddIngredient(ItemID.IceTorch, 30)
                .AddIngredient(ItemID.HallowedTorch, 30)
                .AddIngredient(ItemID.CorruptTorch, 30)
                .Register();

        }

        public override void UpdateInventory(Player player)
        {
            InfinitybottPlayer modPlayer = player.GetModPlayer<InfinitybottPlayer>();
            modPlayer.Inf_Torch_Luck = true;
        }

    }
}
