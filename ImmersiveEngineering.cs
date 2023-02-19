using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDE
{
    internal class ImmersiveEngineering
    {
        static string millingType = "\"type\": \"immersiveengineering:crusher\"";
        public static string Crusher1to1(string input, bool isTag, string output, int count, double energy)
        {
            string recipe = millingType + ",\"secondaries\":[]," + SF.result + SF.wrapInItem(output, count) +',' +SF.input;
            if (isTag)
                recipe += SF.wrapInTag(input);
            else
                recipe += SF.wrapInItem(input);
            recipe += ',' + SF.energyRequired(energy);
            return SF.wrapInCustom(recipe);
        }
    }
}
