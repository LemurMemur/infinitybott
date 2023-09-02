using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace infinitybott.Content.Items.InfiniteBuffs.ExplorationBuffs.GatheringBuffs
{
    internal class InfGatheringBuffs : ModItem
    {
        public override void SetStaticDefaults() 
        {
            // DisplayName.SetDefault("Infinite Gathering Buffs");
            // Tooltip.SetDefault("Infinite Builder, Mining, Obsidian Skin, and Spelunker\n-Hoho");
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
                .AddIngredient(ModContent.ItemType<InfBuilder>(), 1)
                .AddIngredient(ModContent.ItemType<InfMining>(), 1)
                .AddIngredient(ModContent.ItemType<InfObsidianSkin>(), 1)
                .AddIngredient(ModContent.ItemType<InfSpelunker>(), 1)
                .Register();

        }

        public override void UpdateInventory(Player player)
        {
            InfinitybottPlayer modPlayer = player.GetModPlayer<InfinitybottPlayer>();
            modPlayer.UseGatheringBuffs();
        }

    }
}
