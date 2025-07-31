using Models;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "ShopData", menuName = "Shop/Shop Data")]
    public class ShopData : ScriptableObject
    {
        public ShopEntry[] items;

        private void OnValidate()
        {
            foreach (var item in items)
            {
                if (item.price >= 0) continue;
                LogHelper.LogWarning("Price cannot be less than zero. Setting to 0.");
                item.price = 0;
            }
        }
    }
}
