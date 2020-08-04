using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using System.Linq;


namespace WILDLANDS
{
    public class ModNameWorld : ModWorld
    {

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int genIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if (genIndex == -1)
            {
                return;
            }
            tasks.Insert(genIndex + 1, new PassLegacy("Custom Biome", delegate (GenerationProgress progress)
            {
                progress.Message = "Custom Biome Progress";
                for (int i = 0; i < Main.maxTilesX / 600; i++)       //600 is how many blocks. the bigger is the number = less biomes
                {
                    int X = WorldGen.genRand.Next(1, Main.maxTilesX - 300);
                    int Y = WorldGen.genRand.Next((int)WorldGen.rockLayer - 100, Main.maxTilesY - 200);
                    int TileType = mod.TileType("Tiles_0.png");     //this is the tile u want to use for the biome , if u want to use a vanilla tile then its int TileType = 56; 56 is obsidian block

                    WorldGen.TileRunner(X, Y, 350, WorldGen.genRand.Next(100, 200), TileType, false, 0f, 0f, true, true);  //350 is how big is the biome     100, 200 this changes how random it looks.
                    for (int k = 0; k < 750; k++)                     //750 is the ore spawn rate. the bigger is the number = more ore spawns
                    {
                        int Xo = X + Main.rand.Next(-240, 240);
                        int Yo = Y + Main.rand.Next(-240, 240);
                        if (Main.tile[Xo, Yo].type == mod.TileType("Tiles_0.png"))   //this is the tile where the ore will spawn
                        {

                            {
                                WorldGen.TileRunner(Xo, Yo, (double)WorldGen.genRand.Next(5, 10), WorldGen.genRand.Next(5, 10), mod.TileType("CustomOreTile"), false, 0f, 0f, false, true);  //   5, 10 is how big is the ore veins.    mod.TileType("CustomOreTile") is the custom ore tile,  if u want a vanila ore just do this: TileID.Cobalt, for cobalt spawn
                            }
                        }
                    }
                }

            }));
        }
    }
}