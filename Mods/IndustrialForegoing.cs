using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDE.Auxiliary_Files;

namespace MDE.Mods
{
    internal class IndustrialForegoing
    {
        static string fillingType = " \"industrialforegoing:dissolution_chamber\"";
     
        public static string Filling(string input, bool isTag, string fluid, int fluidAmount, string output)
        {
            string recipe = SF.input ;
            if (isTag)
                recipe += $"[{SF.wrapInTag(input)}";
            else
                recipe += $"[{SF.wrapInItem(input)}";
            recipe += "]," + SF.wrapInFluidName(fluid, fluidAmount)+","+SF.processTime((int)(fluidAmount/15+30))+","+SF.output+SF.wrapInItemWithCount(output,1)+",";
            recipe += fillingType;
            return SF.wrapInCustomRecipeEvent(recipe);
        }
    }
}
