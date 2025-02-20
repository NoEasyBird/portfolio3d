using Utility;

namespace Data.SaveData
{
    public class TutorialSaveData : ListIntSaveData
    {
        public override void Save()
        {
            base.Save();
            
            GameSaveDataStore.Instance.Save(this);
        }
    }
}