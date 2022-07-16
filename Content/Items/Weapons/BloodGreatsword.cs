//-----------------------------------------
// IMPORTS:
//-----------
using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;

// Namespace contains all of the item classes of First Mod.
namespace FirstMod.Content.Items.Weapons
{
    class BloodGreatsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Daemon's Blood Greatsword");
            Tooltip.SetDefault("Greatsword brandished by Archbishop Ludwig of the Jade City. \n\n" +
                               "It is said that when Archbishop Ludwig stood before the Daemon Gods, " +
                               "he was tainted by the allure of their blood. His sword, infused with " +
                               "a Daemon blood droplet, signifies the demise of his faith.");
        }
        public override void SetDefaults()
        {
            // Set the damage and knockback done by the item.
            item.damage = 70;
            item.knockBack = 5;

            // Set the "class" type of this item. This is a boolean that denotes
            // what style of weapon this weapon is and isn't.
            item.melee = true;

            // Set the animation style used by the weapon. You should not use
            // an integer for this anymore.
            item.useStyle = ItemUseStyleID.SwingThrow;

            // Set the timing of the animation. The difference between the
            // two is not known yet.
            item.useTime = 45;
            item.useAnimation = 45;
            item.UseSound = SoundID.Item1;

            // Set the hitbox height and width. These should typically be the
            // same.
            item.width = 50;
            item.height = 50;

            // Set rarity. You may need to lookup values for this.
            item.rare = ItemRarityID.Lime;

            // Set whether or not we can swing this item by just holding
            // down the left mouse click.
            item.autoReuse = true;
        }
        public override void UseStyle(Player player)
        {
            player.itemLocation.X = player.Center.X + 7;
            player.itemLocation.Y = player.Center.Y;
        }
        
    }
}
