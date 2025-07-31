using System;
using Core;
using TMPro;
using UnityEngine;

namespace UI
{
    public class WalletBalanceDisplay : MonoBehaviour
    {
        [Header("Configuration")] 
        [SerializeField] private int iconIndex = 0;
        
        [Header("UI Elements")] 
        [SerializeField] private TMP_Text balanceText;

        private void Start()
        {
            var wallet = SceneContext.Instance.Player.Wallet;
            DrawBalance(wallet.Balance);
            wallet.onBalanceChanged.AddListener(OnBalanceChanged);
        }

        private void OnBalanceChanged(int balance)
        {
            DrawBalance(balance);
        }

        private void DrawBalance(int balance)
        {
            balanceText.text = $"<sprite={iconIndex}> {balance.ToString()}";
        }
    }
}