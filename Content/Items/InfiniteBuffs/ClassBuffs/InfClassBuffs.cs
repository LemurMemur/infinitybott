using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace infinitybott.Content.Items.InfiniteBuffs.ClassBuffs
{
    [Autoload(false)]
    internal class InfClassBuffs : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Infinite Class-Specific Buffs");
            // Tooltip.SetDefault("Class specific potion and station buffs for Melee, Ranged, Magic, and Summon classes.\nAlso comes with cake!\n-Hoho");
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
                .AddIngredient(ModContent.ItemType<MeleeBuffs.InfMeleeBuffs>(), 1)
                .AddIngredient(ModContent.ItemType<RangedBuffs.InfRangedBuffs>(), 1)
                .AddIngredient(ModContent.ItemType<MagicBuffs.InfMagicBuffs>(), 1)
                .AddIngredient(ModContent.ItemType<SummonBuffs.InfSummonBuffs>(), 1)
                .AddIngredient(ModContent.ItemType<InfSugarRush>(), 1)
                .Register();

        }

        public override void UpdateInventory(Player player)
        {
            InfinitybottPlayer modPlayer = player.GetModPlayer<InfinitybottPlayer>();
            modPlayer.UseClassBuffs();
        }

    }
}
