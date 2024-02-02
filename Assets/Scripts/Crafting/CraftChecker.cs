using MinecraftWordle.Item;
using System.Collections.Generic;
using UnityEngine;

namespace MinecraftWordle.Crafting
{
	public class CraftChecker : MonoBehaviour
	{
		[SerializeField] private List<Craft> _crafts;
		private IComparer<CraftPattern> _comparer;

        private void Awake()
        {
            _comparer = new CraftPatternComparer();
        }

        public ItemModel FindCraftBy(CraftPattern pattern)
        {
            foreach (var craft in _crafts)
            {
                Debug.Log(pattern);
                Debug.Log(craft.Pattern);
                if (_comparer.Compare(pattern, craft.Pattern) == 0)
                    return craft.Result;
            }
            return null;
        }
    }
}
