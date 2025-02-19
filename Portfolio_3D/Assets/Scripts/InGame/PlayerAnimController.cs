using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace InGame
{
    public enum AnimationTrigger
    {
        Idle = 0,
        Attack_01 = 1,
        Attack_02 = 2,
        Attack_03 = 3,
        Spinning = 11,
        Running = 12,
        Air = 13,
    }
    
    public class PlayerAnimController
    {
        private Animator animator;

        public void SetAnimator(Animator animator)
        {
            this.animator = animator;
        }
        
        public void AttackAnim()
        {
            if (animator == null)
            {
                return;
            }
            int randomAnim = Random.Range((int)AnimationTrigger.Attack_01, (int)AnimationTrigger.Attack_03 + 1);
            animator.SetTrigger(((AnimationTrigger) randomAnim).ToString());
        }

        public void SetAnimation(AnimationTrigger trigger)
        {
            switch (trigger)
            {
                case AnimationTrigger.Attack_01:
                case AnimationTrigger.Attack_02:
                case AnimationTrigger.Attack_03:
                    AttackAnim();
                    break;
                default:
                    animator.SetTrigger(trigger.ToString());
                    break;
            }
        }
    }
}