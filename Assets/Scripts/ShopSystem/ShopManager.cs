using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Data;
using Models;
using PlayerSystem;
using UnityEngine;

namespace ShopSystem
{
    public class ShopManager : MonoBehaviour
    {
        [SerializeField] private ShopData data;
        private Player _player;
        public IReadOnlyList<ShopEntry> Items => data.items;

        #region MonoBehaviour

        private void Start()
        {
            this.Initialize();
        }

        #endregion
        
        #region Public Methods
        
        /// <summary>
        /// Attempts to purchase the specified shop entry for the current player.
        /// Withdraws the item's price from the player's wallet and adds the item to the player's inventory.
        /// </summary>
        /// <param name="entry">The shop entry to purchase. Must not be null and must exist in the current shop data.</param>
        /// <exception cref="ArgumentNullException">Thrown when the entry is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the entry is not available in the current shop.</exception>
        /// <exception cref="GameExceptions.NotEnoughWalletBalanceException">Thrown by the player's wallet when there are insufficient funds to complete the purchase.</exception>
        public void BuyItem(ShopEntry entry)
        {
            if(entry == null) { throw new ArgumentNullException(nameof(entry), "Cannot buy a null item"); }
            if(!ShopHasItem(entry)) { throw new ArgumentException("Cannot buy a non-existing item"); }
            _player.Wallet.Withdraw(entry.price);
            _player.Inventory.AddItem(entry.item);
        }
        
        #endregion
        
        #region Private Methods

        private void Initialize()
        {
            _player = SceneContext.Instance.Player;
        }

        private bool ShopHasItem(ShopEntry entry)
        {
            var existing = data.items.FirstOrDefault(i => i.item == entry.item);
            return existing != null;
        }
        
        #endregion
    }
}