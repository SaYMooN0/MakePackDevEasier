using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDE
{
    internal class ThermalExpansion
    {
        static string pulverizerType = "\"type\": \"thermal:pulverizer\"";
        public static string Crusher1to1(string input, bool isTag, string output, int count, double energy)
        {
            string recipe = pulverizerType + ',' + SF.ingredients;
            if (isTag)
                recipe += $"[{SF.wrapInTag(input)}]";
            else
                recipe += $"[{SF.wrapInItem(input)}]";
            recipe += ',' + SF.result + SF.wrapInItem(output, count) + ',' + SF.energyMod(energy);
            return SF.wrapInCustom(recipe);
        }
    }
}
