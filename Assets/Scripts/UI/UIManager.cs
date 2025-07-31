using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using Utils;
using CanvasGroup = UnityEngine.CanvasGroup;

namespace UI
{
    public enum UIType
    {
        Shop,
        Inventory
    }

    [Serializable]
    public class UIEntry
    {
        public UIType type;
        public CanvasGroup canvasGroup;
    }
    
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] private List<UIEntry> uiEntries = new List<UIEntry>();
        [SerializeField] private UIType defaultActiveUI = UIType.Inventory;
        
        private Dictionary<UIType, CanvasGroup> _uiMap = new Dictionary<UIType, CanvasGroup>(); 
        private UIType _currentUIEntry;
        
        public UIType CurrentUI => _currentUIEntry;

        public UnityEvent<UIType> onUIChanged = new UnityEvent<UIType>();
        
        #region MonoBehaviour
        protected override void Awake()
        {
            base.Awake();
            _uiMap = uiEntries.ToDictionary(entry => entry.type, entry => entry.canvasGroup);
            InitializeUIs();
        }
        #endregion

        #region Public Methods
        public void ChangeActiveUI(UIType uiType)
        {
            HideCanvasGroup(_uiMap[_currentUIEntry]);
            _currentUIEntry = uiType;
            ShowCanvasGroup(_uiMap[_currentUIEntry]);
            onUIChanged.Invoke(_currentUIEntry);
        }
        
        #endregion

        #region Private Methods
        private void InitializeUIs()
        {
            _currentUIEntry = defaultActiveUI;
            foreach (var uiEntry in uiEntries)
            {
                if (uiEntry.type == defaultActiveUI)
                {
                    ShowCanvasGroup(uiEntry.canvasGroup);
                }
                else
                {
                    HideCanvasGroup(uiEntry.canvasGroup);
                }
            }
        }

        private void ShowCanvasGroup(CanvasGroup canvasGroup)
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }

        private void HideCanvasGroup(CanvasGroup canvasGroup)
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
        #endregion
    }
}