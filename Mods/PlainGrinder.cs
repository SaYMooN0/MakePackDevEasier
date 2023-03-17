using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDE.Mods
{
    internal class PlainGrinder
    {
        static string Type = "\"type\": \"plaingrinder:grinder\"";
        public static string Crusher1to1(string input, bool isTag, string output, int count)
        {
            string recipe = Type + ',' + SF.input;
            if (isTag)
                recipe += SF.wrapInTag(input);
            else
                recipe += SF.wrapInItem(input);
            recipe += ',' + SF.result + SF.wrapInItemWithCount(output, count);
            return SF.wrapInCustomRecipeEvent(recipe);
        }
    }
}
