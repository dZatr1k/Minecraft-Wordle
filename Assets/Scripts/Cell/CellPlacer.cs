using MinecraftWordle.Item;

namespace MinecraftWordle.Cell
{
    public class CellPlacer : CellPresenter
    {
        public CellPlacer(CellModel cellModel, CursorItem cursorItem) : base(cellModel, cursorItem) {}

        public override void OnCellClicked()
        {
            base.OnCellClicked();
        }
    }
}