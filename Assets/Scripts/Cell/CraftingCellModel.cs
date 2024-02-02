using MinecraftWordle.Item;
using UnityEngine.Events;

namespace MinecraftWordle.Cell
{
    public class CraftingCellModel : CellModel
    {
        public static UnityAction<CraftingCellModel> ItemChanged;

        private uint _columnIndex;
        private uint _rowIndex;

        public uint ColumnIndex => _columnIndex;
        public uint RowIndex => _rowIndex;

        public CraftingCellModel(CellView view, uint columnIndex, uint rowIndex) : base(view) 
        {
            _columnIndex = columnIndex;
            _rowIndex = rowIndex;
        }

        public override void ChangeItem(ItemModel newItem)
        {
            base.ChangeItem(newItem);
            ItemChanged?.Invoke(this);
        }

        public override void DeleteItem()
        {
            base.DeleteItem();
            ItemChanged?.Invoke(this);
        }
    }
}