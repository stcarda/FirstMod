using FirstMod.Utils;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FirstMod.Content.Items.Weapons.Spears {
    internal class OvergrownSpear : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Fauna-Overgrown Royal Spear");
            Tooltip.SetDefault(
                "Spear once wielded by the Aetherian Royal Garrison, now tainted \n" +
                "by an unyielding, voracious overgrowth.");
        }

        public override void SetDefaults() {
            // Set damage parameters.
            Item.DamageType = DamageClass.Melee;
            Item.damage = 60;
            Item.knockBack = 4;
            Item.autoReuse = true;

            // Item animation properties.
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.noUseGraphic = true;
            Item.noMelee = true;

            // Item shoot properties.
            Item.shoot = Mod.Find<ModProjectile>("OvergrownSpearProj").Type;

            // Hitbox and physics properties.
            Item.width = 90;
            Item.height = 90;
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
            Projectile.NewProjectile(
                source,
                position,
                velocity,
                Item.shoot,
                Item.damage,
                Item.knockBack,
                player.whoAmI,
                0f,
                0f
            );
            return false;
        }
    }

    public class OvergrownSpearProj : ModProjectile {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Fauna-Overgrown Royal Spear");
        }

        public override void SetDefaults() {
            // Damage properties.
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = -1;
            Projectile.friendly = true;
            Projectile.hostile = false;

            // Animation and AI properties.
            Projectile.aiStyle = -1;
            Projectile.width = 90;
            Projectile.height = 90;
            Projectile.timeLeft = 30;

            // Physics properties.
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.ownerHitCheck = true;
        }

        

        public override void AI() {
            // Get a reference to the player and the player's center.
            Projectile.ai[0]++;
            Player player = Main.player[Projectile.owner];
            Vector2 playerCenter = player.RotatedRelativePoint(player.MountedCenter, true);

            // Modify the projectile's direction.
            Projectile.direction = player.direction;
            
            // Set the position of the projectile to be on the player.
            Projectile.position.X = (playerCenter.X) - (float)Projectile.width / 2;
            Projectile.position.Y = (playerCenter.Y) - (float)Projectile.height / 2;

            // Get the degrees the sprite is offset by.
            float rotationOffset = (player.direction < 1) ? 45 : 45;

            // Get the vector extending from the center of the screen to the position of
            // the mouse on-screen.
            float centerToMouseX = Main.MouseScreen.X - (Main.screenWidth / 2);
            float centerToMouseY = Main.MouseScreen.Y - (Main.screenHeight / 2);
            Projectile.rotation = (float)Math.Atan2(centerToMouseY, centerToMouseX) +
                                  degreesToRadians(rotationOffset);

        }

        public float degreesToRadians(float degrees) {
            return (float)Math.IEEERemainder((Math.PI / 180) * degrees, Math.PI);
        }

    }
}
