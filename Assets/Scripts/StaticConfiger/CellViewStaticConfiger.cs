using UnityEngine;
using MinecraftWordle.Cell;

namespace MinecraftWordle.StaticConfiger
{
	public class CellViewStaticConfiger : MonoBehaviour
	{
        [SerializeField] private Sprite _emptySprite;

        private void Awake()
        {
            CellView.EmptySprite = _emptySprite;
        }
    }
}
