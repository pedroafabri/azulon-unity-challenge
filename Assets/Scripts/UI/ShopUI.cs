using Core;
using Models;
using PlayerSystem;
using ShopSystem;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ShopUI : MonoBehaviour
    {
        [Header("Configuration")]
        [SerializeField] private ShopManager shopManager;
        [SerializeField] private GameObject listItemPrefab;
        
        [Header("UI Components")]
        [SerializeField] private Button buyButton;
        [SerializeField] private GameObject shopListContent;
        [SerializeField] private ItemInfoUI itemInfo;
        [SerializeField] private BuyFeedback buyFeedback;
        
        private ShopListItem _currentItem;
        private Player _player;
        
        #region MonoBehaviour

        private void Start()
        {
            Initialize();
            DrawItemsForSale();
            SelectFirstItem();
        }

        #endregion
        
        #region Public Methods

        public void OnShopListItemClicked(ShopListItem item)
        {
            if(_currentItem == item) return;
            SelectListItem(item);
        }
        #endregion
        
        #region Private Methods

        private void Initialize()
        {
            _player = SceneContext.Instance.Player;
            itemInfo.Clear();
            buyButton.onClick.RemoveAllListeners();
            buyButton.onClick.AddListener(ProcessItemBuy);
        }
        
        private void DrawItemsForSale()
        {
            foreach(var entry in shopManager.Items)
            {
                DrawListItem(entry);
            }
        }

        private void SelectFirstItem()
        {
            var item = shopListContent
                .transform
                .GetChild(0)?
                .GetComponent<ShopListItem>();
            if (!item) return;
            SelectListItem(item);
        }

        private void DrawListItem(ShopEntry entry)
        {
            var instance = Instantiate(listItemPrefab, shopListContent.transform);
            instance.GetComponent<ShopListItem>()?.Setup(this, entry);
        }

        private void SelectListItem(ShopListItem item)
        {
            _currentItem?.SetSelected(false);
            _currentItem = item;
            _currentItem.SetSelected(true);
            DrawItemInfo(item.ShopEntry);
        }

        private void DrawItemInfo(ShopEntry entry)
        {
            buyButton.interactable = _player.Wallet.CanAfford(entry.price);
            itemInfo.SetEntry(entry);
        }

        private void ProcessItemBuy()
        {
            shopManager.BuyItem(_currentItem.ShopEntry);
            buyFeedback.Show(_currentItem.ShopEntry);
            DrawItemInfo(_currentItem.ShopEntry);
        }
        #endregion
    }
}