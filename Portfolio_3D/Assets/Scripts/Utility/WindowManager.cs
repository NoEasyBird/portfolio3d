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

        public T GetWindow<T>(WindowNameType windowNameType) where T : UIWindowBase
        {
            if (!loadedWindow.ContainsKey(windowNameType))
            {
                LoadWindow(windowNameType);
            }

            return loadedWindow[windowNameType] as T;
        }

        public void OpenWindow(WindowNameType windowNameType)
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

        public void BackWindow()
        {
            
        }

        private UIWindowBase LoadWindow(WindowNameType windowNameType)
        {
            string path = string.Format(windowPath, windowNameType.ToString());
            var window = path.LoadPrefab<UIWindowBase>(UIController.Instance.transform);
            if (window == null)
            {
                Debug.LogError("Window Is Null : " + windowNameType);
                return null;
            }

            window.SetWindow(windowNameType);
            loadedWindow.Add(windowNameType, window);
            return window;
        }

        public bool IsOpenWindow(WindowNameType windowNameType)
        {
            if (!loadedWindow.ContainsKey(windowNameType))
            {
                return false;
            }

            return loadedWindow[windowNameType].IsOpened;
        }
    }
}