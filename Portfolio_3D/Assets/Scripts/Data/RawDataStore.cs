using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace Data
{
    public class RawDataStore : Singleton<RawDataStore>
    {
        private readonly string resourcePath = "Data/";
        
        private List<RawOpenContents> openContents = new List<RawOpenContents>();

        private List<RawDialog> dialogs = new List<RawDialog>();
        
        protected override void Init()
        {
            base.Init();
            LoadData();
        }

        public void LoadData()
        {
            openContents = LoadData<RawOpenContents>("OpenContents");
            dialogs = LoadData<RawDialog>("Dialog");
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
            return dialogs.FindAll(x => x.GroupId == groupId);
        }
    }
}
