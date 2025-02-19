using System;
using System.Collections.Generic;
using Data;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace UI
{
    public class UIDialogWindow : UIWindowBase
    {
        public TypeEffectText dialogText;

        public Button nextButton;

        public GameObject arrowImg;

        private RawDialog currentDialog;

        private Queue<RawDialog> dialogQueue = new Queue<RawDialog>();

        private bool isDialog;

        public override void SetWindow(WindowNameType windowType)
        {
            base.SetWindow(windowType);
            dialogText.onFinished = OnFinishedDialog;
            nextButton.onClick.AddListener(OnClick_SkipButton);
        }

        public override void BackWindow()
        {
            currentDialog = null;
            dialogQueue.Clear();
            base.BackWindow();
        }

        private void OnDisable()
        {
        }

        public void PlayDialog(int groupId)
        {
            var dialogs = RawDataStore.Instance.GetDialogs(groupId);
            dialogs.Sort((a,b) => a.Index.CompareTo(b.Index));
            foreach (var dialog in dialogs)
            {
                dialogQueue.Enqueue(dialog);
            }
            PlayDialogInternal();
        }

        private void PlayDialogInternal()
        {
            if (dialogQueue.Count <= 0)
            {
                FinishDialog();
                return;
            }
            currentDialog = dialogQueue.Dequeue();
            if (currentDialog == null)
            {
                PlayDialogInternal();
                return;
            }

            arrowImg.SetActiveSafely(false);
            dialogText.text = currentDialog.Content;
            isDialog = true;
        }

        private void OnFinishedDialog()
        {
            isDialog = false;
            arrowImg.SetActiveSafely(true);
        }

        private void FinishDialog()
        {
            BackWindow();
        }

        private void OnClick_SkipButton()
        {
            if (isDialog)
            {
                dialogText.SetForceText(currentDialog?.Content ?? "");
            }
            else
            {
                PlayDialogInternal();
            }
        }
    }
}