using System.Collections.Generic;
using UnityEngine;

namespace Scriptable
{
    [CreateAssetMenu(fileName = "Sprite Group", menuName = "Scriptable Object/Sprite Group", order = int.MaxValue)]
    public class SpriteGroup : ScriptableObject
    {
        public List<Sprite> sprites = new List<Sprite>();

        private Dictionary<string, Sprite> spriteDic = new Dictionary<string, Sprite>();

        public void ApplyDic()
        {
            sprites.ForEach(x =>
            {
                spriteDic.Add(x.name, x);
            });
        }

        public Sprite GetSprite(string spriteName)
        {
            if (!spriteDic.ContainsKey(spriteName))
            {
                return null;
            }

            return spriteDic[spriteName];
        }
    }
}