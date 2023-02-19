using System;

namespace MDE
{
    internal class Mekanism
    {
        static string millingType = "\"type\": \"mekanism:crushing\"";
        public static string Crusher1to1(string input, bool isTag, string output, int count)
        {
            string recipe = millingType + ',' + SF.input;
            if (isTag)
                recipe += SF.wrapInTag(input);
            else
                recipe += SF.wrapInItem(input);
            recipe += ',' + SF.result + SF.wrapInItem(output, count);
            return SF.wrapInCustom(recipe);
        }
    }
}
