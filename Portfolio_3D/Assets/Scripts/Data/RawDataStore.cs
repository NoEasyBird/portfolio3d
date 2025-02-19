using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace Data
{
    public class RawDataStore : Singleton<RawDataStore>
    {
        private readonly string resourcePath = "Data/";
        
        private List<RawOpenContents> openContents = new List<RawOpenContents>();

        private Dictionary<int, List<RawDialog>> dialogDic = new ();
        
        private Dictionary<int, List<RawScenarioData>> scenarioDic = new ();
        
        protected override void Init()
        {
            base.Init();
            LoadData();
        }

        public void LoadData()
        {
            openContents = LoadData<RawOpenContents>("OpenContents");
            
            var dialogList = LoadData<RawDialog>("Dialog");
            dialogList.ForEach(x => AddDictionaryData(dialogDic, x.GroupId, x));
            
            var scenarioList = LoadData<RawScenarioData>("Scenario");
            scenarioList.ForEach(x => AddDictionaryData(scenarioDic, x.GroupId, x));
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
    }
}
