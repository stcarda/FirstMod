using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using FirstMod.Content.Projectiles;

// This is a weapon from the mod FirstMod.
namespace FirstMod.Content.Items.Weapons
{
    class LudwigsGreatsword : ModItem
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
            Item.DamageType = DamageClass.Melee;

            // Set the hold style.
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shoot = ModContent.ProjectileType<LudwigProj>();

            // Set the properties of the animation.
            Item.useTime = 20;
            Item.useAnimation = 20;

            // Hitbox properties.
            Item.height = 5;
            Item.width = 5;
            Item.autoReuse = true;
        }

        public override bool Shoot(
            Player player, 
            EntitySource_ItemUse_WithAmmo source, 
            Vector2 position, 
            Vector2 velocity, 
            int type, 
            int damage, 
            float knockback)
        {
            position += new Vector2(velocity.X, velocity.Y);
            Projectile.NewProjectile(
                Terraria.Entity.GetSource_NaturalSpawn(),
                position.X,
                position.Y,
                velocity.X / 30,
                velocity.Y / 30,
                type,
                damage,
                (int)knockback,
                Main.myPlayer,
                velocity.X,
                velocity.Y
            );
            return false;
        }
    }
}
