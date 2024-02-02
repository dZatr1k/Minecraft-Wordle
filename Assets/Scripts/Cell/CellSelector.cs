using System;
using MinecraftWordle.Item;

namespace MinecraftWordle.Cell
{
    public class CellSelector : CellPresenter
    {
        private CursorItem _cursorItem;
        public CellSelector(CellModel cellModel, CursorItem cursorItem) : base(cellModel) 
        {

            _cursorItem = cursorItem;
        }

        public override void OnCellClicked()
        {
            if(_cursorItem.IsItemSelected)
            {
                _cursorItem.DeselectItem();
                return;
            }

            if(_cellModel.Item != null)
            {
                _cursorItem.SelectItem(_cellModel.Item);
            }
        }
    }
}