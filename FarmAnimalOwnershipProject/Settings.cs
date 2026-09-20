using Mutagen.Bethesda.Synthesis.Settings;


namespace FarmAnimalOwnershipProject
{

    // ObjectNameMember targets the class (not a member) and names the member whose live value
    // labels this entry when it appears inside a list. Without it, list rows render with a blank
    // header and are dropped from the breadcrumb, leaving entries indistinguishable in the UI.
    [SynthesisObjectNameMember(nameof(EditorID))]
    public class ManualFactionMatchEntry
    {

        [SynthesisSettingName("Match Pattern")]
        [SynthesisTooltip("A substring to match against a cell or location EditorID (partial matching).")]
        public string EditorID { get; set; } = string.Empty;

        [SynthesisSettingName("Faction EditorID")]
        [SynthesisTooltip("The EditorID of the faction that should own animals matching the pattern above.")]
        public string FactionEditorID { get; set; } = string.Empty;
    }


    public class VerboseSettings
    {

        [SynthesisSettingName("Placed NPCs seen, by plugin")]
        [SynthesisTooltip("Lists every plugin the patcher saw ANY placed NPC from, and how many of those matched a farm-animal race — before any exclusion rule runs. Use this to check whether a mod's animals are reaching the patcher at all.")]
        public bool PerPluginCounts { get; set; } = false;

        [SynthesisSettingName("Skipped animals, by cell")]
        [SynthesisTooltip("Lists the farm animals that were left unpatched because no suitable owner could be found, grouped by cell and plugin.")]
        public bool SkippedAnimals { get; set; } = false;

        [SynthesisSettingName("Exclusion detail (list animal names)")]
        [SynthesisTooltip("Adds the individual animal names under each rule in the Exclusion Summary, instead of just a count.")]
        public bool ExclusionDetail { get; set; } = false;

        [SynthesisSettingName("Flag fuzzy faction matches")]
        [SynthesisTooltip("Marks ownership that came from a loose name match rather than an exact one with '(fuzzy)'. Fuzzy matches are the likeliest source of a wrong owner, so this is worth turning on when checking results.")]
        public bool FuzzyMatchDetail { get; set; } = false;

        [SynthesisSettingName("Timing breakdown")]
        [SynthesisTooltip("Prints how long each phase of the run took. Useful when the patcher feels slow on a large load order.")]
        public bool Timing { get; set; } = false;
    }


    [SynthesisObjectNameMember(nameof(PluginName))]
    public class PluginFactionOverrideEntry
    {

        [SynthesisSettingName("Plugin Name (partial matching)")]
        [SynthesisTooltip("A substring of the plugin file name that placed the animal (e.g. 'MyFarmMod').")]
        public string PluginName { get; set; } = string.Empty;

        [SynthesisSettingName("Faction EditorID")]
        [SynthesisTooltip("The EditorID of the faction that should own animals placed by matching plugins.")]
        public string FactionEditorID { get; set; } = string.Empty;
    }


    public class Settings
    {

        [SynthesisSettingName("Races to patch")]
        [SynthesisTooltip("The races the patcher is looking for")]
        public List<string> IncludeRaceTerms { get; set; } =
        [
            "Goat", "Chicken", "Cow", "Horse", "Pig", "Sheep", "Dog", "Cat", "Bunny", "Husky", "Geese",
            "Goose", "Rabbit", "Pet", "Duck", "Rooster", "Lamb", "Foal", "Puppy", "Kitten", "Calf", "Cock",
            "Domestic", "MihailGuar", "MihailKagouti", "BantamGuar",

        ];

        [SynthesisSettingName("Owners to never assign")]
        [SynthesisTooltip("Factions to never assign as owners")]
        public List<string> ExcludeOwnerNames { get; set; } =
        [
            "Player", "CW", "Bandit", "Hagraven", "Fort", "Draugr", "JobMerchantFaction",
            "Fake", "CarriageDriver", "CarriageSystemFaction", "RiverwoodCamillaFaction", "Service",
        ];

        [SynthesisSettingName("Minimum owned animals required for a majority")]
        [SynthesisTooltip("A cell needs at least this many already-owned animals before the ownership by voting system is active")]
        public int MinimumOwnedObjectsForMajority { get; set; } = 1;

        [SynthesisSettingName("Names to exclude")]
        [SynthesisTooltip("Actor name terms to exclude from patching")]
        public List<string> ExcludeNameTerms { get; set; } =
        [
            "Wild", "Bandit", "Forsworn", "Sabre", "Pigeon", "Zombie", "Draugr", "Durzog", "Stray", "Dead", "Ghost",
            "Vampire", "Necromancer", "Bone", "Feral", "Giant", "Dragon", "Troll", "ShellBug", "Netch", "BYOH",
            "Player", "CW",
        ];

