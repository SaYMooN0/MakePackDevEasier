namespace MDE
{
    public class SF//String formating class
    {
        public const string result = "\"result\":";
        public const string input = "\"input\":";
        public const string ingredients = "\"ingredients\":";
        static public string count(int a){ return "\"count\":"+a.ToString(); }
        static public string processTime(double a){ return "\"processingTime\":" + (a).ToString(); }
        static public string energyMod(double a){ return "\"energy_mod\":" + (a/100).ToString(); }
        static public string wrapInItem(string s){return "{\"item\": \'"+s+"\' }";}
        static public string wrapInItem(string s, int a){return "{\"item\": \'"+s+"\',"+count(a)+" }";}
        static public string wrapInTag(string s){return "{ \"tag\": \'"+s+"\' }";}
        static public string wrapInCustom(string s){return "event.custom({" + s + "})";}
    }
}
