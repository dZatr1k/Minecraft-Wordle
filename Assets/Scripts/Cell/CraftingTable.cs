using MinecraftWordle.Crafting;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using MinecraftWordle.Item;
using System;

namespace MinecraftWordle.Cell
{
	public class CraftingTable : MonoBehaviour
	{
        private uint _lineItemCount = 3;
        private List<CraftingCellModel> _craftingCellModels = new List<CraftingCellModel>();
		private CraftPattern _pattern;

        private void OnEnable()
        {
            CraftingCellModel.OnItemChanged += OnCellItemChanged;
        }

        private void OnDisable()
        {
            CraftingCellModel.OnItemChanged -= OnCellItemChanged;
        }

        private void OnCellItemChanged(CraftingCellModel cell)
        {
            SetItemToPattern(cell.Item, cell.RowIndex, cell.ColumnIndex);
        }

        private void SetItemToPattern(ItemModel item, uint row, uint column)
        {
            _pattern.SetItem(item, row, column);
        }

        public void Init(IEnumerable<CraftingCellModel> craftingCellModels)
        {

            _pattern = new CraftPattern(_lineItemCount);
            _craftingCellModels = craftingCellModels.ToList();
            
            _lineItemCount = (uint)Mathf.Sqrt(_craftingCellModels.Count);
            
            if(_lineItemCount * _lineItemCount != _craftingCellModels.Count)
            {
                _lineItemCount = 0;
                _craftingCellModels = null;
                throw new ArgumentException("Incorect cell models count.");
            } 
            
            for (int i = 0; i < _lineItemCount * _lineItemCount; i++)
            {
                SetItemToPattern(_craftingCellModels[i].Item, (uint)(i / 3), (uint)(i % 3));
            }
        }
    }
}
