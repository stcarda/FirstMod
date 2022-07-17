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
            Item.damage = 100;
            Item.knockBack = 6;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;

            // Set the hold style.
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shoot = 3;

            // Set the properties of the animation.
            Item.useTime = 20;
            Item.useAnimation = 20;

            // Hitbox properties.
            Item.height = 5;
            Item.width = 5;
            Item.autoReuse = true;
        }
    }
}
