using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.FriendsVersus.Data
{
    public static class ExtensionMethods
    {
        public static T ThrowIfNull<T>(this T instance, string arg)
        {
            if (instance == null) throw new ArgumentNullException(arg);
            
            return instance;
        }
    }
}
