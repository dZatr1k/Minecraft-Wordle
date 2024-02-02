using System;
using UnityEngine;

namespace MinecraftWordle.Item
{
	public class CursorItem : MonoBehaviour
	{
        [SerializeField] private SpriteRenderer _followerSpriteRenderer;

        private ItemModel _selectedItem;

        public ItemModel SelectedItem => _selectedItem;
        public bool IsItemSelected => _selectedItem != null;

        private void Update()
        {
            if(IsItemSelected)
                FollowCursor();
        }

        private void FollowCursor()
        {
            _followerSpriteRenderer.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        private ItemModel ChangeItem(ItemModel newItem)
        {
            var lastSelectedItem = _selectedItem;
            _selectedItem = newItem;
            _followerSpriteRenderer.sprite = newItem == null ? null : newItem.Sprite;
            return lastSelectedItem;
        }

        public void SelectItem(ItemModel item)
        {
            if (item == null)
                throw new ArgumentException("Item was null. Use DeselectItem instead.");
            ChangeItem(item);
        }

        public ItemModel DeselectItem()
        {
            return ChangeItem(null);
        }
    }
}
