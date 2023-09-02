using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace infinitybott.Content.Items.InfiniteBuffs.CombatBuffs.DefensiveBuffs
{
    internal class InfDefensiveBuffs : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Infinite Defensive Buffs");
            // Tooltip.SetDefault("Infinite Endurance, Heartreach, Lifeforce, Thorns, and Warmth buffs\n-Hoho");
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
                .AddIngredient(ModContent.ItemType<DefensiveBuffs.InfEndurance>(), 1)
                .AddIngredient(ModContent.ItemType<DefensiveBuffs.InfHeartreach>(), 1)
                .AddIngredient(ModContent.ItemType<DefensiveBuffs.InfLifeforce>(), 1)
                .AddIngredient(ModContent.ItemType<DefensiveBuffs.InfThorns>(), 1)
                .AddIngredient(ModContent.ItemType<DefensiveBuffs.InfWarmth>(), 1)
                .Register();

        }

        public override void UpdateInventory(Player player)
        {
            InfinitybottPlayer modPlayer = player.GetModPlayer<InfinitybottPlayer>();
            modPlayer.UseDefensiveBuffs();
        }

    }
}
