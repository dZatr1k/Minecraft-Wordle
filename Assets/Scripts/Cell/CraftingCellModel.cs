using MinecraftWordle.Item;
using UnityEngine.Events;

namespace MinecraftWordle.Cell
{
    public class CraftingCellModel : CellModel
    {
        public static UnityAction<CraftingCellModel> OnItemChanged;

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
            OnItemChanged?.Invoke(this);
        }

        public override void DeleteItem()
        {
            base.DeleteItem();
            OnItemChanged?.Invoke(this);
        }
    }
}