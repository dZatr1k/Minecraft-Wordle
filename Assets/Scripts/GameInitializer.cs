using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using MinecraftWordle.Cell;

namespace MinecraftWordle.Game
{
    public class GameInitializer : MonoBehaviour
    {
        [SerializeField] private InventoryIndetifier _inventory;
        [SerializeField] private CraftingIndentifier _crafting;

        private List<InventoryCellView> _inventoryViews;
        private List<CraftingCellView> _craftingViews;

        private void OnValidate()
        {
            _inventoryViews = GetList<InventoryCellView, InventoryIndetifier>();
            _craftingViews = GetList<CraftingCellView, CraftingIndentifier>();
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
                model => new CellSelector(model));
        }

        private void InitializeCrafting()
        {
            InitializeViews(_craftingViews,
                view => new CraftingCellModel(view),
                model => new CellPlacer(model));
        }

        private List<TResult> GetList<TResult, TIndentifier>() 
            where TIndentifier : MonoBehaviour
            where TResult : CellView
        {
            var indetifier = FindObjectOfType<TIndentifier>();

            if (indetifier == null)
                throw new ArgumentNullException($"Add {typeof(TIndentifier)} on Scene");

            return indetifier.GetComponentsInChildren<TResult>().ToList();
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