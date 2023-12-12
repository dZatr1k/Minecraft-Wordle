using MinecraftWordle.Item;

namespace MinecraftWordle.Cell
{
    public class CraftingCellModel : CellModel
    {
        public CraftingCellModel(CellView view) : base(view) {}

        public override void ChangeItem(ItemModel newItem)
        {
            base.ChangeItem(newItem);
        }
    }
}