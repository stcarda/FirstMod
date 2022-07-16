using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

// This is a weapon from the mod FirstMod.
namespace FirstMod.Content.Items.Weapons
{
    class BGS_shoot : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Set the name of the item that is seen in-game.
            DisplayName.SetDefault("True Daemon's Blood Greatsword");

            // Provide a short description of the item.
            Tooltip.SetDefault("Blood-blessed Daemon's Blood Greatsword, true bane of Ludwig's faith...");
        }
        public override void SetDefaults()
        {
            // Set the weapon behavior properties.
            item.damage = 100;
            item.knockBack = 6;
            item.melee = true;

            // Set the hold style.
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.shoot = true;

            // Set the properties of the animation.
            item.useTime = 20;
            item.useAnimation = 20;

            // Hitbox properties.
            item.height = 5;
            item.width = 5;
            item.autoReuse = true;
        }
    }
}
