using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;

namespace FirstMod.Content.Items.Weapons
{
    class CrystalSceptre : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Set name and item description.
            DisplayName.SetDefault("Crystal Sceptre");
            Tooltip.SetDefault("Sceptre of a crysal mage, imbued with gemstone sorcery. Casts " +
                               " crystal projectiles that split upon impact.");

            // This is a tag that corrects the positioning of the staff on the player when held.
            Item.staff[Item.type] = true;
        }

        public override void SetDefaults()
        {
            // Basic item info.
            Item.rare = ItemRarityID.LightPurple;

            // Set the item damage and knockback.
            Item.damage = 20;
            Item.knockBack = 5;

            // Set reusability.
            Item.autoReuse = true;

            // Set the item to be from the magic class and set the mana to be consumed.
            Item.DamageType = DamageClass.Magic;
            Item.noMelee = true;
            Item.mana = 10;

            // Hitbox dimension info.
            Item.height = 40;
            Item.width = 40;

            // Animation / use time. Set the speed of the cast animation.
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item8;
            Item.shoot = ProjectileID.CrystalPulse;
            Item.shootSpeed = 5;
        }

        public override Vector2? HoldoutOrigin()
        {
            return new Vector2(0, 20);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 offset = 3 * velocity;
            position += offset;
            return true;
        }

    }
}
