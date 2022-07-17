using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FirstMod.Content.Projectiles
{
    class GBS_proj : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.DamageType = DamageClass.Melee;
        }
    }
}
