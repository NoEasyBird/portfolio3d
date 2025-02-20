using DG.Tweening;
using UnityEngine;

namespace Tween
{
    public class TweenPosition : TweenBase
    {
        public Vector3 startPosition;

        public Vector3 endPosition;
        
        public override void SetTweenSequence()
        {
            if (tweenSequence != null)
            {
                return;
            }
            base.SetTweenSequence();
            transform.localPosition = startPosition;
            tweenSequence.Append(transform.DOLocalMove(endPosition, durationTime));
        }
    }
}