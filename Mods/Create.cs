using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MDE.Mods
{
    internal class Create //class for the Create Mod
    {
        static string millingType = "\"type\": \"create:milling\"";
        static string polishingType = "\"type\": \"create:sandpaper_polishing\"";
        static string fillingType = "\"type\": \"create:filling\"";
        static string assemblyType = "\"type\": \"create:sequenced_assembly\"";
        static string pressingType = "\"type\": \"create:pressing\"";
        static string cuttingType = "\"type\": \"create:cutting\"";
        public static string Crusher1to1(string input, bool isTag, string output, int count, double energy)
        {
            string recipe = millingType + ',' + SF.ingredients;
            if (isTag)
                recipe += $"[{SF.wrapInTag(input)}]";
            else
                recipe += $"[{SF.wrapInItem(input)}]";
            recipe += ',' + SF.results + '[' + SF.wrapInItemWithCount(output, count) + "]," + SF.processTime(energy + 20);
            return SF.wrapInCustom(recipe);
        }
        public static string Polishing(string input, bool isTag, string output)
        {
            string recipe = polishingType + ',' + SF.ingredients;
            if (isTag)
                recipe += $"[{SF.wrapInTag(input)}]";
            else
                recipe += $"[{SF.wrapInItem(input)}]";
            recipe += ',' + SF.results + $"[{SF.wrapInItem(output)}]";
            return SF.wrapInCustom(recipe);
        }
        public static string Crusher1ToMany(string input, bool isTag, List<Tuple<string, double>> l, double energy)
        {
            string recipe = millingType + ',' + SF.ingredients;
            if (isTag)
                recipe += $"[{SF.wrapInTag(input)}],";
            else
                recipe += $"[{SF.wrapInItem(input)}],";
            recipe += SF.results + '[';
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i].Item2 >= 1)
                    recipe += SF.wrapInItemWithCount(l[i].Item1, (int)l[i].Item2);
                else
                    recipe += SF.wrapInItemWithChance(l[i].Item1, l[i].Item2);
                recipe += ",";
            }
            recipe = recipe.Substring(0, recipe.Length - 1);
            recipe += "]," + SF.processTime(energy + 20);
            return SF.wrapInCustom(recipe);
        }
        public static string Filling(string input, bool isTag,string fluid, int fluidAmount, string output)
        {
            string recipe = fillingType + ',' + SF.ingredients;
            if (isTag)
                recipe += $"[{SF.wrapInTag(input)},";
            else
                recipe += $"[{SF.wrapInItem(input)},";
            recipe += '{' + SF.fluid + $"\"{fluid}\",{SF.nbtEmpty}," + SF.amount + fluidAmount + "}],";
            recipe+= SF.results + $"[{SF.wrapInItem(output)}]";
            return SF.wrapInCustom(recipe);
        }
        public static string Pressing(string input, bool isTag, string output)
        {
            string recipe = pressingType + ',' + SF.ingredients;
            if (isTag)
                recipe += $"[{SF.wrapInTag(input)}]";
            else
                recipe += $"[{SF.wrapInItem(input)}]";
            recipe += ',' + SF.results + $"[{SF.wrapInItem(output)}]";
            return SF.wrapInCustom(recipe);
        }
        public static string Sawmill(string input, bool isTag, string output, int count, int time)
        {
            string recipe = cuttingType + ',' + SF.ingredients;
            if (isTag)
                recipe += $"[{SF.wrapInTag(input)}";
            else
                recipe += $"[{SF.wrapInItem(input)}";
            if (count > 1)
                recipe += "," + SF.count(count) + "]";
            else
                recipe += "]";
            recipe += ',' + SF.results + $"[{SF.wrapInItem(output)}],"+SF.processTime(time);
            return SF.wrapInCustom(recipe);
        }

    }
}
