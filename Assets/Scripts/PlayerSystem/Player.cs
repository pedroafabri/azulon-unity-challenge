using UnityEngine;
using Components;
using Core;

namespace PlayerSystem
{
    public class Player : MonoBehaviour
    {
        [SerializeField, Header("Demo Config")] private int initialBalance = 100;
        [SerializeField, Header("Player Components")] private WalletComponent wallet;
        [SerializeField] private InventoryComponent inventory;
        
        public WalletComponent Wallet => wallet;
        public InventoryComponent Inventory => inventory;

        #region MonoBehaviour
        
        private void Awake()
        {
            this.ValidateParameters();
        }
        private void Start()
        {
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
        }
        #endregion
    }
}
