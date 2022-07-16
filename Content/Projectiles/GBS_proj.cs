using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FirstMod.Content.Projectiles
{
    class GBS_proj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.melee = true;
        }
    }
}
