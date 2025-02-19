using System;
using System.Collections.Generic;
using Data;

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
                    bool isFade = Convert.ToBoolean(currentScenario.Arg1);
                    float fadeTime = Convert.ToSingle(currentScenario.Arg2);
                    UIController.Instance.StartFade(isFade, fadeTime, isNext ? null : PlayInternal);
                    break;
                case ScenarioEventType.Dialog:
                    int dialogGroupId = Convert.ToInt32(currentScenario.Arg1);
                    UIController.Instance.PlayDialog(dialogGroupId, isNext ? null : PlayInternal);
                    break;
                case ScenarioEventType.GetItem:
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