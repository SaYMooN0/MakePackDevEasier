using System;
using System.Collections.Generic;

namespace MDE.Mods
{
    internal class ImmersiveEngineering
    {
        static string crusherType = "\"type\": \"immersiveengineering:crusher\"";
        static string pressingType = "\"type\":\"immersiveengineering:metal_press\"";
        static string sawmillType = "\"type\":\"immersiveengineering:sawmill\"";
        static string plateMold = "\"mold\":\"immersiveengineering:mold_plate\"";

        public static string Crusher1to1(string input, bool isTag, string output, int count, double energy)
        {
            string recipe = crusherType + ",\"secondaries\":[]," + SF.result + SF.wrapInItemWithCount(output, count) + ',' + SF.input;
            if (isTag)
                recipe += SF.wrapInTag(input);
            else
                recipe += SF.wrapInItem(input);
            recipe += ',' + SF.energyRequired(energy);
            return SF.wrapInCustomRecipeEvent(recipe);
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
            return SF.wrapInCustomRecipeEvent(recipe);
        }
        public static string Pressing(string input, bool isTag, string output)
        {
            string recipe = pressingType + ',' + plateMold+','+SF.result+SF.wrapInItem(output)+','+SF.input;
            if (isTag)
                recipe += $"{SF.wrapInTag(input)}";
            else
                recipe += $"{SF.wrapInItem(input)}";
            recipe += ','+SF.energyRequired(80);
            return SF.wrapInCustomRecipeEvent(recipe);
        }
        public static string Sawmill(string input, bool isTag, string output, int count, double energy)
        {
            string recipe = sawmillType + ",\"secondaries\":[]," + SF.result + SF.wrapInItemWithCount(output, count) + ',' +SF.energyRequired(energy/2)+','+ SF.input;
            if (isTag)
                recipe += SF.wrapInTag(input);
            else
                recipe += SF.wrapInItem(input);
            return SF.wrapInCustomRecipeEvent(recipe);
        }
    }
}
