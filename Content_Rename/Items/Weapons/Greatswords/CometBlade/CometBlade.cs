using FirstMod.Utils;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FirstMod.Content.Items.Weapons.Greatswords.CometBlade {
    internal class CometBlade : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Drynseaux's Uncarved Cometstone Sabre");
            Tooltip.SetDefault(
                "The unhewn sabre once wielded by Drynseaux, the astral Wyrm of stars. \n " +
                "In its current state, it is nothing more than cosmic rock, but \n " +
                "Drynseaux was a skilled smith, and would not leave such raw potential \n " +
                "to slumber..."
            );
        }

        public override void SetDefaults() {
            // Damage properties.
            Item.damage = 70;
            Item.DamageType = DamageClass.Melee;
            Item.knockBack = 5;
            Item.autoReuse = false;

            // Shoot properties.
            Item.shoot = Mod.Find<ModProjectile>("CometBladeProj").Type;

            // Item animation properties.
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.scale = 1.5f;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.channel = false;

            // Hitbox and physics properties.
            Item.width = 80;
            Item.height = 80;
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame) {
            player.itemLocation.X = player.Center.X;
        }

        public override bool CanUseItem(Player player) {
            return player.ownedProjectileCounts[Item.shoot] < 1;
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


    public class CometBladeProj : ModProjectile {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Drynseaux's Uncarved Cometstone Sabre");
        }

        public override void SetDefaults() {
            // Damage properties.
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = -1;
            Projectile.friendly = true;
            Projectile.hostile = false;

            // Animation and AI properties.
            Projectile.aiStyle = -1;
            Projectile.width = 80;
            Projectile.height = 80;
            Projectile.timeLeft = 30;
            Projectile.scale = 1.5f;

            // Physics properties.
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.ownerHitCheck = true;
        }

        public override void AI() {
            // Increment the internal timer and get reference to the player.
            Projectile.ai[0]++;
            float currentTime = Projectile.ai[0];
            Player player = Main.player[Projectile.owner];

            // If we have died, we want to destroy the projectile.
            if (player.dead) {
                Projectile.Kill();
                return;
            }

            // Before the actual swing happens.
            if (currentTime < 10f) {
                // Ensure that the sword is facing the direction of the player.
                // This also adjusts the hitbox.
                Projectile.spriteDirection = player.direction;

                if (currentTime < 2f) {
                    Projectile.rotation = player.direction * degreesToRadians(-60);
                }

                // Adjust the positioning of the weapon based on the sprite direction so
                // that we are fixated on the player.
                Vector2 relativePosition = player.RotatedRelativePoint(player.MountedCenter);

                // Fine tune an offset depending on the direction of the sword.
                Vector2 swordOffset = new Vector2(
                    (player.direction < 0f ? 0.5f : 0.175f) * Projectile.Size.X,
                    Projectile.Size.Y
                );
                Projectile.position = relativePosition - swordOffset;
            }

            // If the current time is less than 10s, start a VERY slow upward swing
            // to build tension.
            if (currentTime < 10f) {
                Projectile.rotation -= player.direction * 0.01f;
            }
            // If we have performed the buildup, then swing down REALLY fast.
            else if (10f <= currentTime && currentTime <= 15f) {
                Projectile.rotation += player.direction * 0.35f;

                // Need to account for the change in position as the sword comes down.
                Projectile.position += new Vector2(
                    player.direction * Projectile.Size.X / 15f,
                    Projectile.Size.Y / 7.5f
                );
            }
            // When we have completed the swing, stop moving for the remainder of the
            // animation.
            else {
                Projectile.rotation -= player.direction * 0.01f;

                // Again, we need to account for the change in position to ensure
                // that the sword is still tracking the player after the complete
                // swing finishes.
                Vector2 relativePosition = player.RotatedRelativePoint(player.MountedCenter);
                Vector2 swordOffset = new Vector2(
                    (player.direction < 0f ? 0.8f : -0.15f) * Projectile.Size.X,
                    Projectile.Size.Y / 4
                );
                Projectile.position = relativePosition - swordOffset;
            }
        }

        public Dictionary<int, int> getWeaponAngleToArmPosition() {
            // Instantiate the dictionary.
            Dictionary<int, int> weaponAngleToArmPosition = new Dictionary<int, int>();
            int[] angles = new int[] { 180, 225, 270, 315 };
            int[] armPositions = new int[] { 1, 2, 3, 4 };

            // Fill the dictionary with values
            for (int i = 0; i < 4; i++) {
                weaponAngleToArmPosition.Add(angles[i], armPositions[i]);
            }

            return weaponAngleToArmPosition;
        }

        public int findNearestAngle(float angle) {
            int[] angles = new int[] { 180, 225, 270, 315 };
            int[] armPositions = new int[] { 1, 2, 3, 4 };

            // Get the closest angle to the given angle, and find the Player
            // body position that corresponds to that closest angle.
            int min = 999;
            for (int i = 0; i < 4; i++) {
                int currentAngle = angles[i];
                float angleDiff = Math.Abs(currentAngle - angle);
                if (angleDiff < min) {
                    min = currentAngle;
                }
            }
            return min;
        }

        public float degreesToRadians(float degrees) {
            return (float)Math.IEEERemainder(Math.PI / 180 * degrees, Math.PI);
        }
    }
}
