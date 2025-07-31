using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIHeader : MonoBehaviour
    {
        [Header("UI Components")]
        [SerializeField] private Button inventoryButton;
        [SerializeField] private Button shopButton;
        
        private UIManager _uIManager;
        private void Start()
        {
            _uIManager = UIManager.Instance;

            _uIManager.onUIChanged.AddListener(UpdateButtonsState);
            
            inventoryButton.onClick.RemoveAllListeners();
            inventoryButton.onClick.AddListener(() => OnNavButtonClicked(UIType.Inventory));
            
            shopButton.onClick.RemoveAllListeners();
            shopButton.onClick.AddListener(() => OnNavButtonClicked(UIType.Shop));

            UpdateButtonsState(_uIManager.CurrentUI);
        }

        private void OnNavButtonClicked(UIType type)
        {
            _uIManager.ChangeActiveUI(type);
        }

        private void UpdateButtonsState(UIType type)
        {
            inventoryButton.interactable = type != UIType.Inventory;
            shopButton.interactable = type != UIType.Shop;
        }
        
    }
}