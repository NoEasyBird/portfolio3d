using System;
using UnityEngine;
using Utility;

namespace InGame
{
    public class Player : CallBackMonoBehaviour
    {
        private PlayerAnimController playerAnim = new PlayerAnimController();

        private bool isInit;

        protected override void Awake()
        {
            base.Awake();
            Init();
        }

        public virtual void Init()
        {
            if (isInit)
            {
                return;
            }

            Caching();
            isInit = true;
        }

        private void Caching()
        {
            playerAnim.SetAnimator(GetComponent<Animator>());
        }

        public void SetAnimation(AnimationTrigger trigger)
        {
            playerAnim.SetAnimation(trigger);
        }
    }
}
