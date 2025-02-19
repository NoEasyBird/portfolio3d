using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Utility
{
    public static class ResourceManager
    {
        private static readonly string prefabPath = "Object/";
        
        public static T LoadAsset<T>(this string path) where T : Object
        {
            return Resources.Load<T>(path);
        }

        public static T LoadPrefab<T>(this string path) where T : Component
        {
            var obj = Resources.Load<Object>(path) as GameObject;
            if (obj == null)
            {
                return null;
            }

            return obj.GetComponent<T>();
        }

        public static string GetPath(this Type type)
        {
            if (type == typeof(UIController))
            {
                return string.Format("{0}{1}/{2}", prefabPath, "UI", "UIController");
            }

            return "";
        }
    }
}