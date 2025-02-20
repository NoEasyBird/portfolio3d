using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Utility;

namespace Data.SaveData
{
    [Serializable]
    public class ListIntSaveData : SaveDataBase
    {
        [SerializeField]
        private List<int> listInt = new List<int>();

        private HashSet<int> hashInt = new HashSet<int>();

        public override void ApplyData()
        {
            base.ApplyData();
            if (listInt == null)
            {
                listInt = new List<int>();
                return;
            }
            hashInt = new HashSet<int>(listInt);
        }

        public bool ContainsKey(int groupId)
        {
            return hashInt.Contains(groupId);
        }

        public void AddIdSave(int index)
        {
            if (hashInt.Contains(index))
            {
                return;
            }

            hashInt.Add(index);
            listInt.Add(index);
            Save();
        }
    }
}