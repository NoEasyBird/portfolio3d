using UnityEngine;
using Utility;

namespace InGame
{
    public enum BackGroundType
    {
        None,
        Space,
        Ground,
    }
    
    public class BackGround : CallBackMonoBehaviour
    {
        public BackGroundType backGroundType;

        public virtual void Init()
        {
        }
    }
}