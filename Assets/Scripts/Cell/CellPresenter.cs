using MinecraftWordle.Item;

namespace MinecraftWordle.Cell
{
    public abstract class CellPresenter
    {
        protected CellModel _cellModel;

        public CellModel CellModel => _cellModel;

        public CellPresenter(CellModel cellModel)
        {
            _cellModel = cellModel;
        }

        public abstract void OnCellClicked();
    }
}