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
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            // Basic item info.
            item.rare = ItemRarityID.LightPurple;

            // Set the item damage and knockback.
            item.damage = 20;
            item.knockBack = 5;

            // Set reusability.
            item.autoReuse = true;

            // Set the item to be from the magic class and set the mana to be consumed.
            item.magic = true;
            item.noMelee = true;
            item.mana = 10;

            // Hitbox dimension info.
            item.height = 40;
            item.width = 40;

            // Animation / use time. Set the speed of the cast animation.
            item.useAnimation = 20;
            item.useTime = 20;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.UseSound = SoundID.Item8;
            item.shoot = ProjectileID.CrystalPulse;
            item.shootSpeed = 5;
        }

        public override Vector2? HoldoutOrigin()
        {
            return new Vector2(0, 20);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 offset = new Vector2(speedX * 3, speedY * 3);
            position += offset;
            return true;
        }

    }
}
