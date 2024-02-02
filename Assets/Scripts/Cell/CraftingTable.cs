using MinecraftWordle.Crafting;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using MinecraftWordle.Item;
using System;
using UnityEngine.Events;

namespace MinecraftWordle.Cell
{
	public class CraftingTable : MonoBehaviour
	{
        public static UnityAction<CraftPattern> CraftPatternChanged;

        [SerializeField] private uint _itemLineCount = 3;
		private CraftPattern _pattern;

        private void Awake()
        {
            _pattern = new CraftPattern(_itemLineCount);
        }

        private void OnEnable()
        {
            CraftingCellModel.ItemChanged += OnCellItemChanged;
        }

        private void OnDisable()
        {
            CraftingCellModel.ItemChanged -= OnCellItemChanged;
        }

        private void OnCellItemChanged(CraftingCellModel cell)
        {
            SetItemToPattern(cell.Item, cell.RowIndex, cell.ColumnIndex);
            CraftPatternChanged?.Invoke(_pattern);
        }

        private void SetItemToPattern(ItemModel item, uint row, uint column)
        {
            _pattern.SetItem(item, row, column);
        }
    }
}
