using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDE.Auxiliary_Files
{
    class RecipeTypeForCreateSequencedAssembly
    {
        public type Type;
        public string Fluid { get; set; }
        public string Item { get; set; }
        public int FluidAmount { get; set; }
        public RecipeTypeForCreateSequencedAssembly(type t)
        {
            Type = t;
        }
        public RecipeTypeForCreateSequencedAssembly(string item)
        {
            Type = type.AddingItem;
            Item = item;
        }
        public RecipeTypeForCreateSequencedAssembly(string fluid, int amount)
        {
            Type = type.Filling;
            Fluid = fluid;
            FluidAmount = amount;
        }
    }
    enum type
    {
        Pressing,
        Filling,
        Polishing,
        AddingItem,
        Sawmill
    }
}
