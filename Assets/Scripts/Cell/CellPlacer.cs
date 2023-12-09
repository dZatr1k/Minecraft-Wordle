using MinecraftWordle.Item;

namespace MinecraftWordle.Cell
{
    public class CellPlacer : CellPresenter
    {
        public CellPlacer(CellModel cellModel) : base(cellModel) {}

        private void PlaceItem()
        {
            if(CellSelector.SelectedItem != null)
                _cellModel.ChangeItem(CellSelector.SelectedItem);
        }

        public override void OnCellClicked()
        {
            PlaceItem();
        }
    }
}