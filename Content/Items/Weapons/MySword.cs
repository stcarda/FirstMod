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
            Item.damage = 30;
            Item.knockBack = 2;

            // Set the "class" type of this item. This is a boolean that denotes
            // what style of weapon this weapon is and isn't.
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;

            // Set the animation style used by the weapon. You should not use
            // an integer for this anymore.
            Item.useStyle = ItemUseStyleID.Swing;

            // Set the timing of the animation. The difference between the
            // two is not known yet.
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.UseSound = SoundID.Item1;

            // Set the hitbox height and width. These should typically be the
            // same.
            Item.width = 25;
            Item.height = 25;

            // Set rarity. You may need to lookup values for this.
            Item.rare = ItemRarityID.LightRed;

            // Set whether or not we can swing this item by just holding
            // down the left mouse click.
            Item.autoReuse = true;

        }
    }
}
