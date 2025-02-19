using Utility;

namespace Data
{
    public enum ContentsType
    {
        SpaceDialog,
    }                                          
    
    public class RawOpenContents
    {
        private int index;

        private ContentsType contentsType;

        private int arg1;

        public int Index
        {
            get => index;
            set => index = value;
        }

        public string ContentsType
        {
            set => contentsType = value.ToEnum<ContentsType>();
        }

        public ContentsType GetContentsType() => contentsType;

        public int Arg1
        {
            get => arg1;
            set => arg1 = value;
        }
    }
}