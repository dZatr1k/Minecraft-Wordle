using System;
using System.Collections.Generic;
using UnityEngine;

namespace MinecraftWordle.Item
{
    [CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObjects/Item", order = 51)]
    public class ItemModel : ScriptableObject
    {
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

        public override bool Equals(object obj)
        {
            return obj is ItemModel model &&
                   base.Equals(obj) &&
                   name == model.name &&
                   hideFlags == model.hideFlags &&
                   EqualityComparer<Sprite>.Default.Equals(_sprite, model._sprite) &&
                   EqualityComparer<Sprite>.Default.Equals(Sprite, model.Sprite);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), name, hideFlags, _sprite, Sprite);
        }
    }
}