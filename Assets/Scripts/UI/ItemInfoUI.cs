using Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ItemInfoUI : MonoBehaviour
    {
        [Header("Configuration")] [SerializeField]
        private int balanceIconID = 0;
        
        [Header("UI Components")]
        [SerializeField] private TMP_Text itemNameText;
        [SerializeField] private TMP_Text itemPriceText;
        [SerializeField] private TMP_Text itemDescriptionText;
        [SerializeField] private Image itemIcon;

        public void Clear()
        {
            itemNameText.text = "";
            itemPriceText.text = "";
            itemDescriptionText.text = "";
            itemIcon.sprite = null;
        }
        
        public void SetEntry(ShopEntry entry)
        {
            itemNameText.text = entry.item.itemName;
            itemPriceText.text = $"<sprite={balanceIconID}> {entry.price.ToString()}";
            itemDescriptionText.text = entry.item.description;
            itemIcon.sprite = entry.item.icon;
        }
    }
}