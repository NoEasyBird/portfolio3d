namespace Data
{
    public class RawDialog
    {
        private int groupId;

        private int index;

        private string content;

        public int GroupId
        {
            get => groupId;
            set => groupId = value;
        }

        public int Index
        {
            get => index;
            set => index = value;
        }

        public string Content
        {
            get => content;
            set => content = value;
        }
    }
}