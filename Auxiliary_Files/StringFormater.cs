using static System.Net.Mime.MediaTypeNames;

namespace MDE.Auxiliary_Files
{
    public class SF//String formating class
    {
        public const string result = "\"result\":";
        public const string results = "\"results\":";
        public const string input = "\"input\":";
        public const string output = "\"output\":";
        public const string mainOutput = "\"mainOutput\":";
        public const string ingredients = "\"ingredients\":";
        public const string ingredient = "\"ingredient\":";
        public const string transitional = " \"transitionalItem\":";
        public const string sequence = "  \"sequence\":";
        public const string xp = "\"experience\" :";
        public const string secondaries = "\"secondaries\" :";
        public const string amount = "\"amount\":";
        public const string fluid = "\"fluid\":";
        public const string fluidtag = "\"fluid_tag\":";
        public const string nbtEmpty = "\"nbt\": {}";

        public static string removeWraping(string s) { if (s.Length > 14) { s = s.Substring(13); return s.Remove(s.Length - 2); } return " "; }
        static public string count(int a) { return "\"count\":" + a.ToString(); }
        static public string loops(int a) { return "\"loops\":" + a.ToString(); }
        static public string chance(double a) { return "\"chance\":" + a.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture); }
        static public string processTime(double a) { return "\"processingTime\":" + a.ToString(); }
        static public string energyMod(double a) { return "\"energy_mod\":" + (a / 100).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture); }
        static public string energyRequired(double a) { return "\"energy\":" + (a * 28).ToString(); }
        static public string wrapInItem(string s) { return "{\"item\": \'" + s + "\' }"; }
        static public string wrapInItemWithCount(string s, int a) { return "{\"item\": \'" + s + "\'," + count(a) + " }"; }
        static public string wrapInItemWithChance(string s, double b) { return "{\"item\": \'" + s + "\'," + chance(b) + '}'; }
        static public string wrapInTag(string s) { return "{ \"tag\": \'" + s + "\' }"; }
        static public string wrapInCustomRecipeEvent(string s) { return "event.custom({" + s + "})\n"; }
        static public string wrapInCreateEvent(string s) { return "event.create(\"" + s + "\")"; }
        static public string wrapInItemRegistryEvent(string s) { return "onEvent('item.registry', event => {" + s + "})\n"; }
        static public string wrapInFluidName(string s, int a) { return "\"inputFluid\": \"{FluidName:\\\"" + s + "\\\",Amount:" + a + "}\""; }
    }
}
