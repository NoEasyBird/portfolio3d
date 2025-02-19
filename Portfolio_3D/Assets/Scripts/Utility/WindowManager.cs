using System.Collections.Generic;
using UI;
using UnityEngine;

namespace Utility
{
    public class WindowManager
    {
        private readonly string windowPath = "Object/UI/{0}";
        
        private Stack<UIWindowBase> openedWindow = new Stack<UIWindowBase>();

        private Dictionary<WindowNameType, UIWindowBase> loadedWindow = new ();

        private void OpenWindow<T>(WindowNameType windowNameType) where T : UIWindowBase
        {
            UIWindowBase windowBase = null;
            if (!loadedWindow.ContainsKey(windowNameType))
            {
                windowBase = LoadWindow(windowNameType);
                loadedWindow.Add(windowNameType, windowBase);
            }
            else
            {
                windowBase = loadedWindow[windowNameType];
            }

            if (windowBase == null)
            {
                Debug.LogError(string.Format("Not Exist Window! - {0}", windowNameType));
                return;
            }

            if (windowBase.IsOpened)
            {
                return;
            }
            
            openedWindow.Push(windowBase);
            windowBase.OpenWindow();
        }

        private void BackWindow()
        {
            
        }

        private UIWindowBase LoadWindow(WindowNameType windowNameType)
        {
            string path = string.Format(windowPath, windowNameType.ToString());
            return path.LoadPrefab<UIWindowBase>();
        }
    }
}