using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class UIManager : MonoBehaviour
    {
        // Sub-managers
        public MenuManager menuManager;
        //public TooltipManager tooltipManager;
       // public StatusBarManager statusBarManager;

        // Singleton instance
        private static UIManager _instance;
        public static UIManager Instance { get { return _instance; } }

        private void Awake()
        {
            // Ensure only one instance of UIManager exists
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }

            // Initialize sub-managers
            //menuManager.Initialize();
            //tooltipManager.Initialize();
            //statusBarManager.Initialize();
        }

        // Call sub-managers to show or hide menus, tooltips, status bars, etc.
        /*
        public void ShowMenu(MenuType menuType)
        {
            menuManager.ShowMenu(menuType);
        }

        public void HideMenu(MenuType menuType)
        {
            menuManager.HideMenu(menuType);
        }

        public void ShowTooltip(string tooltipText, Vector3 position)
        {
            tooltipManager.ShowTooltip(tooltipText, position);
        }

        public void HideTooltip()
        {
            tooltipManager.HideTooltip();
        }

        public void ShowStatusBar(StatusBarType statusBarType, float currentValue, float maxValue)
        {
            statusBarManager.ShowStatusBar(statusBarType, currentValue, maxValue);
        }

        public void HideStatusBar(StatusBarType statusBarType)
        {
            statusBarManager.HideStatusBar(statusBarType);
        }
        */
    }
}