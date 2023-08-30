using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace infinitybott.Content.Items.InfiniteBuffs.ClassBuffs.MagicBuffs
{
    internal class InfMagicBuffs : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Infinite Magic Buffs");
            Tooltip.SetDefault("Infinite Clairvoyance, Magic Power, and Mana Regeneration\n-Hoho");
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
                .AddIngredient(ModContent.ItemType<InfClairvoyance>(), 1)
                .AddIngredient(ModContent.ItemType<InfMagicPower>(), 1)
                .AddIngredient(ModContent.ItemType<InfManaRegeneration>(), 1)
                .Register();

        }

        public override void UpdateInventory(Player player)
        {
            InfinitybottPlayer modPlayer = player.GetModPlayer<InfinitybottPlayer>();
            modPlayer.UseMagicBuffs();
        }

    }
}
