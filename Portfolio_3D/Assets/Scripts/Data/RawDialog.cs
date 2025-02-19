namespace Data
{
    public class RawDialog
    {
        private int id;

        private int index;

        private string content;

        public int Id
        {
            get => id;
            set => id = value;
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