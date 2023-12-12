using System;
using MinecraftWordle.Item;

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
            if(newItem == null)
                throw new ArgumentNullException("You're trying to set null ItemModel. Use DeleteItem instead.");

            _item = newItem;
            _view.DisplayItem(_item);
        }

        public virtual void DeleteItem()
        {
            _item = null;
            _view.DisplayEmpty();
        }
    }
}