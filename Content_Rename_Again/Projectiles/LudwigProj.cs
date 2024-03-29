﻿using FirstMod.Utils;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Modules;
using Terraria.Utilities;

namespace FirstMod.Content.Projectiles {
    class LudwigProj : ModProjectile {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("True Daemon's Blood Greatsword");
        }

		public override void SetDefaults() {
			// Damage properties. 
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = 3;
			Projectile.friendly = true;
			Projectile.hostile = false;
			
			// Anitation and AI properties.
			Projectile.aiStyle = -1;
			Projectile.width = 29;
			Projectile.height = 131;
			Projectile.timeLeft = 800;
			Projectile.light = 0.75f;

			// Physics properties.
			Projectile.ignoreWater = false;
			Projectile.tileCollide = false;
			Projectile.ownerHitCheck = true;
		}

        public override void AI() {
			// Increment the projectile's internal timer. This is essential for
			// parameters to be able to change.
			Projectile.ai[0]++;
			float currentTime = Projectile.ai[0];

			// If we are starting the call to AI(), we would like for the projectile
			// to start with some random rotation.
			if (currentTime < 2f) {
				Random random = new Random();
				Projectile.rotation = (float)(Math.PI * (2 * random.NextDouble() - 1));
            }

			// Slow the velocity to a near halt. It is sufficient to do this by
			// scaling the velocity vector.
			Projectile.velocity *= 0.97f;
			Vector2 projectileVelocity = Projectile.velocity;

			// Augment the projectile's rotation.
			Projectile.rotation += (1.2f / currentTime);

			// If we have reached a sufficiently slow speed, start raining blood.
			if (PseudoNumpyHelpers.L2Norm(projectileVelocity) < 0.05f) {
				Projectile.NewProjectileDirect(
					Projectile.GetSource_FromThis(),
					Projectile.Center,
					0.1f * new Vector2(0, 1),
					ProjectileID.GoldenShowerFriendly,
					2,
					0f,
					Main.myPlayer,
					0f,
					0f
				);
			}
		}
	}
}
