using Data;
using Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InventoryListItem : MonoBehaviour
    {
        [Header("UI Components")]
        [SerializeField] private Button button;
        [SerializeField] private Image icon;
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private TMP_Text quantityText;
        
        public void Setup(InventoryUI owner, InventoryItem item)
        {
            nameText.text = item.Item.itemName;
            icon.sprite = item.Item.icon;
            quantityText.text = item.Quantity > 1 ? $"x{item.Quantity}" : "";
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => owner.ShowItemInfo(item));
        }
    }
}