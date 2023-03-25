using System.IO;
using Models;
using Newtonsoft.Json;
using UnityEngine;

namespace Systems.SaveSystem
{

    public class JSONSaveSystem : ISaveSystem
    {
        private readonly string _filePath;
        private readonly JsonSerializer _serializer;

        public JSONSaveSystem()
        {
            _filePath = Application.persistentDataPath + "/Save.json";
            _serializer = new JsonSerializer();
        }

        public void Save(SaveData saveData)
        {
            using var sw = new StreamWriter(_filePath);
            using JsonWriter writer = new JsonTextWriter(sw);
            _serializer.Serialize(writer, saveData);
        }

        public SaveData Load()
        {
            if (!File.Exists(_filePath))
            {
                return null;
            }

            using var sr = new StreamReader(_filePath);
            using JsonReader reader = new JsonTextReader(sr);
            var models = _serializer.Deserialize<SaveData>(reader);

            return models;
        }
    }
}