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
    }
}