using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace api.FriendsVersus.Data.Utility
{
    public class Mapper : IMapper
    {
        public Mapper() { }

        /*
        public T MapData<T>(SqliteDataReader reader) where T : class, new()
        {
            reader.ThrowIfNull("reader");

            
        }
        public IEnumerable<PropertyInfo> getProperties<T>()
        {
            return typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }
        */
    }
}
