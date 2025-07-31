using Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace UI
{
    public class ShopListItem : MonoBehaviour
    {
        public ShopEntry ShopEntry { get; private set; }
        
        [SerializeField, Header("Configuration")] private int iconIndex = 0;
        [SerializeField] private Sprite unselectedSprite;
        [SerializeField] private Sprite selectedSprite;
        
        [Header("Configuration")]
        [SerializeField] private Button button;
        [SerializeField] private Image backgroundImage;
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private TMP_Text priceText;

        public void Setup(ShopUI owner, ShopEntry shopEntry, bool selected = false)
        {
            ShopEntry = shopEntry;
            nameText.text = shopEntry.item.itemName;
            priceText.text = $"<sprite={iconIndex}>{shopEntry.price.ToString()}";
            backgroundImage.sprite = selected ? selectedSprite : unselectedSprite;
            button.onClick.AddListener(() => owner.OnShopListItemClicked(this));
        }

        public void SetSelected(bool selected)
        {
            backgroundImage.sprite = selected ? selectedSprite : unselectedSprite;
        }
    }
}