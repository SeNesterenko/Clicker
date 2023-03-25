using Models;

namespace Systems.SaveSystem
{
    public interface ISaveSystem
    {
        void Save(SaveData saveData);

        SaveData Load();
    }
}