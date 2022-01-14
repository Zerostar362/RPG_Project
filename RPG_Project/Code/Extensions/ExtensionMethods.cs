using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Project.Code.Extensions
{
    public static class ExtensionMethods
    {
        public static double ToDouble(this Int32 num) 
        {
            return Convert.ToDouble(num);
        }

        public static int ToInt(this double num) 
        {
            return (int)Convert.ToInt32(num);
        }
    }
}
