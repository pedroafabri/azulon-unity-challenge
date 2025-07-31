using System;
using Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class BuyFeedback : MonoBehaviour
    {
        [Header("UI Components")]
        [SerializeField] private TMP_Text messageText;
        [SerializeField] private Button closeButton;
        [SerializeField] private CanvasGroup canvasGroup;
        private void Start()
        {
            messageText.text = string.Empty;
            HideCanvasGroup();
            closeButton.onClick.AddListener(HideCanvasGroup);
        }

        public void Show(ShopEntry entry)
        {
            messageText.text = $"You bought \"{entry.item.itemName}\"";
            ShowCanvasGroup();
        }

        private void HideCanvasGroup()
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }

        private void ShowCanvasGroup()
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
    }
}