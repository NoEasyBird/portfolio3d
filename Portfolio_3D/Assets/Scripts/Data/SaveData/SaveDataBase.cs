using System;
using Utility;

namespace Data.SaveData
{
    [Serializable]
    public class SaveDataBase
    {
        public virtual void ApplyData()
        {
        }

        public virtual void Save()
        {
        }
    }
}