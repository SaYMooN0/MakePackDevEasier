using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDE.Mods
{
    class CreateSequencedAssembly
    {

        static string assemblyType = "\"type\": \"create:sequenced_assembly\"";
        public static string SequencedAssembly(List<RecipeTypeForCreateSequencedAssembly> r, string itemIn, string itemTrans, string itemOut, bool isTag, int loops)
        {
            string recipe = assemblyType + "," + SF.ingredient;
            if (isTag)
                recipe += SF.wrapInTag(itemIn);
            else
                recipe += SF.wrapInItem(itemIn);
            recipe += ',' + SF.transitional + SF.wrapInItem(itemTrans) + ',' + SF.sequence + '[';
            string auxiliary="";
            for (int i = 0; i < r.Count; i++)
            {
                switch (r[i].Type)
                {
                    case type.Pressing:
                        auxiliary = Create.Pressing(itemTrans, false, itemTrans);
                        break;
                    case type.Sawmill:
                        auxiliary = Create.Sawmill(itemTrans, false, itemTrans, 1, 60);
                        break;
                    case type.Polishing:
                        auxiliary = Create.Polishing(itemTrans, false, itemTrans);
                        break;
                    case type.Filling:
                        auxiliary = Create.Filling(itemTrans, false,itemTrans, r[i].FluidAmount, r[i].Fluid);
                        break;
                    case type.AddingItem:
                        auxiliary = Create.Deploying(itemTrans, r[i].Item, itemTrans, false);
                        break;
                    default: break;
                }
                recipe += SF.removeWraping(auxiliary);
                recipe += ',';
            }
            recipe += "],"+SF.results+"["+SF.wrapInItem(itemOut)+"],"+SF.loops(loops);
            return SF.wrapInCustomRecipeEvent(recipe);
        }
       
    }
}
