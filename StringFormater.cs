namespace MDE
{
    public class SF//String formating class
    {
        public const string result = "\"result\":";
        public const string results = "\"results\":";
        public const string input = "\"input\":";
        public const string output = "\"output\":";
        public const string ingredients = "\"ingredients\":";
        public const string ingredient = "\"ingredient\":";
        public const string xp = "\"experience\" :";
        public const string secondaries = "\"secondaries\" :";
        public const string amount = "\"amount\":";
        public const string fluid = "\"fluid\":";
        public const string fluidtag = "\"fluid_tag\":";
        public const string nbtEmpty = "\"nbt\": {}";

        static public string count(int a){ return "\"count\":"+a.ToString(); }
        static public string chance(double a){ return "\"chance\":" + a.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture); }
        static public string processTime(double a){ return "\"processingTime\":" + (a).ToString(); }
        static public string energyMod(double a){ return "\"energy_mod\":" + (a/100).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture); }
        static public string energyRequired(double a){ return "\"energy\":" + ((a*28).ToString()); }
        static public string wrapInItem(string s){return "{\"item\": \'"+s+"\' }";}
        static public string wrapInItemWithCount(string s, int a){return "{\"item\": \'"+s+"\',"+count(a)+" }";}
        static public string wrapInItemWithChance(string s, double b){ return "{\"item\": \'" + s + "\'," + chance(b) + '}'; }
        static public string wrapInTag(string s){return "{ \"tag\": \'"+s+"\' }";}
        static public string wrapInCustom(string s){return "event.custom({" + s + "})\n";}
        static public string wrapInFluidName(string s, int a){return "\"inputFluid\": \"{FluidName:\\\""+s+"\\\",Amount:"+a+"}\""; }
    }
}
