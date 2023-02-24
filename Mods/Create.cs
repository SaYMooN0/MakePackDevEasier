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
        public static string Polishing(string input, bool isTag, string output)//WIP
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
    }
}
