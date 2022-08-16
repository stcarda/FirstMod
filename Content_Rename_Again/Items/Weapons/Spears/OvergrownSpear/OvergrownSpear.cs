using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;

namespace FirstMod.Content.Items.Weapons.Spears.OvergrownSpear {
    internal class OvergrownSpear : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Fauna-Overgrown Royal Spear");
            Tooltip.SetDefault(
                "Spear once wielded by the Aetherian Royal Garrison, now tainted \n" +
                "by an unyielding, voracious overgrowth.");
        }

        public override void SetDefaults() {
            Item.CloneDefaults(ItemID.Spear);
            // Set damage parameters.
            Item.DamageType = DamageClass.Melee;
            Item.damage = 60;
            Item.knockBack = 4;
            Item.autoReuse = true;

            // Item animation properties.
            //Item.useStyle = ItemUseStyleID.Thrust;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.channel = false;

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

        // We want to be able to switch between using close-range melee and a long-range
        // laser.
        public override bool AltFunctionUse(Player player) {
            return true;
        }

        // Set the properties of this weapon when using either the close-range melee
        // attack or the laser. The laser should punish using long-distance by doing
        // less damage.
        public override bool CanUseItem(Player player) {
            if (player.altFunctionUse == 2) {
                Item.useTime = 20;
                Item.useAnimation = 20;
                Item.damage = 30;
                Item.shoot = Mod.Find<ModProjectile>("OvergrownSpearLaser").Type;
            } else {
                Item.useTime = 40;
                Item.useAnimation = 40;
                Item.damage = 60;
                Item.shoot = Mod.Find<ModProjectile>("OvergrownSpearProj").Type;
            }
            return base.CanUseItem(player);
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

        // We want to have a holdout offset for rotating about the center of the player.
        // We cannot do this through holdout offset due to the melee nature of the weapon.
        private const float HOLDOUT_OFFSET = 30;

        public override void AI() {
            // Get a reference to the player and the player's center.
            Projectile.ai[0]++;
            Player player = Main.player[Projectile.owner];
            Vector2 playerCenter = player.RotatedRelativePoint(player.MountedCenter, true);

            // Modify the projectile's direction.
            Projectile.direction = player.direction;

            // Get the degrees the sprite is offset by.
            float rotationOffset = 45;

            // Get the vector extending from the center of the screen to the position of
            // the mouse on-screen.
            float centerToMouseX = Main.MouseScreen.X - Main.screenWidth / 2;
            float centerToMouseY = Main.MouseScreen.Y - Main.screenHeight / 2;
            float mouseAngle = (float)Math.Atan2(centerToMouseY, centerToMouseX);
            Projectile.rotation = mouseAngle + degreesToRadians(rotationOffset);

            // Set the position of the projectile to be on the player.
            float holdOffX = (HOLDOUT_OFFSET) * (float)Math.Cos(mouseAngle);
            float holdOffY = (HOLDOUT_OFFSET) * (float)Math.Sin(mouseAngle);
            Projectile.position.X = playerCenter.X - ((float)Projectile.width / 2) + holdOffX;
            Projectile.position.Y = playerCenter.Y - ((float)Projectile.height / 2) + holdOffY;
        }

        public float degreesToRadians(float degrees) {
            return (float)Math.IEEERemainder(Math.PI / 180 * degrees, Math.PI);
        }

    }


    public class OvergrownSpearLaser : ModProjectile {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Fauna-Overgrown Royal Spear");
        }

        public override void SetDefaults() {
            // Damage properties.
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = 3;
            Projectile.friendly = true;
            Projectile.hostile = false;

            // Animation and AI properties.
            Projectile.aiStyle = -1;
            Projectile.width = 11;
            Projectile.height = 15;
            Projectile.timeLeft = 30;

            // Physics properties.
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.ownerHitCheck = true;
        }

        // Set what the max distance can be.
        private const float MAX_DISTANCE = 99;

        // Set a distance variable which can be accessed to set the endpoint of the laser.
        public float Distance {
            get => Projectile.ai[0];
            set => Projectile.ai[0] = value;
        }

        public override bool PreDraw(ref Color lightColor) {
            DrawLaser(
                Projectile.,)
        }

        public void DrawLaser(
            SpriteBatch spriteBatch, 
            Texture2D texture,
            Vector2 start,
            Vector2 unit,
            float step,
            int damage,
            float rotation = 0f,
            float scale = 1f,
            float maxDist = 2000f,
            Color color = default(Color),
            int transDist = 50
        ) {
            float r = unit.ToRotation() + rotation;

            // Draw the beam of the laser.
            for (float i = transDist; i <= Distance; i += step) {
                Color c = Color.White;
                var origin = start + i * unit;
                spriteBatch.Draw(
                    texture, 
                    origin - Main.screenPosition,
                    new Rectangle(0, 26, 28, 26),
                    i < transDist ? Color.Transparent : c, 
                    r,
                    new Vector2(28 * 0.5f, 26 * 0.5f),
                    scale,
                    0f,
                    0f
                );
            }

            // Draw the tail of the laser.
            spriteBatch.Draw(
                texture,
                start + unit * (transDist - step) - Main.screenPosition,
                new Rectangle(0, 0, 28, 26),
                Color.White,
                r,
                new Vector2(28 * 0.5f, 26 * 0.5f),
                scale,
                0f,
                0f
            );

            // Draw the head of the laser.
            spriteBatch.Draw(
                texture,
                start + (Distance + step) * unit - Main.screenPosition,
                new Rectangle(0, 52, 28, 26),
                Color.White,
                r,
                new Vector2(28 * 0.5f, 26 * 0.5f),
                scale,
                0f,
                0f
            );
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox) {
            Player player = Main.player[Projectile.owner];
            Vector2 unit = Projectile.velocity;
            float point = 0f;
            // Run an AABB versus Line check to look for collisions, look up AABB collision
            // first to see how it works.
            return Collision.CheckAABBvLineCollision(
                targetHitbox.TopLeft(), 
                targetHitbox.Size(), 
                player.Center,
                player.Center + unit * Distance, 
                22, 
                ref point
            );
        }

        public void SetLaserLength(Player player) {
            for (Distance = MAX_DISTANCE; Distance <= 2200f; Distance += 5f) {
                Vector2 start = player.Center + Projectile.velocity * Distance;
                if (!Collision.CanHit(player.Center, 1, 1, start, 1, 1)) {
                    Distance -= 5f;
                    break;
                } 
            }
        }

        public override void AI() {
            
        }

        public override void CutTiles() {
            DelegateMethods.tilecut_0 = TileCuttingContext.AttackProjectile;
            Vector2 unit = Projectile.velocity;
            Terraria.Utils.PlotTileLine(
                Projectile.Center, 
                Projectile.Center + unit * Distance, 
                (Projectile.width + 16) * Projectile.scale, 
                DelegateMethods.CutTiles
            );
        }
    }
}
