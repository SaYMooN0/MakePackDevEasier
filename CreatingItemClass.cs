using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MDE.Recipes_Types
{
    class CreatingItemClass
    {
        
        public static string CreateItem(string name,  string stackSize)
        {
            string str = SF.wrapInCreateEvent(name)+".maxStackSize("+stackSize+")";
            return SF.wrapInItemRegistryEvent (str);
        }
    }
}
