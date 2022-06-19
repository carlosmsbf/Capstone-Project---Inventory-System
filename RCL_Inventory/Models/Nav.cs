using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCL_Inventory.Models
{
    public class Nav
    {
        //Static helper method (in a static class that returns the string "active" for bootstrap CSS styling in the parameters match).

        public static string Active(string value, string current)
        {
            return (value == current) ? "active" : "";
        }
    }
}
