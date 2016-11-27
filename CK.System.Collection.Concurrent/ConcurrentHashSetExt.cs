using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.System.Collection.Concurrent
{
    public static class ConcurrentHashSetExt
    {
        public static ConcurrentHashSet<T> ToConcurrentHashSet<T>(this IEnumerable<T> items) => new ConcurrentHashSet<T>(items);
    }
}
