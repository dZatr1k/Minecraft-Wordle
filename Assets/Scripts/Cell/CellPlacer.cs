using MinecraftWordle.Item;

namespace MinecraftWordle.Cell
{
    public class CellPlacer : CellPresenter
    {
        protected CursorItem _cursorItem;
        public CellPlacer(CellModel cellModel, CursorItem cursorItem) : base(cellModel) 
        {
            _cursorItem = cursorItem;
        }

        public override void OnCellClicked()
        {
            if(_cursorItem.IsItemSelected) 
            {
                if (_cellModel.Item == null)
                    _cellModel.ChangeItem(_cursorItem.SelectedItem);
                else
                    _cursorItem.DeselectItem();
            }
            else
            {
                _cursorItem.SelectItem(_cellModel.Item);
                _cellModel.DeleteItem();
            }
        }
    }
}