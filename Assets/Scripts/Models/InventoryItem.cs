using UnityEngine;
using Data;

namespace Models
{
    [System.Serializable]
    public class InventoryItem
    {
        public Item Item { get; private set; }
        public int Quantity { get; set; }

        public InventoryItem(Item item, int quantity)
        {
            Item = item;
            Quantity = quantity;
        }
    }
}