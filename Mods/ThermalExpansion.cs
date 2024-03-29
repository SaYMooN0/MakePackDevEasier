﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MDE.Auxiliary_Files;

namespace MDE.Mods
{
    internal class ThermalExpansion
    {
        static string pulverizerType = "\"type\": \"thermal:pulverizer\"";
        static string fillingType = " \"type\": \"thermal:bottler\"";
        static string pressingType = "\"type\": \"thermal:press\"";
        static string sawmillType = " \"type\": \"thermal:sawmill\"";
        public static string Crusher1to1(string input, bool isTag, string output, int count, double energy)
        {
            string recipe = pulverizerType + ',' + SF.ingredient;
            if (isTag)
                recipe += $"[{SF.wrapInTag(input)}]";
            else
                recipe += $"[{SF.wrapInItem(input)}]";
            recipe += ',' + SF.result + SF.wrapInItemWithCount(output, count) + ',' + SF.energyMod(energy);
            return SF.wrapInCustomRecipeEvent(recipe);
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
            return SF.wrapInCustomRecipeEvent(recipe);
        }
        public static string Filling(string input, bool isTag, string fluid, int fluidAmount, string output)
        {
            string recipe = fillingType + ',' + SF.ingredients;
            if (isTag)
                recipe += $"[{SF.wrapInTag(input)},";
            else
                recipe += $"[{SF.wrapInItem(input)},";
            recipe += '{';
            if (fluid.Contains("forge:"))
                recipe += SF.fluidtag;
            else
                recipe += SF.fluid;
            recipe+=$"\"{fluid}\"," + SF.amount + fluidAmount + "}],";
            recipe += SF.result + $"[{SF.wrapInItem(output)}]";
            return SF.wrapInCustomRecipeEvent(recipe);
        }
        public static string Pressing(string input, bool isTag, string output)
        {
            string recipe = pressingType + ',' + SF.ingredient;
            if (isTag)
                recipe += $"{SF.wrapInTag(input)}";
            else
                recipe += $"{SF.wrapInItem(input)}";
            recipe += ',' + SF.result + $"[{SF.wrapInItem(output)}]";
            return SF.wrapInCustomRecipeEvent(recipe);
        }
        public static string Sawmill(string input, bool isTag, string output, int count, double energy)
        {
            string recipe = sawmillType + ',' + SF.ingredient;
            if (isTag)
                recipe += $"[{SF.wrapInTag(input)}]";
            else
                recipe += $"[{SF.wrapInItem(input)}]";
            recipe += ',' + SF.result+'[' + SF.wrapInItemWithCount(output, count) + "]," + SF.energyRequired(energy);
            return SF.wrapInCustomRecipeEvent(recipe);
        }
    }
}
