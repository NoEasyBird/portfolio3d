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

        public static T LoadPrefab<T>(this string path, Transform parent = null) where T : Component
        {
            var obj = Resources.Load<Object>(path);
            if (obj == null)
            {
                return null;
            }

            var gameObj = Object.Instantiate(obj, parent) as GameObject;
            if (gameObj == null)
            {
                return null;
            }

            return gameObj.GetComponent<T>();
        }

        public static string GetPath(this Type type)
        {
            if (type == typeof(UIController))
            {
                return string.Format("{0}{1}/{2}", prefabPath, "UI", "UIController");
            }

            if (type == typeof(GameManager))
            {
                return string.Format("{0}{1}", prefabPath, "GameManager");
            }

            return "";
        }
    }
}