using System;
using Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ItemInfoModal : MonoBehaviour
    {
        [Header("UI Components")]
        [SerializeField] private Button closeButton;
        [SerializeField] private TMP_Text itemNameText;
        [SerializeField] private TMP_Text descriptionText;
        [SerializeField] private TMP_Text quantityText;
        [SerializeField] private Image iconImage;
        [SerializeField] private CanvasGroup canvasGroup;

        private void Awake()
        {
            HideCanvasGroup();
        }

        public void Show(InventoryItem item)
        {
            itemNameText.text = item.Item.itemName;
            descriptionText.text = item.Item.description;
            quantityText.text = $"Quantity: {item.Quantity}";
            iconImage.sprite = item.Item.icon;
            closeButton.onClick.RemoveAllListeners();
            closeButton.onClick.AddListener(HideCanvasGroup);
            ShowCanvasGroup();
        }

        private void ShowCanvasGroup()
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }

        private void HideCanvasGroup()
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }
}