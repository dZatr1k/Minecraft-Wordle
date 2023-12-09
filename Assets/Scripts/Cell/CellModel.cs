using MinecraftWordle.Item;
using UnityEngine;

namespace MinecraftWordle.Cell 
{
    public abstract class CellModel
    {
        protected CellView _view;
        protected ItemModel _item;

        public ItemModel Item => _item;

        public CellModel(CellView view)
        {
            _view = view;
        }

        public virtual void ChangeItem(ItemModel newItem)
        {
            _item = newItem;
            _view.DisplayItem(_item);
        }
    }
}