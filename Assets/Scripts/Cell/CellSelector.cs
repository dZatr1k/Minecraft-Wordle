using System;
using MinecraftWordle.Item;

namespace MinecraftWordle.Cell
{
    public class CellSelector : CellPresenter
    {
        private static ItemModel _selectedItem;

        public static ItemModel SelectedItem => _selectedItem;
        
        public CellSelector(CellModel cellModel, CursorItem cursorItem) : base(cellModel, cursorItem) {}

        public override void OnCellClicked()
        {
            base.OnCellClicked();
        }
    }
}