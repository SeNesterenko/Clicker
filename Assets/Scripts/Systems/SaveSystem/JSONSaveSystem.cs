
using System.IO;
using UnityEngine;
using Models;
using Newtonsoft.Json;

namespace Systems
{

    public class JSONSaveSystem : ISaveSystem
    {
        private readonly string _filePath;
        private JsonSerializer _serializer;

        public JSONSaveSystem()
        {
            _filePath = Application.persistentDataPath + "/Save.json";
            _serializer = new JsonSerializer();
        }

        public async void Save(BusinessModel[] saveDatas)
        {
            foreach (var data in saveDatas)
            {
                using (StreamWriter sw = new StreamWriter(_filePath))
                {
                    using (JsonWriter writer = new JsonTextWriter(sw))
                    {
                        _serializer.Serialize(writer, data);
                    }
                }
            }
            
            Debug.Log("файл сохранения успешно записан");
        }

        public BusinessModel[] Load()
        {
            if (!File.Exists(_filePath))
                return null;


            BusinessModel[] models;
            using (StreamReader sr = new StreamReader(_filePath))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                models = _serializer.Deserialize<BusinessModel[]>(reader);             
            }
            
            
            Debug.Log("файл сохранения успешно загружен");
            return models;
        }
    }
}