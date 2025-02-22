using System;
using Data;
using UI;

namespace Utility
{
    public class UIController : MonoSingleton<UIController>
    {
        private WindowManager windowManager = new WindowManager();

        public void StartFade(bool fadeIn, float fadeTime = 1f, Action onFinished = null)
        {
            windowManager.OpenWindow(WindowNameType.UIFadeWindow);
            var window = windowManager.GetWindow<UIFadeWindow>(WindowNameType.UIFadeWindow);
            if (window != null)
            {
                if (fadeIn)
                {
                    window.FadeIn(fadeTime, onFinished);
                }
                else
                {
                    window.FadeOut(fadeTime, onFinished);
                }
            }
        }

        public void BackWindow()
        {
            windowManager.BackWindow();
        }

        public void PlayDialog(int groupIndex, Action onFinished = null)
        {
            windowManager.OpenWindow(WindowNameType.UIDialogWindow);
            
            var window = windowManager.GetWindow<UIDialogWindow>(WindowNameType.UIDialogWindow);
            if (window != null)
            {
                window.PlayDialog(groupIndex, onFinished);
            }
        }

        public void CheckAndPlayTutorial()
        {
            var nextTutorial = RawDataStore.Instance.CanTutorialData();
            if (nextTutorial == null)
            {
                return;
            }

            switch (nextTutorial.GetCondition())
            {
                case TutorialCondition.Scenario:
                    int scenarioIndex = Convert.ToInt32(nextTutorial.Arg1);
                    ScenarioController.Instance.PlayScenario(scenarioIndex);
                    break;
                default:
                    return;
            }
            
            //GameSaveDataStore.Instance.ScenarioSaveData.AddIdSave(nextTutorial.Id);
        }
    }
}