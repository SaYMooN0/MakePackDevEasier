using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MDE
{
    internal class ThermalExpansion
    {
        static string pulverizerType = "\"type\": \"thermal:pulverizer\"";
        public static string Crusher1to1(string input, bool isTag, string output, int count, double energy)
        {
            string recipe = pulverizerType + ',' + SF.ingredient;
            if (isTag)
                recipe += $"[{SF.wrapInTag(input)}]";
            else
                recipe += $"[{SF.wrapInItem(input)}]";
            recipe += ',' + SF.result + SF.wrapInItemWithCount(output, count) + ',' + SF.energyMod(energy);
            return SF.wrapInCustom(recipe);
        }
        public static string Crusher1ToMany(string input, bool isTag, List<Tuple<string, double>> l, double energy)
        {


            string recipe = pulverizerType + ',' + SF.ingredient;
            if (isTag)
                recipe += $"[{SF.wrapInTag(input)}],";
            else
                recipe += $"[{SF.wrapInItem(input)}],";
            recipe += SF.result + '[';
            for (int i = 0; i < l.Count; i++)
            {
                recipe += SF.wrapInItemWithChance(l[i].Item1, l[i].Item2);
                recipe += ",";
            }
            recipe = recipe.Substring(0, recipe.Length - 1);
            recipe += "]";
            return SF.wrapInCustom(recipe);
        }
    }
}
