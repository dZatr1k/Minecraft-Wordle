using System;
using System.Collections.Generic;
using UnityEngine;

namespace MinecraftWordle.Item
{
    [CreateAssetMenu(fileName = "NewItem", menuName = "ScriptableObjects/Item", order = 51)]
    public class ItemModel : ScriptableObject
    {
        [SerializeField] private uint _index;
        [SerializeField] private Sprite _sprite;

        public Sprite Sprite 
        {
            get
            {
                return _sprite;
            }
            set
            {
                _sprite = value;
            }
        }
        public int Index => (int)_index;

        public bool Compare(ItemModel other)
        {
            return other._index == _index;
        }
    }
}