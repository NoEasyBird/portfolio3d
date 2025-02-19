using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Utility
{
    public enum PrefsName
    {
        OpenContents,
        PlayerPos,
    }
    
    public class ClientSaveDataStore : Singleton<ClientSaveDataStore>
    {
        private bool isLoad = false;
        
        private HashSet<int> openIndex = new HashSet<int>();

        public bool IsOpenContents(int index)
        {
            return openIndex.Contains(index);
        }

        public void SetOpenContents(int index)
        {
            if (!openIndex.Contains(index))
            {
                openIndex.Add(index);
            }
            
            PlayerPrefs.SetString(PrefsName.OpenContents.ToString(), openIndex.ToList().ListToString());
            PlayerPrefs.Save();
        }

        protected override void Init()
        {
            base.Init();
            if (isLoad)
            {
                return;
            }
            LoadData();
        }

        public void LoadData()
        {
            isLoad = true;
            
            var openIndexStrLists = PlayerPrefs.GetString(PrefsName.OpenContents.ToString(), "").StringToList();
            openIndex = new HashSet<int>(openIndexStrLists.ConvertAll(Convert.ToInt32));
        }
    }
}
