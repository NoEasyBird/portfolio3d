using System.Collections.Generic;
using Data;
using InGame;
using UnityEngine;

namespace Utility
{
    public class GameManager : MonoBehaviour
    {
        private Dictionary<BackGroundType, BackGround> backGrounds = new ();
        
        protected void Awake()
        {
            UIController.Instance.StartFade(true, 0f);
        }

        protected void Start()
        {
            LoadBackGround();
            LoadPlayer();
            
            UIController.Instance.CheckAndPlayTutorial();
        }

        private void LoadPlayer()
        {
            var player = "Object/Player/Player".LoadPrefab<Player>();
            if (player != null)
            {
                player.transform.position = Vector3.zero;
                player.Init();
                PlayerController.Instance.SetMainPlayer(player);
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
