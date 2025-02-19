using System;
using System.IO;
using Data.SaveData;
using UnityEngine;

namespace Utility
{
    public enum SaveDataName
    {
        Scenario,
    }
    
    public class GameSaveDataStore : Singleton<GameSaveDataStore>
    {
        private readonly string basicPath = Application.persistentDataPath;

        private ScenarioSaveData scenarioSaveData = new ScenarioSaveData();
        
        public ScenarioSaveData ScenarioSaveData => scenarioSaveData;

        protected override void Init()
        {
            base.Init();
            scenarioSaveData = Load<ScenarioSaveData>();
            scenarioSaveData.ApplyData();
        }

        private T Load<T>() where T : SaveDataBase, new()
        {
            string filePath = $"{basicPath}/{typeof(T)}";
            if (File.Exists(filePath))
            {
                string fileStr = File.ReadAllText(filePath);
                var data = JsonUtility.FromJson<T>(fileStr);
                return data;
            }

            return new T();
        }

        public void Save<T>(T data)
        {
            string filePath = $"{basicPath}/{typeof(T)}";
            string toJsonStr = JsonUtility.ToJson(data);
            
            File.WriteAllText(filePath, toJsonStr);
        }
    }
}