using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "Item", menuName = "Shop/Item")]
    public class Item : ScriptableObject
    {
        public string itemName;
        public Sprite icon;
        [TextArea]
        public string description;
    }
}
