using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.System.Collection.Concurrent
{
    public class ConcurrentHashSet<T> : IEnumerable<T>
    {
        // Fields -------------------------------------------

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        readonly ConcurrentDictionary<T, object> dic;


        // Ctor ---------------------------------------------

        public ConcurrentHashSet()
        {
            dic = new ConcurrentDictionary<T, object>();
        }

        public ConcurrentHashSet(IEnumerable<T> initialItems)
        {
            if (initialItems == null)
                throw new ArgumentNullException(nameof(initialItems));

            dic = new ConcurrentDictionary<T, object>(initialItems.Select(x => new KeyValuePair<T, object>(x, null)));
        }


        // Read Through Props -------------------------------

        public int Count => dic.Count;


        // Methods ------------------------------------------

        public bool TryAdd(T obj) => dic.TryAdd(obj, null);

        public bool TryRemove(T obj)
        {
            object _;
            return dic.TryRemove(obj, out _);
        }

        public bool Contains(T obj) => dic.ContainsKey(obj);


        // IEnumerable<T> -----------------------------------

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var kvp in dic)
                yield return kvp.Key;
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
