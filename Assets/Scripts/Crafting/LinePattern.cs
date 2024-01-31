using MinecraftWordle.Extensions;
using MinecraftWordle.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MinecraftWordle.Crafting
{
	[Serializable]
	public class LinePattern
	{
		[SerializeField] private ItemModel[] _items;

		private uint _itemCount;

        public int Length => (int)_itemCount;

		public LinePattern(uint itemCount)
		{
            _itemCount = itemCount;
            _items = new ItemModel[(int)itemCount];
		}

        public bool IsEmpty()
        {
            return _items.All(x => x == null);
        }

        public int GetNonEmptyItemIndex()
        {
            int i = 0;
            for (; i < _itemCount; i++)
            {
                if (_items[i] != null)
                    return i;
            }
            return i;
        }

        public void Resize(int startIndex)
        {
            var list = new List<ItemModel>(_items);
            list = list.GetRange(startIndex, (Length - startIndex));
            list.FillTo(Length);
            _items = list.ToArray();
        }

        public override string ToString()
        {
            var result = "";
            _items.ToList().ForEach(x => result += x != null ? "1 " : "0 ");
            return result;
        }
    }
}
