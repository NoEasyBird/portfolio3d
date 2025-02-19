using System.Collections.Generic;
using Data;
using InGame;
using UnityEngine;

namespace Utility
{
    public class GameManager : MonoBehaviour
    {
        private Dictionary<BackGroundType, BackGround> backGrounds = new ();
        
        private void Awake()
        {
            RawDataStore.Instance.LoadData();
            ClientSaveDataStore.Instance.LoadData();
            UIController.Instance.StartFade(true, 0f);
        }

        private void Start()
        {
            LoadBackGround();
            LoadPlayer();
            UIController.Instance.StartFade(false, 2f);
        }

        private void LoadPlayer()
        {
            var player = "Object/Player/Player".LoadPrefab<Player>();
            if (player != null)
            {
                player.transform.position = Vector3.zero;
                player.Init();
                player.SetAnimation(AnimationTrigger.Air);
            }
        }

        private void LoadBackGround()
        {
            foreach (var backGroundType in backGrounds.Keys)
            {
                backGrounds[backGroundType].Hide();
            }
            
            var spaceContents = RawDataStore.Instance.GetOpenContents(ContentsType.SpaceDialog);
            if (spaceContents.TrueForAll(x => ClientSaveDataStore.Instance.IsOpenContents(x.Index)))
            {
                //일반 땅 로드
            }
            else
            {
                //Space 공간 
                if (!backGrounds.ContainsKey(BackGroundType.Space))
                {
                    var spaceBackGround = "Object/BackGround/Space".LoadPrefab<BackGround>();
                    backGrounds.Add(BackGroundType.Space, spaceBackGround);
                }
                backGrounds[BackGroundType.Space].Init();
            }
        }
    }
}
