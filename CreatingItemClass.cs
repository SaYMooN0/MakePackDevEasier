using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace MDE.Recipes_Types
{
    class CreatingItemClass
    {
        
        public static string CreateItem(string name, string texture,  string stackSize)
        {
          
            string str = SF.wrapInCreateEvent(texture.Replace(".png", string.Empty))+ ".displayName(\""+name+"\")" + ".texture(\""+texture+"\")" + ".maxStackSize("+stackSize+")";
            return SF.wrapInItemRegistryEvent ("\n"+str+"\n");
        }
        public static void FormatNameField(ref TextBox TB)
        {
            string name = TB.Text;
            name = name.Replace("_", " ");
            name = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name);
            TB.Text = name;
        }
    }
}
