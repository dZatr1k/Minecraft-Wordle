using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinecraftWordle.Crafting
{
    public class CartPatternComparer : MonoBehaviour, IComparer<CraftPattern>
	{
		[SerializeField] private Craft _craft1;
		[SerializeField] private Craft _craft2;

        private void Start()
        {
            Compare(_craft1.Pattern, _craft2.Pattern);
        }

        public int Compare(CraftPattern x, CraftPattern y)
        {
            Debug.Log(x.ToString());
            x = x.GetUpLeftEdgeNormalizedPattern();
            Debug.Log(x.ToString());
            Debug.Log(y.ToString());
            y = y.GetUpLeftEdgeNormalizedPattern();
            Debug.Log(y.ToString());
            return 0;
        }
    }
}
