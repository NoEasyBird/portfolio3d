using System;
using DG.Tweening;
using UnityEngine;

namespace Tween
{
    public enum TweenLoopType
    {
        None,
        Loop,
        Rewind,
    }
    
    public class TweenBase : MonoBehaviour
    {
        public AnimationCurve curve = AnimationCurve.Linear(0f , 0f , 1f, 1f);

        public float durationTime = 1f;

        public bool onEnableStart = false;

        public TweenLoopType loopType = TweenLoopType.None;

        protected Sequence tweenSequence = null;

        public bool IsPlaying => tweenSequence?.IsPlaying() ?? false;

        private void Awake()
        {
            SetTweenSequence();
            
            tweenSequence.SetEase(curve);
            switch (loopType)
            {
                case TweenLoopType.Loop:
                    tweenSequence.SetLoops(-1, LoopType.Restart);
                    break;
                case TweenLoopType.Rewind:
                    tweenSequence.SetLoops(-1, LoopType.Yoyo);
                    break;
            }

            tweenSequence.Pause();
        }

        private void OnEnable()
        {
            if (onEnableStart)
            {
                Play();
            }
        }

        public virtual void SetTweenSequence()
        {
            if (tweenSequence != null)
            {
                return;
            }
            tweenSequence = DOTween.Sequence();
        }

        public void Play(bool isForward)
        {
            if (isForward)
            {
                tweenSequence.PlayForward();
            }
            else
            {
                tweenSequence.PlayBackwards();
            }
        }

        public virtual void Pause()
        {
            tweenSequence.Pause();
        }

        public virtual void Restart()
        {
            tweenSequence.Restart();
        }

        public virtual void Play()
        {
            tweenSequence.Play();
        }

        protected virtual void OnFinished()
        {
            
        }

        public void AddOnFinished(TweenCallback onFinished)
        {
            tweenSequence.onComplete += onFinished;
        }

        public void ResetOnFinished()
        {
            tweenSequence.onComplete = OnFinished;
        }

        public void AddOnPaused(TweenCallback onPaused)
        {
            tweenSequence.onPause += onPaused;
        }

        public void ResetOnPaused()
        {
            tweenSequence.onPause = null;
        }

        public void AddOnRewind(TweenCallback onRewind)
        {
            tweenSequence.onRewind = onRewind;
        }

        public void ResetOnRewind()
        {
            tweenSequence.onRewind = null;
        }
    }
}