        [SynthesisSettingName("Plugins to exclude")]
        [SynthesisTooltip("Plugins that are entirely excluded from patching")]
        public List<string> ExcludePlugins { get; set; } =
        [
            "Vigilant", "SkyrimUnderground", "HearthFire", "cc", "Glenmoril", "HorrorOfMorthal", "BattleAftermath",
            "CWB",
        ];

        [SynthesisSettingName("Cells to exclude")]
        [SynthesisTooltip("Cells that are entirely excluded from patching")]
        public List<string> ExcludeCellRules { get; set; } =
        [
            "BYOH", "cc", "Helgen", "Labyrinthian", "POI", "CW", "DrelassCottage", "Attack",
        ];

        [SynthesisSettingName("Location Types to exclude")]
        [SynthesisTooltip("Location types that are entirely excluded from patching")]
        public List<string> ExcludeLocTypeRules { get; set; } =
        [
            "Dungeon", "AnimalDen", "Bandit", "DragonLair", "Draugr", "Dwarven",
            "Falmer", "GiantCamp", "Hagraven", "Spriggan", "Vampire", "Warlock",
            "Werewolf", "Forsworn", "Cave", "Ruin", "PlayerHouse", "Lair",
        ];

        [SynthesisSettingName("Plugin overrides (Plugin name -> Faction EditorID)")]
        [SynthesisTooltip("Animals placed by a matching plugin are assigned to the given faction, taking precedence over location-based matching.")]
        public List<PluginFactionOverrideEntry> PluginFactionOverrides { get; set; } =
        [
            new() { PluginName = "Whiterun", FactionEditorID = "TownWhiterunFaction" },
            new() { PluginName = "Solitude", FactionEditorID = "TownSolitudeFaction" },
            new() { PluginName = "Riften", FactionEditorID = "TownRiftenFaction" },
            new() { PluginName = "Windhelm", FactionEditorID = "TownWindhelmFaction" },
            new() { PluginName = "Markarth", FactionEditorID = "TownMarkarthFaction" },
            new() { PluginName = "Falkreath", FactionEditorID = "TownFalkreathFaction" },
            new() { PluginName = "Morthal", FactionEditorID = "TownMorthalFaction" },
            new() { PluginName = "Dawnstar", FactionEditorID = "TownDawnstarFaction" },
            new() { PluginName = "Winterhold", FactionEditorID = "TownWinterholdFaction" },
            new() { PluginName = "DragonBridge", FactionEditorID = "TownDragonBridgeFaction" },
            new() { PluginName = "Ivarstead", FactionEditorID = "TownIvarsteadFaction" },
            new() { PluginName = "Karthwasten", FactionEditorID = "TownKarthwastenFaction" },
            new() { PluginName = "Riverwood", FactionEditorID = "TownRiverwoodFaction" },
            new() { PluginName = "Rorikstead", FactionEditorID = "TownRoriksteadFaction" },
            new() { PluginName = "Kynesgrove", FactionEditorID = "TownKynesgroveFaction" },
            new() { PluginName = "Nightgate", FactionEditorID = "Hadring" },
            new() { PluginName = "OldHroldan", FactionEditorID = "TownOldHroldanFaction" },
            new() { PluginName = "ShorsStone", FactionEditorID = "TownShorsStoneFaction" },
            new() { PluginName = "Shor's Stone", FactionEditorID = "TownShorsStoneFaction" },
            new() { PluginName = "DarkwaterCrossing", FactionEditorID = "TownDarkwaterCrossingFaction" },
            new() { PluginName = "Skaal", FactionEditorID = "DLC2SVGreathallFaction" },
        ];

