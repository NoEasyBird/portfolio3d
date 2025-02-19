using Data;
using UnityEngine;

namespace Utility
{
    public class GameManager : MonoBehaviour
    {
        private void Awake()
        {
            RawDataStore.Instance.LoadData();
            ClientSaveDataStore.Instance.LoadData();
        }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        private void CheckSpaceBackGround()
        {
            var spaceContents = RawDataStore.Instance.GetOpenContents(ContentsType.SpaceDialog);
            if (spaceContents.TrueForAll(x => ClientSaveDataStore.Instance.IsOpenContents(x.Index)))
            {
                //일반 땅 로드
            }
            else
            {
                //Space 공간 로드
                
            }
        }
    }
}
