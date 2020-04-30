using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    public abstract class Storage<TItem>
    {
        private readonly List<TItem> _Items = new List<TItem>();

        public int Count => _Items.Count;

        public TItem this[int index]
        {
            get
            {
                return _Items[index];
            }
            set
            {
                if (_Items.Contains(value)) return;
                _Items[index] = value;
            }
        }

        public void Add(TItem item)
        {
            if(_Items.Contains(item)) return;
            _Items.Add(item);
        }

        public bool Remove(TItem item)
        {
            return _Items.Remove(item);
        }

        public bool IsContains(TItem item)
        {
            return _Items.Contains(item);
        }

        public void Clear()
        {
            _Items.Clear();
        }
    }
}
