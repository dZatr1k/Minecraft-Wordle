using MinecraftWordle.Crafting;
using UnityEngine;

namespace MinecraftWordle.Cell
{
    public class CellResulter : CellPresenter
    {
        private CraftChecker _checker;
        public CellResulter(CellModel cellModel, CraftChecker checker) : base(cellModel)
        {
            _checker = checker;
            CraftingTable.CraftPatternChanged += OnCraftPatternChanged;
        }

        private void OnCraftPatternChanged(CraftPattern pattern)
        {
            var newItem = _checker.FindCraftBy(pattern);
            Debug.Log(newItem);
            if (newItem != null)
            {
                _cellModel.ChangeItem(newItem);
            }
            else
            {
                _cellModel.DeleteItem();
            }
        }

        public override void OnCellClicked()
        {
            
        }
    }
}
