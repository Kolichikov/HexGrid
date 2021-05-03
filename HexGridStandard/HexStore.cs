using System;
using System.Collections.Generic;
using System.Text;

namespace HexGridStandard
{
    public class HexStore<TKey, TValue>
    {
        public Dictionary<TKey, TValue> _store {get;set; }

        public int Count => _store.Count;

        public TValue this[TKey key] => _store[key];

        public HexStore()
        {
             _store = new Dictionary<TKey, TValue>();
        }

        public HexStore(int capacity)
        {
            _store = new Dictionary<TKey, TValue>(capacity);
        }
        public void Remove(TKey pos, Func<TKey, bool> removal)
        {
            if (!_store.TryGetValue(pos, out _) || !removal(pos))
                return;
            _store.Remove(pos);
        }

        public TValue Add(
          TKey pos,
          Action<TValue> duplicateProcess,
          Func<TKey, TValue> creationProcess)
        {
            if (_store.ContainsKey(pos))
                duplicateProcess(_store[pos]);
            else
                _store.Add(pos, creationProcess(pos));
            return _store[pos];
        }

        internal void Clear(Action<TValue> valueCleanup)
        {
            foreach (var key in _store.Keys)
                valueCleanup(_store[key]);
            _store.Clear();
        }
    }
}
