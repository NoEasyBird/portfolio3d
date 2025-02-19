using UnityEngine;

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

        public void RunAnim()
        {
            if (animator == null)
            {
                return;
            }
            animator.SetTrigger(AnimationTrigger.Running.ToString());
        }

        public void SpinningAnim()
        {
            if (animator == null)
            {
                return;
            }
            animator.SetTrigger(AnimationTrigger.Spinning.ToString());
        }
    }
}