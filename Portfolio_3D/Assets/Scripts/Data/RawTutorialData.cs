using Utility;

namespace Data
{
    public enum TutorialCondition
    {
        Scenario,
    }
    
    public class RawTutorialData
    {
        private int id;

        private TutorialCondition condition;

        private string arg1;

        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Condition
        {
            set => condition = value.ToEnum<TutorialCondition>();
        }

        public TutorialCondition GetCondition() => condition;

        public string Arg1
        {
            get => arg1;
            set => arg1 = value;
        }
    }
}