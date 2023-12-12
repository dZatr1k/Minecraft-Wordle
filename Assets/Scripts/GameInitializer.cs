using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using MinecraftWordle.Cell;
using MinecraftWordle.Item;

namespace MinecraftWordle.Game
{
    public class GameInitializer : MonoBehaviour
    {
        [Header("Indetifiers of view lists")]
        [SerializeField] private InventoryIndetifier _inventoryIndetifier;
        [SerializeField] private CraftingIndentifier _craftingIndetifier;

        [Header("Other")]
        [SerializeField] private CursorItem _cursorItem;

        private List<InventoryCellView> _inventoryViews;
        private List<CraftingCellView> _craftingViews;

        private void OnValidate()
        {
            _cursorItem = FindObjectOfType<CursorItem>();

            _inventoryViews = GetList<InventoryCellView, InventoryIndetifier>(ref _inventoryIndetifier);
            _craftingViews = GetList<CraftingCellView, CraftingIndentifier>(ref _craftingIndetifier);
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
            InitializeViews(_inventoryViews,
                view => new InventoryCellModel(view, view.StartItem),
                model => new CellSelector(model, _cursorItem));
        }

        private void InitializeCrafting()
        {
            InitializeViews(_craftingViews,
                view => new CraftingCellModel(view),
                model => new CellPlacer(model, _cursorItem));
        }

        private List<TResult> GetList<TResult, TIndentifier>(ref TIndentifier indentifier) 
            where TIndentifier : MonoBehaviour
            where TResult : CellView
        {
            indentifier ??= FindObjectOfType<TIndentifier>();

            if (indentifier == null)
                throw new ArgumentNullException($"Add {typeof(TIndentifier)} on Scene");

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