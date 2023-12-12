using MinecraftWordle.Item;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MinecraftWordle.Cell
{
    public class InventoryCellView : CellView
    {
        [SerializeField] protected ItemModel _startItem;

        public ItemModel StartItem => _startItem;

        private void OnValidate ()
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