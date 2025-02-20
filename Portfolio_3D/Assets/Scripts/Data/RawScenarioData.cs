using Utility;

namespace Data
{
    public enum ScenarioNextType
    {
        None,
        Next,
    }

    public enum ScenarioEventType
    {
        None,
        Fade,
        Dialog,
        GetItem,
        PlayerAnim,
    }
    
    public class RawScenarioData
    {
        private int groupId;

        private int id;

        private ScenarioNextType nextType;

        private ScenarioEventType eventType;

        private string arg1;

        private string arg2;

        public int GroupId
        {
            get => groupId;
            set => groupId = value;
        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public string NextType
        {
            set => nextType = value.ToEnum<ScenarioNextType>();
        }

        public ScenarioNextType GetNextType() => nextType;

        public string EventType
        {
            set => eventType = value.ToEnum<ScenarioEventType>();
        }

        public ScenarioEventType GetEventType() => eventType;

        public string Arg1
        {
            get => arg1;
            set => arg1 = value;
        }

        public string Arg2
        {
            get => arg2;
            set => arg2 = value;
        }
    }
}