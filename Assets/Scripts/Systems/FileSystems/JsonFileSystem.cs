using System.IO;
using Events;
using Interfaces;
using Models;
using Newtonsoft.Json;
using SimpleEventBus.Disposables;
using UnityEngine;

namespace Systems.FileSystems
{
    public class JsonFileSystem : ISaveSystem, ILoadFileSystem, IDeleteFileSystem
    {
        private readonly string _filePath;
        private readonly JsonSerializer _serializer;

        private readonly CompositeDisposable _subscriptions;

        public JsonFileSystem()
        {
            _filePath = Application.persistentDataPath + "/Save.json";
            _serializer = new JsonSerializer();

            _subscriptions = new CompositeDisposable
            {
   //             EventStreams.Game.Subscribe<SaveGameEvent>(Save)
            };
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
            var saveData = _serializer.Deserialize<SaveData>(reader);

            return saveData;
        }

        public void Delete()
        {
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }
        }
    }
}