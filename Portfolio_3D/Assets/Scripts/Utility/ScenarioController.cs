using System;
using System.Collections.Generic;
using Data;
using InGame;

namespace Utility
{
    public class ScenarioController : Singleton<ScenarioController>
    {
        private RawScenarioData currentScenario;

        private Queue<RawScenarioData> scenarioQueue = new();
        
        public void PlayScenario(int groupId)
        {
            var scenarioData = RawDataStore.Instance.GetScenarioData(groupId);
            scenarioData.ForEach(x => scenarioQueue.Enqueue(x));
            PlayInternal();
        }

        private void PlayInternal()
        {
            if (scenarioQueue.Count <= 0)
            {
                return;
            }

            currentScenario = scenarioQueue.Dequeue();
            if (currentScenario == null)
            {
                PlayInternal();
                return;
            }

            bool isNext = currentScenario.GetNextType() == ScenarioNextType.Next;

            switch (currentScenario.GetEventType())
            {
                case ScenarioEventType.Fade:
                    bool isFadeIn = Convert.ToBoolean(currentScenario.Arg1);
                    float fadeTime = Convert.ToSingle(currentScenario.Arg2);
                    UIController.Instance.StartFade(isFadeIn, fadeTime, isNext ? null : PlayInternal);
                    break;
                case ScenarioEventType.Dialog:
                    int dialogGroupId = Convert.ToInt32(currentScenario.Arg1);
                    UIController.Instance.PlayDialog(dialogGroupId, isNext ? null : PlayInternal);
                    break;
                case ScenarioEventType.GetItem:
                    break;
                case ScenarioEventType.PlayerAnim:
                    AnimationTrigger animationTrigger = currentScenario.Arg1.ToEnum<AnimationTrigger>();
                    PlayerController.Instance.MainPlayer.SetAnimation(animationTrigger);
                    break;
                default:
                    PlayInternal();
                    return;
            }

            if (isNext)
            {
                PlayInternal();
            }
        }
    }
}