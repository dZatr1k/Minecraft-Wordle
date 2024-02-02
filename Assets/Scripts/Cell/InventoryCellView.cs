using MinecraftWordle.Item;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MinecraftWordle.Cell
{
    public class InventoryCellView : CellView
    {
        private ItemModel _startItem;

        public ItemModel StartItem
        {
            get { return _startItem; }
            set { _startItem = value; }
        }

        private void Start()
        {
            if(_startItem != null)
            {
                DisplayItem(_startItem);
            }
        }

        public override void DisplayItem(ItemModel itemModel)
        {
            base.DisplayItem(itemModel);
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);
        }
    }
}