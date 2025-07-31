using UnityEngine;
using Components;
using Core;
using Data;

namespace PlayerSystem
{
    public class Player : MonoBehaviour
    {
        [Header("Demo Config")]
        [SerializeField] private int initialBalance = 100;
        [SerializeField] private Item initialItem;
        [SerializeField, Header("Player Components")] private WalletComponent wallet;
        [SerializeField] private InventoryComponent inventory;
        
        public WalletComponent Wallet => wallet;
        public InventoryComponent Inventory => inventory;

        #region MonoBehaviour
        
        private void Awake()
        {
            this.ValidateParameters();
            this.Initialize();
        }
        #endregion
        
        #region Private Methods
        private void ValidateParameters()
        {
            if (wallet == null)
            {
                LogHelper.LogError("Player's wallet is null");
            }

            if (inventory == null)
            {
                LogHelper.LogError("Player's inventory is null");
            }
        }
        private void Initialize()
        {
            SceneContext.Instance.RegisterPlayer(this);
            wallet.Deposit(initialBalance);
            inventory.AddItem(initialItem);
        }
        #endregion
    }
}
