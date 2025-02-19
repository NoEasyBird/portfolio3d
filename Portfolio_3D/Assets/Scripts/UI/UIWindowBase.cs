using UnityEngine;
using Utility;

namespace UI
{
    public enum WindowNameType
    {
        UIDialogWindow,
        UIFadeWindow,
    }
    
    public class UIWindowBase : MonoBehaviour
    {
        private bool isOpened;

        private WindowNameType windowNameType;

        private RectTransform rectTransform;

        public bool IsOpened => isOpened;

        public WindowNameType WindowNameType => windowNameType;

        public virtual void SetWindow(WindowNameType windowType)
        {
            windowNameType = windowType;
            rectTransform = GetComponent<RectTransform>();
        }
        
        public virtual void OpenWindow()
        {
            isOpened = true;
        }

        public virtual void Refresh()
        {
            
        }

        public virtual void BackWindow()
        {
            isOpened = false;
            UIController.Instance.BackWindow();
        }
    }
}