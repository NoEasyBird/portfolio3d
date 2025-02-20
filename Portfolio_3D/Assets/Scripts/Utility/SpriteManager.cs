using System;
using Scriptable;
using UnityEngine;

namespace Utility
{
    public enum SpriteGroupName
    {
        Icon,
    }
    
    public class SpriteManager : Singleton<SpriteManager>
    {
        private readonly string basePath = "Image/SpriteGroup/";
        
        private SpriteGroup iconSprite;

        protected override void Init()
        {
            base.Init();
            iconSprite = $"{basePath}IconSprite".LoadAsset<SpriteGroup>();
            iconSprite.ApplyDic();
        }

        public Sprite GetSprite(SpriteGroupName groupName, string spriteName)
        {
            switch (groupName)
            {
                case SpriteGroupName.Icon:
                    return iconSprite.GetSprite(spriteName);
            }

            return null;
        }
    }
}