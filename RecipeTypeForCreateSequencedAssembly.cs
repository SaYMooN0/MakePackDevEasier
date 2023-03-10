using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDE
{
    class RecipeTypeForCreateSequencedAssembly
    {
        type Type;
        string Fluid { get; set; }
        string Item { get; set; }
        int FluidAmount { get; set; }
        RecipeTypeForCreateSequencedAssembly(type t)
        {
            this.Type = t;
        }
        RecipeTypeForCreateSequencedAssembly(string item)
        {
            this.Type = type.AddingItem;
            Item = item;
        }
        RecipeTypeForCreateSequencedAssembly(string fluid, int amount)
        {
            this.Type = type.Filling;
            Fluid= fluid;
            FluidAmount= amount;
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
