using System;
using System.Collections.Generic;
using System.Text;

namespace HexGridStandard
{
    public class HexStore<TKey, TValue>
    {
        List<TValue> _values;
        Dictionary<TKey, int> _keys;

        public int Count => _values.Count;

        public TValue this[TKey key] => _values[_keys[key]];

        public TValue this[int iter] => _values[iter];

        public HexStore()
        {
            _values = new List<TValue>();
            _keys = new Dictionary<TKey, int>();
        }

        public IEnumerable<TValue> All()
        {
	        for(int i = 0; i < _values.Count; i++) 
                yield return _values[i];	        
        }

        public IEnumerable<TKey> Keys()
        {
            return _keys.Keys;
        }
        public HexStore(int capacity)
        {
            _values = new List<TValue>(capacity);
            _keys = new Dictionary<TKey, int>(capacity);
        }
        public void Remove(TKey pos, Func<TKey, bool> removal)
        {
            if (!_keys.TryGetValue(pos, out _) || !removal(pos))
                return;
            var position = _keys[pos];
            _keys.Remove(pos);
            foreach(var key in _keys.Keys)
            {
                if(_keys[key] > position)
                    _keys[key]--;
            }
            _values.RemoveAt(position);
        }

        public TValue Add(
          TKey pos,
          Action<TValue> duplicateProcess,
          Func<TKey, TValue> creationProcess)
        {
            if (_keys.ContainsKey(pos))
                duplicateProcess(_values[_keys[pos]]);
            else
            {
                _values.Add(creationProcess(pos));
                _keys.Add(pos, _values.Count-1);
            }
            return _values[_values.Count-1];
        }

        internal void Clear(Action<TValue> valueCleanup)
        {
            foreach (var key in _keys.Keys)
                valueCleanup(_values[_keys[key]]);
            _values.Clear();
            _keys.Clear();
        }

        public bool ContainsKey(TKey position)
        {
            return _keys.ContainsKey(position);
        }
    }
}
