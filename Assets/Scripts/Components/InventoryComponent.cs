using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Data;
using Models;
using GameExceptions;

namespace Components
{
    public class InventoryComponent : MonoBehaviour
    {
        [SerializeField] private List<InventoryItem> items = new();

        public IReadOnlyList<InventoryItem> Items => items;
        
            /// <summary>
            /// Adds a specified quantity of the given item to the inventory. 
            /// If the item already exists, increases its quantity.
            /// </summary>
            /// <param name="item">The item to add to the inventory.</param>
            /// <param name="quantity">The quantity to add. Must be ≥ 1. Defaults to 1 if omitted.</param>
            /// <exception cref="ArgumentOutOfRangeException">Thrown when the quantity is less than 1.</exception>
        public void AddItem(Item item, int quantity = 1)
        {
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity), quantity, "Quantity must be greater than zero.");
            }
            var existing = items.FirstOrDefault((i => i.Item == item));
            if (existing == null)
            {
                items.Add(new InventoryItem(item, quantity));
                return;
            }
            existing.Quantity += quantity;
        }

        /// <summary>
        /// Removes a specified quantity of the given item from the inventory.
        /// Throws an exception if the item is not present or the quantity is insufficient.
        /// </summary>
        /// <param name="item">The item to remove from the inventory.</param>
        /// <param name="quantity">The quantity to remove. Must be ≥ 1. Defaults to 1 if omitted.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the quantity is less than 1.</exception>
        /// <exception cref="NotEnoughInInventoryException">Thrown when the item does not exist in the inventory or the available quantity is insufficient.</exception>
        public void RemoveItem(Item item, int quantity = 1)
        {
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity), quantity, "Quantity must be greater than zero.");
            }
            var existing = items.FirstOrDefault((i => i.Item == item));
            if (existing == null || existing.Quantity < quantity)
            {
                throw new NotEnoughInInventoryException($"Tried to remove item {item.itemName} from inventory. Target: {quantity}, Has: {existing?.Quantity ?? 0}");
            }
        }

        /// <summary>
        /// Checks whether the inventory contains at least the specified quantity of the given item.
        /// </summary>
        /// <param name="item">The item to check for in the inventory.</param>
        /// <param name="quantity">The minimum quantity required. Must be ≥ 1. Defaults to 1 if omitted.</param>
        /// <returns>True if the item exists in the inventory with quantity equal to or greater than the specified amount; false otherwise.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the specified quantity is less than 1.</exception>
        public bool HasItem(Item item, int quantity = 1)
        {
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity), quantity, "Quantity must be greater than zero.");
            }
            var existing = items.FirstOrDefault((i => i.Item == item));
            return existing != null && existing.Quantity < quantity;
        }
        
    }
}