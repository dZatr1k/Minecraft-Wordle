using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using MinecraftWordle.Cell;
using MinecraftWordle.Item;
using MinecraftWordle.Extensions;

namespace MinecraftWordle.Game
{
    public class GameInitializer : MonoBehaviour
    {
        [Header("Indetifiers of view lists")]
        [SerializeField] private Inventory _inventory;
        [SerializeField] private CraftingTable _craftingTable;

        [Header("Items")]
        [SerializeField] private List<ItemModel> _items;

        [Header("Other")]
        [SerializeField] private CursorItem _cursorItem;

        private List<InventoryCellView> _inventoryViews;
        private List<CraftingCellView> _craftingViews;

        private void OnValidate()
        {
            _cursorItem = FindObjectOfType<CursorItem>();

            _inventoryViews = GetList<InventoryCellView, Inventory>(ref _inventory);
            _craftingViews = GetList<CraftingCellView, CraftingTable>(ref _craftingTable);
        }

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            InitializeInventory();
            InitializeCrafting();
        }

        private void InitializeInventory()
        {
            _items.Shuffle();
            for (int i = 0; i < Mathf.Min(_inventoryViews.Count, _items.Count); i++)
            {
                _inventoryViews[i].StartItem = _items[i];
            }

            InitializeViews(_inventoryViews,
                view => new InventoryCellModel(view, view.StartItem),
                model => new CellSelector(model, _cursorItem));
        }

        private void InitializeCrafting()
        {
            InitializeViews(_craftingViews,
                view => new CraftingCellModel(view, view.ColumnIndex, view.RowIndex),
                model => new CellPlacer(model, _cursorItem));

            _craftingTable.Init(_craftingViews.Select(x => (CraftingCellModel)x.CellPresenter.CellModel));
        }

        private List<TResult> GetList<TResult, TIndentifier>(ref TIndentifier indentifier) 
            where TIndentifier : MonoBehaviour
            where TResult : CellView
        {
            indentifier ??= FindObjectOfType<TIndentifier>();

            if (indentifier == null)
                throw new ArgumentNullException($"Add {typeof(TIndentifier).Name} on Scene");

            return indentifier.GetComponentsInChildren<TResult>().ToList();
        }

        private void InitializeViews<TView>(List<TView> views, Func<TView, CellModel> modelGenerator, Func<CellModel, CellPresenter> presenterGenerator)
            where TView : CellView
        {
            views.ForEach(view =>
            {
                var model = modelGenerator(view);
                var presenter = presenterGenerator(model);
                view.Init(presenter);
            });
        }
    }
}