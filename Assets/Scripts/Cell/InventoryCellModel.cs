using MinecraftWordle.Item;

namespace MinecraftWordle.Cell
{
    public class InventoryCellModel : CellModel
    {
        public InventoryCellModel(CellView view) : base(view){}

        public InventoryCellModel(CellView view, ItemModel item) : base(view)
        {
            _item = item;
        }

        public override void ChangeItem(ItemModel newSprite)
        {
            base.ChangeItem(newSprite);
        }
    }
}