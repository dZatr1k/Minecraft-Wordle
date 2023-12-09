using System;
using MinecraftWordle.Item;

namespace MinecraftWordle.Cell
{
    public class CellSelector : CellPresenter
    {
        private static ItemModel _selectedItem;

        public static ItemModel SelectedItem => _selectedItem;
        
        public CellSelector(CellModel cellModel) : base(cellModel) {}

        public override void OnCellClicked()
        {
            if(_cellModel.Item != null)
                _selectedItem = _cellModel.Item;
        }
    }
}