using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Placeable
{
    public class Lycoris : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Plants of hell'");
        }

        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 12;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 0;
            item.createTile = mod.TileType("Lycoris");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.Bottles);
            recipe.AddIngredient(null, "ObsidiumPlant");
            recipe.SetResult(this, 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.Hellforge);
            recipe.AddIngredient(null, "LavaGem");
            recipe.AddIngredient(null, "ObsidiumRock", 4);
            recipe.SetResult(null, "Lycoris", 4);
            recipe.AddRecipe();
        }
    }
}