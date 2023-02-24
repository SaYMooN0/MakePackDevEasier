using System;
using System.Collections.Generic;

namespace MDE.Mods
{
    internal class ImmersiveEngineering
    {
        static string crusherType = "\"type\": \"immersiveengineering:crusher\"";
        public static string Crusher1to1(string input, bool isTag, string output, int count, double energy)
        {
            string recipe = crusherType + ",\"secondaries\":[]," + SF.result + SF.wrapInItemWithCount(output, count) + ',' + SF.input;
            if (isTag)
                recipe += SF.wrapInTag(input);
            else
                recipe += SF.wrapInItem(input);
            recipe += ',' + SF.energyRequired(energy);
            return SF.wrapInCustom(recipe);
        }
        public static string Crusher1ToMany(string input, bool isTag, List<Tuple<string, double>> l, double energy)
        {
            string recipe = crusherType + ",\"secondaries\":[";
            for (int i = 1; i < l.Count; i++)
            {
                recipe += '{';
                if (l[i].Item2 >= 1)
                    recipe += SF.count((int)l[i].Item2) + ',' + SF.output + SF.wrapInItem(l[i].Item1);
                else
                    recipe += SF.chance(l[i].Item2) + ',' + SF.output + SF.wrapInItem(l[i].Item1);
                recipe += "},";
            }
            recipe = recipe.Substring(0, recipe.Length - 1);
            recipe += "]," + SF.result + SF.wrapInItemWithCount(l[0].Item1, (int)l[0].Item2) + "," + SF.input;
            if (isTag)
                recipe += $"{SF.wrapInTag(input)}";
            else
                recipe += $"{SF.wrapInItem(input)}";
            recipe += ',' + SF.energyRequired(energy);
            return SF.wrapInCustom(recipe);
        }
    }
}
