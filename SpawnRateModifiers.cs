using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace infinitybott
{
	public class SpawnRateModifier : GlobalNPC
	{
		public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
		{
            InfinitybottPlayer modPlayer = player.GetModPlayer<InfinitybottPlayer>();
            
            if (modPlayer.Toggle_War)
            {
                if (modPlayer.Inf_Ult_War)
                {
                    spawnRate /= 100;
                    maxSpawns *= 20;
                }
                else
                {
                    if (modPlayer.Inf_Battle)
                    {
                        spawnRate = (int)((float)spawnRate * 0.5);
                        maxSpawns = (int)((float)maxSpawns * 2f);
                    }
                    if (modPlayer.Inf_Water_Candle)
                    {
                        spawnRate = (int)((double)spawnRate * 0.75);
                        maxSpawns = (int)((float)maxSpawns * 1.5f);
                    }
                }
            }
            else if (modPlayer.Toggle_Peace)
            {
                if (modPlayer.Inf_Ult_Peace)
                {
                    maxSpawns = 0;
                }
                else
                {
                    if (modPlayer.Inf_Calm)
                    {
                        spawnRate = (int)((float)spawnRate * 1.3f);
                        maxSpawns = (int)((float)maxSpawns * 0.7f);
                    }
                    if (modPlayer.Inf_Peace_Candle)
                    {
                        spawnRate = (int)((double)spawnRate * 1.3);
                        maxSpawns = (int)((float)maxSpawns * 0.7f);
                    }
                }
            }
            
        }
    }

}
