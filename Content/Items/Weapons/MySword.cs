//-----------------------------------------
// IMPORTS:
//-----------
using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

// Namespace contains all of the item classes of First Mod.
namespace FirstMod.Content.Items.Weapons
{
    class MySword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("My Mod Sword");
            Tooltip.SetDefault("My First Mod Item!");
        }
        public override void SetDefaults()
        {
            // Set the damage and knockback done by the item.
            item.damage = 30;
            item.knockBack = 2;

            // Set the "class" type of this item. This is a boolean that denotes
            // what style of weapon this weapon is and isn't.
            item.melee = true;

            // Set the animation style used by the weapon. You should not use
            // an integer for this anymore.
            item.useStyle = ItemUseStyleID.SwingThrow;

            // Set the timing of the animation. The difference between the
            // two is not known yet.
            item.useTime = 20;
            item.useAnimation = 20;
            item.UseSound = SoundID.Item1;

            // Set the hitbox height and width. These should typically be the
            // same.
            item.width = 25;
            item.height = 25;

            // Set rarity. You may need to lookup values for this.
            item.rare = ItemRarityID.LightRed;

            // Set whether or not we can swing this item by just holding
            // down the left mouse click.
            item.autoReuse = true;

        }
    }
}
