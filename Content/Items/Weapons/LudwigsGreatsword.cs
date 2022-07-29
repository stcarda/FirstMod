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
            Item.height = 60;
            Item.width = 60;
            Item.autoReuse = true;
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame) {
            player.itemLocation.X = player.Center.X;
        }        
    }
}
