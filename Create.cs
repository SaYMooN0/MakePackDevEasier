using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MDE
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
            recipe += ',' + SF.results + SF.wrapInItem(output, count) + ',' + SF.processTime(energy + 20);
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
    }
}
