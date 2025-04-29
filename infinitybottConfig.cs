using System.ComponentModel;
using Newtonsoft.Json;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;


namespace infinitybott
{
    public class infinitybottConfig : ModConfig
    {
        [Label("Enable Calamity Speed Balance")]
        [Tooltip("Reduces the effects of Swiftness and Well Fed buffs to Calamity standards. Check the mod description for more details.")]
        [DefaultValue(false)]
        public bool toggleCalamitySpeedBalance;

        [Label("Enable Crate Effect")]
        [Tooltip("Enables Crate when using Infinite Crate Buff or its upgrades.")]
        [DefaultValue(true)]
        public bool toggleInfCrate;

        [Label("Enable Gills Effect")]
        [Tooltip("Enables Gills when using Infinite Gills Buff or its upgrades.")]
        [DefaultValue(true)]
        public bool toggleInfGills;

        [Label("Enable Gravitation Effect")]
        [Tooltip("Enables Gravitation when using Infinite Gravitation Buff or its upgrades.")]
        [DefaultValue(true)]
        public bool toggleInfGravitation;

        [Label("Enable Featherfall Potion Effect")]
        [Tooltip("Enables Featherfall when using Infinite Featherfall Buff or its upgrades.")]
        [DefaultValue(true)]
        public bool toggleInfFeatherfall;

        [Label("Enable Inferno Potion Effect")]
        [Tooltip("Enables the Inferno effect when using Infinite Inferno Buff or its upgrades.\nDisable to hide visual AND disable damage effect\nDISABLED EFFECT overrides ENABLED VISUAL")]
        [DefaultValue(true)]
        public bool toggleInfInferno;

        [Label("Enable Inferno Potion Visual")]
        [Tooltip("Enables the Inferno visual when using Infinite Inferno Buff or its upgrades.\nDisable to hide the big flame circle")]
        [DefaultValue(true)]
        public bool toggleInfInfernoVisual;

        [Label("Enable Invisibility Potion Effect")]
        [Tooltip("Enables Invisibility when using Infinite Invisibility Buff or its upgrades.\nThis affects spawn rates.")]
        [DefaultValue(true)]
        public bool toggleInfInvisibility;


        public static infinitybottConfig Instance => ModContent.GetInstance<infinitybottConfig>();
        [JsonIgnore]
        public static bool Toggle_Calamity_Speed_Balance => Instance.toggleCalamitySpeedBalance;

        [JsonIgnore]
        public static bool Toggle_Inf_Crate => Instance.toggleInfCrate;

        [JsonIgnore]
        public static bool Toggle_Inf_Gills => Instance.toggleInfGills;

        [JsonIgnore]
        public static bool Toggle_Inf_Gravitation => Instance.toggleInfGravitation;

        [JsonIgnore]
        public static bool Toggle_Inf_Featherfall => Instance.toggleInfFeatherfall;

        [JsonIgnore]
        public static bool Toggle_Inf_Inferno => Instance.toggleInfInferno;

        [JsonIgnore]
        public static bool Toggle_Inf_Inferno_Visual => Instance.toggleInfInfernoVisual;

        [JsonIgnore]
        public static bool Toggle_Inf_Invisibility => Instance.toggleInfInvisibility;

        public override ConfigScope Mode => ConfigScope.ClientSide;
    }
}
