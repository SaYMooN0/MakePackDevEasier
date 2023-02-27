﻿using System;

namespace MDE.Mods
{
    internal class Mekanism
    {
        static string millingType = "\"type\": \"mekanism:crushing\"";
        static string polishingType = "\"type\": \"mekanism:enriching\"";
        public static string Crusher1to1(string input, bool isTag, string output, int count)
        {
            string recipe = millingType + ',' + SF.input + '{' + SF.ingredient;
            if (isTag)
                recipe += SF.wrapInTag(input);
            else
                recipe += SF.wrapInItem(input);
            recipe += "}," + SF.output + SF.wrapInItemWithCount(output, count);
            return SF.wrapInCustom(recipe);
        }
        public static string Polishing(string input, bool isTag, string output)//WIP
        {
            string recipe = polishingType + ',' + SF.input + '{' + SF.ingredient;
            if (isTag)
                recipe += SF.wrapInTag(input);
            else
                recipe += SF.wrapInItem(input);
            recipe += "}," + SF.output + SF.wrapInItem(output);
            return SF.wrapInCustom(recipe);
        }
    }
}