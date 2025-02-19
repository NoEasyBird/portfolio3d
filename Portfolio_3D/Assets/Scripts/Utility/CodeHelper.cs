using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Utility
{
    public static class CodeHelper
    {
        public static string ListToString<T>(this List<T> list, char token = '@')
        {
            return String.Join(token, list);
        }

        public static List<string> StringToList(this string str, char token = '@')
        {
            if (string.IsNullOrEmpty(str))
            {
                return new List<string>();
            }
            return str.Split(token).ToList();
        }

        public static T ToEnum<T>(this string str) where T : struct
        {
            return Enum.Parse<T>(str);
        }

        public static void SetActiveSafely(this GameObject gameObject, bool isActive)
        {
            if (gameObject.activeSelf != isActive)
            {
                gameObject.SetActive(isActive);
            }
        }
    }
}