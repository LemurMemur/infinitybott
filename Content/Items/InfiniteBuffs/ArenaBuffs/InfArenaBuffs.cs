using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace infinitybott.Content.Items.InfiniteBuffs.ArenaBuffs
{
    [Autoload(false)]
    internal class InfArenaBuffs : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Infinite Arena Buffs");
            Tooltip.SetDefault("Infinite Campfire, Heart Lantern, Honey, Star in a Bottle, Sunflower, Bast Statue\n-Hoho");
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
                .AddIngredient(ModContent.ItemType<InfCampfire>(), 1)
                .AddIngredient(ModContent.ItemType<InfHeartLantern>(), 1)
                .AddIngredient(ModContent.ItemType<InfHoney>(), 1)
                .AddIngredient(ModContent.ItemType<InfStarBottle>(), 1)
                .AddIngredient(ModContent.ItemType<InfSunflower>(), 1)
                .AddIngredient(ModContent.ItemType<InfBast>(), 1)
                .Register();

        }

        public override void UpdateInventory(Player player)
        {
            InfinitybottPlayer modPlayer = player.GetModPlayer<InfinitybottPlayer>();
            modPlayer.UseArenaBuffs();
        }

    }
}
