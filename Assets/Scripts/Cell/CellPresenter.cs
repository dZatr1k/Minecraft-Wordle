using MinecraftWordle.Item;

namespace MinecraftWordle.Cell
{
    public abstract class CellPresenter
    {
        protected CursorItem _cursorItem;
        protected CellModel _cellModel;

        public CellPresenter(CellModel cellModel, CursorItem cursorItem)
        {
            _cellModel = cellModel;
            _cursorItem = cursorItem;
        }

        public virtual void OnCellClicked()
        {
            if(_cellModel.Item != null)
            {
                if(_cursorItem.IsItemSelected == false)
                {
                    _cursorItem.SelectItem(_cellModel.Item);
                    _cellModel.DeleteItem();
                }
                else
                {
                    if(_cursorItem.SelectedItem == _cellModel.Item)
                    {
                        _cursorItem.DeselectItem();
                    }
                }
            }
            else
            {
                if (_cursorItem.IsItemSelected)
                {
                    var deselectedItem = _cursorItem.DeselectItem();
                    _cellModel.ChangeItem(deselectedItem);
                }
            }
        }
    }
}