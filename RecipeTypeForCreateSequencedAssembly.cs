using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDE
{
    class RecipeTypeForCreateSequencedAssembly
    {
        public type Type;
        public string Fluid { get; set; }
        public string Item { get; set; }
        public int FluidAmount { get; set; }
        public RecipeTypeForCreateSequencedAssembly(type t)
        {
            this.Type = t;
        }
        public RecipeTypeForCreateSequencedAssembly(string item)
        {
            this.Type = type.AddingItem;
            Item = item;
        }
        public RecipeTypeForCreateSequencedAssembly(string fluid, int amount)
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
