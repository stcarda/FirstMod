using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using FirstMod.Content.Projectiles;

// This is a weapon from the mod FirstMod.
namespace FirstMod.Content.Items.Weapons {
    class LudwigsGreatsword : ModItem {
        public override void SetStaticDefaults() {
            // Set the name of the item that is seen in-game.
            DisplayName.SetDefault("True Daemon's Blood Greatsword");

            // Provide a short description of the item.
            Tooltip.SetDefault("Blood-blessed Daemon's Blood Greatsword, true bane of Ludwig's faith...");
        }
        public override void SetDefaults() {
            // Set the weapon behavior properties.
            Item.damage = 100;
            Item.knockBack = 6;
            Item.DamageType = DamageClass.Melee;

            // Set the hold style.
            Item.useStyle = ItemUseStyleID.Swing;
            Item.shoot = Mod.Find<ModProjectile>("LudwigProj").Type;
            Item.shootSpeed = 15f;

            // Set the properties of the animation.
            Item.useTime = 35;
            Item.useAnimation = 35;

            // Hitbox properties.
            Item.height = 100;
            Item.width = 100;
            Item.autoReuse = true;
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame) {
            player.itemLocation.X = player.Center.X;
        }

        public override bool Shoot(
            Player player, 
            EntitySource_ItemUse_WithAmmo source, 
            Vector2 position, 
            Vector2 velocity, 
            int type, 
            int damage, 
            float knockback
        ) {
            // Get the number of projectiles currently owned by this weapon.
            int swordProjectileType = Mod.Find<ModProjectile>("LudwigProj").Type;
            int projectileCount = player.ownedProjectileCounts[swordProjectileType];
            if (projectileCount <= 2) {
                Projectile.NewProjectile(
                    source,
                    position,
                    velocity,
                    type,
                    damage,
                    knockback,
                    player.whoAmI,
                    0f,
                    0f
                );
            }
            return false;
        }
    }
}
