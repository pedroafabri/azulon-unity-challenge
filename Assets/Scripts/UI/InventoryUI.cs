using System;
using Core;
using Data;
using Models;
using UnityEngine;

namespace UI
{
    public class InventoryUI : MonoBehaviour
    {
        [Header("Configuration")] 
        [SerializeField] private GameObject inventoryItemPrefab;

        [Header("UI Components")] 
        [SerializeField] private Transform inventoryContent;
        [SerializeField] private ItemInfoModal itemInfoModal;

        #region MonoBehaviour

        private void Start()
        {
            DrawInventory();
            UIManager.Instance.onUIChanged.AddListener(OnGuiChange);
        }
        

        #endregion

        #region Public Methods

        public void ShowItemInfo(InventoryItem item)
        {
            itemInfoModal.Show(item);
        }

        #endregion


        #region Private Methods

        private void DrawInventory()
        {
            foreach (var item in SceneContext.Instance.Player.Inventory.Items)
            {
                DrawInventoryItem(item);
            }
        }

        private void OnGuiChange(UIType uiType)
        {
            if (uiType == UIType.Inventory)
            {
                DrawInventory();
            }
            else
            {
                ResetInventory();
            }
        }
        
        private void DrawInventoryItem(InventoryItem item)
        {
            var instance = Instantiate(inventoryItemPrefab, inventoryContent);
            instance.GetComponent<InventoryListItem>()?.Setup(this, item);
        }

        private void ResetInventory()
        {
            for (int i = 0; i < inventoryContent.childCount; i++)
            {
                Destroy(inventoryContent.GetChild(i).gameObject);
            }
        }

        #endregion
    }
}