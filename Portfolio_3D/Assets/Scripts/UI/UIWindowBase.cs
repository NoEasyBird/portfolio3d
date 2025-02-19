using UnityEngine;
using Utility;

namespace UI
{
    public enum WindowNameType
    {
        UIDialogWindow,
    }
    
    public class UIWindowBase : MonoBehaviour
    {
        private bool isOpened;

        private WindowNameType windowNameType;

        public bool IsOpened => isOpened;

        public WindowNameType WindowNameType => windowNameType;

        public virtual void SetWindow(WindowNameType windowType)
        {
            windowNameType = windowType;
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
        }
    }
}