        [SynthesisSettingName("Manual Faction Matches")]
        [SynthesisTooltip("Matches a cell/location EditorID to a faction. Only consulted once naming conventions (Town/Farm/Mill patterns) have already had a chance to resolve one. Be careful not to use too broad terms! EditorID can be either a CELL or a LOCATION EditorID.")]
        public List<ManualFactionMatchEntry> ManualFactionMatches { get; set; } =
        [
            // Vanilla Towns
            new() { EditorID = "Whiterun", FactionEditorID = "TownWhiterunFaction" },
            new() { EditorID = "Solitude", FactionEditorID = "TownSolitudeFaction" },
            new() { EditorID = "Riften", FactionEditorID = "TownRiftenFaction" },
            new() { EditorID = "Windhelm", FactionEditorID = "TownWindhelmFaction" },
            new() { EditorID = "Markarth", FactionEditorID = "TownMarkarthFaction" },
            new() { EditorID = "Falkreath", FactionEditorID = "TownFalkreathFaction" },
            new() { EditorID = "Morthal", FactionEditorID = "TownMorthalFaction" },
            new() { EditorID = "Dawnstar", FactionEditorID = "TownDawnstarFaction" },
            new() { EditorID = "Winterhold", FactionEditorID = "TownWinterholdFaction" },
            new() { EditorID = "DragonBridge", FactionEditorID = "TownDragonBridgeFaction" },
            new() { EditorID = "Ivarstead", FactionEditorID = "TownIvarsteadFaction" },
            new() { EditorID = "Karthwasten", FactionEditorID = "TownKarthwastenFaction" },
            new() { EditorID = "Riverwood", FactionEditorID = "TownRiverwoodFaction" },
            new() { EditorID = "Rorikstead", FactionEditorID = "TownRoriksteadFaction" },
            new() { EditorID = "Kynesgrove", FactionEditorID = "TownKynesgroveFaction" },
            new() { EditorID = "Nightgate", FactionEditorID = "Hadring" },
            new() { EditorID = "OldHroldan", FactionEditorID = "TownOldHroldanFaction" },
            new() { EditorID = "ShorsStone", FactionEditorID = "TownShorsStoneFaction" },
            new() { EditorID = "Shor's Stone", FactionEditorID = "TownShorsStoneFaction" },
            new() { EditorID = "DarkwaterCrossing", FactionEditorID = "TownDarkwaterCrossingFaction" },
            new() { EditorID = "MixwaterMill", FactionEditorID = "MixwaterMillGilfreHouseFaction" },

            // Misc Locations
        //  new() { EditorID = "DawnstarSanctuaryLocation", FactionEditorID = "DarkBrotherhoodFaction" },
            new() { EditorID = "DragonBridgeFourShieldsTavern", FactionEditorID = "DragonBridgeFourShieldsInnFaction" },
            new() { EditorID = "HonningbrewMeadery", FactionEditorID = "HonningbrewMeaderyFaction" },
            new() { EditorID = "AngisCampExterior", FactionEditorID = "WIGenericCrimeFaction" },
            new() { EditorID = "LeftHandMine", FactionEditorID = "TownLeftHandMineFaction" },
            new() { EditorID = "Stonehills", FactionEditorID = "TownStonehillsFaction" },
            new() { EditorID = "BluePalace", FactionEditorID = "SolitudeBluePalaceFaction" },

            // Modded Locations
            new() { EditorID = "BearsCaveMillLocation", FactionEditorID = "RG439BearsCaveMillFaction" },
            new() { EditorID = "KynesgroveFarmsLocationTGCoKG", FactionEditorID = "KynesgroveRagnasAndHerleifsHouseFactionTGCoKG" },
            new() { EditorID = "KynesgroveGalasSteadLocationTGCoKG", FactionEditorID = "KynesgroveGalasHouseFactionTGCoKG" },
            new() { EditorID = "0BearQOrigin", FactionEditorID = "TownWindhelmFaction" },
            new() { EditorID = "NightgateInn", FactionEditorID = "Hadring" },
            new() { EditorID = "0WindhelmExtDwelling", FactionEditorID = "WindhelmSurWheelhouseFaction" },
            new() { EditorID = "GraniteHill", FactionEditorID = "TownGraniteHillFaction" },
            new() { EditorID = "HalloftheVigilant", FactionEditorID = "VigilantOfStendarrFaction" },
            new() { EditorID = "WBPT", FactionEditorID = "SolitudeBluePalaceFaction" },

            // DLC Locations
            new() { EditorID = "TelMithryn", FactionEditorID = "TelMithrynFaction" },
            new() { EditorID = "DLC2SkaalVillageLocation", FactionEditorID = "DLC2SVGreathallFaction" },
            new() { EditorID = "DLC2RavenRockLocation", FactionEditorID = "DLC2RRBulwarkFaction" },
            new() { EditorID = "Dawnguard", FactionEditorID = "DLC1DawnguardFaction" },
            new() { EditorID = "HunterWorld", FactionEditorID = "DLC1DawnguardFaction" },
            new() { EditorID = "RavenRock", FactionEditorID = "DLC2CrimeRavenRockFaction" },

            // Orc Strongholds
            new() { EditorID = "DushnikhYal", FactionEditorID = "TownDushnikhYalFaction" },
            new() { EditorID = "Largashbur", FactionEditorID = "TownLargashburFaction" },
            new() { EditorID = "MorKhazgur", FactionEditorID = "TownMorKhazgurFaction" },
            new() { EditorID = "Narzulbur", FactionEditorID = "TownNarzulburFaction" },
        ];

        [SynthesisSettingName("Verbose logging")]
        [SynthesisTooltip("Extra diagnostic output, off by default. Turn these on when an animal wasn't patched and you need to find out why.")]
        public VerboseSettings Verbose { get; set; } = new();
    }
}