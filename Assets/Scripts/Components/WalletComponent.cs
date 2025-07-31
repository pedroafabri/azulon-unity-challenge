using System;
using UnityEngine;
using GameExceptions;

namespace Components
{
    public class WalletComponent : MonoBehaviour
    {
        /// <summary>
        /// The current Balance of this wallet
        /// </summary>
        public int Balance { get; private set; }
        
        /// <summary>
        /// Deposits a specified amount into this wallet's balance.
        /// </summary>
        /// <param name="amount">The value to deposit. Must be ≥ 0.</param>
        /// <returns>The new amount of Coins in this wallet.</returns>
        /// <exception cref="ArgumentException">Thrown when the deposit amount is negative.</exception>
        public int Deposit(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Tried to deposit a negative amount.");
            }
            Balance += amount;
            return Balance;
        }

        /// <summary>
        /// Withdraws a specified amount of this wallet's balance.
        /// Use <see cref="CanAfford"/> to check before calling this method if you want to avoid exceptions.
        /// </summary>
        /// <param name="amount">The value to withdraw. Must be ≥ 0.</param>
        /// <returns>The new amount of Coins in this wallet.</returns>
        /// <exception cref="ArgumentException">Thrown when the amount is negative.</exception>
        /// <exception cref="NotEnoughWalletBalanceException">Thrown when there are insufficient funds to complete the withdrawal.</exception>
        public int Withdraw(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Tried to withdraw a negative amount.");
            }
            if (Balance < amount)
            {
                throw new NotEnoughWalletBalanceException($"Tried to withdraw {amount} but wallet only has {Balance}.");
            }
            Balance -= amount;
            return Balance;
        }

        /// <summary>
        /// Checks whether the wallet has enough balance to cover the specified amount.
        /// </summary>
        /// <param name="amount">The amount to check against the current balance.</param>
        /// <returns>True if the current balance is greater than or equal to the specified amount; false otherwise.</returns>
        public bool CanAfford(int amount)
        {
            return Balance >= amount;
        }
        
    }
}