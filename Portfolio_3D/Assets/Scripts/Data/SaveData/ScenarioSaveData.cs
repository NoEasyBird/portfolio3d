using Utility;

namespace Data.SaveData
{
    public class ScenarioSaveData : ListIntSaveData
    {
        public override void Save()
        {
            base.Save();
            
            GameSaveDataStore.Instance.Save(this);
        }
    }
}