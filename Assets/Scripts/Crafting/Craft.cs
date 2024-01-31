using MinecraftWordle.Item;
using System;
using UnityEngine;

namespace MinecraftWordle.Crafting
{
    [CreateAssetMenu(fileName = "NewCraft", menuName = "ScriptableObjects/Craft", order = 51)]
    public class Craft : ScriptableObject
	{
		[SerializeField] private CraftPattern _pattern;
		[SerializeField] private ItemModel _result;
        [SerializeField] private uint _lineItemCount = 3;

        public CraftPattern Pattern => _pattern;
		public ItemModel Result => _result;

        private void OnValidate()
        {
            if(_pattern == null)
            {
                _pattern = new CraftPattern(_lineItemCount);
                return;
            }

            if(_pattern.Length != _lineItemCount)
            {
                _pattern = new CraftPattern(_lineItemCount);
            }
        }
	}
}
