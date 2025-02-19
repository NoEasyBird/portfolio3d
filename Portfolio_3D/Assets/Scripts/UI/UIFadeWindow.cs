using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIFadeWindow : UIWindowBase
    {
        public Image black;

        private Coroutine fadeCrt;

        public override void OpenWindow()
        {
            base.OpenWindow();
            StopAllCoroutines();
            transform.SetAsLastSibling();
        }

        public override void BackWindow()
        {
            base.BackWindow();
            StopAllCoroutines();
        }

        public void FadeIn(float time = 1f, Action onFinished = null)
        {
            if (fadeCrt != null)
            {
                StopCoroutine(fadeCrt);
            }
            fadeCrt = StartCoroutine(FadeCoroutine(true, time, onFinished));
        }

        public void FadeOut(float time = 1f, Action onFinished = null)
        {
            if (fadeCrt != null)
            {
                StopCoroutine(fadeCrt);
            }
            fadeCrt = StartCoroutine(FadeCoroutine(false, time, onFinished));
        }

        private IEnumerator FadeCoroutine(bool fadeIn, float targetTime = 1f, Action onFinished = null)
        {
            float startAlpha = black.color.a;
            float targetAlpha = fadeIn ? 1f : 0f;
            float time = 0f;
            while (time < targetTime && targetTime > 0f)
            {
                time += Time.unscaledDeltaTime;
                var ratio = Mathf.Clamp(time / targetTime , 0f, 1f);
                var currentAlpha = Mathf.Lerp(startAlpha, targetAlpha, ratio);
                var c = black.color;
                c.a = currentAlpha;
                black.color = c;
                yield return null;
            }

            var color = black.color;
            color.a = fadeIn ? 1f : 0f;
            black.color = color;

            if (fadeIn == false)
            {
                BackWindow();
            }
            onFinished?.Invoke();
            fadeCrt = null;
        }
    }
}