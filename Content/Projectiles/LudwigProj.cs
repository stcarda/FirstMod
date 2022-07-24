using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FirstMod.Content.Projectiles
{
    class LudwigProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Daemon's Blood Greatsword");
            Main.projFrames[Projectile.type] = 6;
        }

        public override void SetDefaults()
        {
            // Set projectile hitbox params.
            Projectile.width = 100;
            Projectile.height = 100;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;

            // Friendly means that the projectile will hit enemies.
            Projectile.friendly = true;

            // Call what type of projectile this is from the DamageClass class.
            Projectile.DamageType = DamageClass.Melee;

            // Hostile is by default false, but we will set it here.
            Projectile.hostile = false;

            // We may hit 3 enemies before the projectile is destroyed.
            Projectile.penetrate = 3;

            // Projectile animation params.
            Projectile.timeLeft = 15;
        }

        public override void AI()
        {
            // Update the frame of the projectile based on the counter.
            Projectile.frameCounter++; 
            if (Projectile.frameCounter >=  5)
            {
                Projectile.frame++;
                Projectile.frameCounter = 0;
            }

            // Get the angle of the projectile.
            Vector2 angle = new Vector2(Projectile.ai[0], Projectile.ai[1]);
            Projectile.rotation = angle.ToRotation();

            // Get the player from Main and set the position of the projecile to be
            // the center of the player.
            Player player = Main.player[Projectile.owner];
            Projectile.position = player.Center + angle - new Vector2(
                Projectile.width / 2,
                Projectile.height / 2
            );
        }
    }
}
