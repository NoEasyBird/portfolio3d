using UnityEditor;
using UnityEngine;

namespace Tween.Editor
{
    [CustomEditor(typeof(TweenBase), true)]
    public class TweenBaseEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            var tweenBase = target as TweenBase;
            if (tweenBase == null)
            {
                return;
            }

            if (!tweenBase.IsPlaying)
            {
                if (GUILayout.Button("Play Forward"))
                {
                    PlayForward();
                }

                if (GUILayout.Button("Play Backward"))
                {
                    PlayBackward();
                }
            }
            else
            {
                if (GUILayout.Button("Pause"))
                {
                    Pause();
                }
            }
        }

        private void PlayForward()
        {
            var tweenBase = target as TweenBase;
            if (tweenBase != null)
            {
                tweenBase.SetTweenSequence();
                tweenBase.Play(true);
            }
        }

        private void PlayBackward()
        {
            var tweenBase = target as TweenBase;
            if (tweenBase != null)
            {
                tweenBase.SetTweenSequence();
                tweenBase.Play(false);
            }
        }

        private void Pause()
        {
            var tweenBase = target as TweenBase;
            if (tweenBase != null)
            {
                tweenBase.SetTweenSequence();
                tweenBase.Pause();
            }
        }
    }
}