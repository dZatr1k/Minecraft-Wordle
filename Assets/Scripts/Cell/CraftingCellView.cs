using MinecraftWordle.Item;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MinecraftWordle.Cell
{
    public class CraftingCellView : CellView
    {
        [SerializeField] private uint _rowIndex;
        [SerializeField] private uint _columnIndex;

        public uint RowIndex => _rowIndex;
        public uint ColumnIndex => _columnIndex;

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