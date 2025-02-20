using System;
using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace Data
{
    public class RawDataStore : Singleton<RawDataStore>
    {
        private readonly string resourcePath = "Data/";

        private bool isLoad;
        
        private List<RawOpenContents> openContents = new List<RawOpenContents>();

        private Dictionary<int, List<RawDialog>> dialogDic = new ();
        
        private Dictionary<int, List<RawScenarioData>> scenarioDic = new ();
        
        private Dictionary<int, RawTutorialData> tutorialData = new ();
        
        protected override void Init()
        {
            base.Init();
            LoadData();
        }

        public void LoadData()
        {
            if (isLoad)
            {
                return;
            }
            openContents = LoadData<RawOpenContents>("OpenContents");
            
            var dialogList = LoadData<RawDialog>("Dialog");
            dialogList.ForEach(x => AddDictionaryData(dialogDic, x.GroupId, x));
            
            var scenarioList = LoadData<RawScenarioData>("Scenario");
            scenarioList.ForEach(x => AddDictionaryData(scenarioDic, x.GroupId, x));
            
            var tutorialList = LoadData<RawTutorialData>("Tutorial");
            tutorialList.ForEach(x => tutorialData.Add(x.Id, x));
            
            isLoad = true;
        }

        private void AddDictionaryData<T, K>(Dictionary<T,List<K>> dictionary, T key, K value)
        {
            if (!dictionary.ContainsKey(key))
            {
                dictionary.Add(key, new List<K>());
            }
            dictionary[key].Add(value);
        }

        private List<T> LoadData<T>(string dataResourceName)
        {
            string path = string.Format("{0}{1}", resourcePath, dataResourceName);
            return CSVManager.LoadTextAsset<T>(path);
        }

        public List<RawOpenContents> GetOpenContents(ContentsType contentsType)
        {
            return openContents.FindAll(x => x.GetContentsType() == contentsType);
        }

        public List<RawDialog> GetDialogs(int groupId)
        {
            return dialogDic[groupId];
        }

        public List<RawScenarioData> GetScenarioData(int groupId)
        {
            return scenarioDic[groupId];
        }

        public RawTutorialData GetTutorialData(int index)
        {
            return tutorialData[index];
        }

        public RawTutorialData CanTutorialData()
        {
            var tutorialSaveData = GameSaveDataStore.Instance.TutorialData;
            foreach (var rawTutorialData in tutorialData.Values)
            {
                if (tutorialSaveData.ContainsKey(rawTutorialData.Id))
                {
                    continue;
                }

                switch (rawTutorialData.GetCondition())
                {
                    case TutorialCondition.Scenario:
                        int scenarioIndex = Convert.ToInt32(rawTutorialData.Arg1);
                        if (!GameSaveDataStore.Instance.ScenarioSaveData.ContainsKey(scenarioIndex))
                        {
                            return rawTutorialData;
                        }
                        break;
                }
            }

            return null;
        }
    }
}
