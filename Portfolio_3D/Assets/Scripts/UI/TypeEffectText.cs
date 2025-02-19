using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class TypeEffectText : Text
    {
        [SerializeField]
        public float typeTerm = 0.1f;

        public override string text
        {
            get => base.text;
            set
            {
                tempText = value;
                base.text = "";
                StartTypeWriter();
            }
        }

        private string tempText = "";

        private Coroutine textCrt;

        private void StartTypeWriter()
        {
            if (textCrt != null)
            {
                StopCoroutine(textCrt);
            }

            textCrt = StartCoroutine(EffectCoroutine());
        }

        IEnumerator EffectCoroutine()
        {
            for (var i = 0; i < tempText.Length; i++)
            {
                base.text = tempText.Substring(0, i + 1);
                yield return new WaitForSecondsRealtime(typeTerm);
            }

            textCrt = null;
        }
    }
}