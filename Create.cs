using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MDE
{
    internal class Create
    {

        static string millingType = "\"type\": \"create:milling\"";
        public static string Crusher1to1(string input, bool isTag, string output, int count, double energy)
        {
            string recipe = millingType+','+SF.ingredients;
            if (isTag)
                recipe += $"[{SF.wrapInTag(input)}]";
            else
                recipe += $"[{SF.wrapInItem(input)}]";
            recipe += ','+SF.result + SF.wrapInItem(output, count)+','+SF.processTime(energy+20);
            return SF.wrapInCustom(recipe);
        }
    }
}
