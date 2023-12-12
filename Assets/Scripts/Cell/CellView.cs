using System;
using MinecraftWordle.Item;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace MinecraftWordle.Cell
{
    public abstract class CellView : MonoBehaviour, IPointerClickHandler
    {
        protected static Sprite _emptySprite;

        public static Sprite EmptySprite
        {
            get
            {
                return _emptySprite;
            }
            set
            {
                _emptySprite = value;
            }
        }

        [SerializeField] protected Image _cellImage;
        [SerializeField] protected Image _itemImage;

        protected CellPresenter _presenter;

        public void Init(CellPresenter presenter)
        {
            _presenter = presenter;
        }

        public virtual void DisplayItem(ItemModel itemModel)
        {
            if (itemModel == null)
                throw new ArgumentNullException("You're trying display null ItemModel. Use DisplayEmpty instead.");

            _itemImage.sprite = itemModel.Sprite;
        }

        public virtual void DisplayEmpty()
        {
            _itemImage.sprite = _emptySprite;
        }

        public virtual void OnPointerClick(PointerEventData eventData)
        {
            _presenter.OnCellClicked();
        }
    }
}