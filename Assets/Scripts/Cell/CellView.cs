using MinecraftWordle.Item;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace MinecraftWordle.Cell
{
    public abstract class CellView : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] protected Image _cellImage;
        [SerializeField] protected Image _itemImage;

        protected CellPresenter _presenter;

        public void Init(CellPresenter presenter)
        {
            _presenter = presenter;
        }

        public virtual void DisplayItem(ItemModel itemModel)
        {
            _itemImage.sprite = itemModel.Sprite;
        }

        public virtual void OnPointerClick(PointerEventData eventData)
        {
            _presenter.OnCellClicked();
        }
    }
}