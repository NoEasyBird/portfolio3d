using System;
using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace Data.SaveData
{
    [Serializable]
    public class ScenarioSaveData : SaveDataBase
    {
        [SerializeField]
        private List<int> playedScenarioRaw = new List<int>();

        private HashSet<int> playedScenario = new HashSet<int>();

        public override void ApplyData()
        {
            base.ApplyData();
            if (playedScenarioRaw == null)
            {
                playedScenarioRaw = new List<int>();
                return;
            }
            playedScenario = new HashSet<int>(playedScenarioRaw);
        }

        public bool IsScenarioPlayed(int groupId)
        {
            return playedScenario.Contains(groupId);
        }

        public void AddPlayedScenario(int groupId)
        {
            if (playedScenario.Contains(groupId))
            {
                return;
            }

            playedScenario.Add(groupId);
            playedScenarioRaw.Add(groupId);
            Save();
        }

        public override void Save()
        {
            base.Save();
            
            GameSaveDataStore.Instance.Save(this);
        }
    }
}