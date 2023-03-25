using Systems;
using Models;
using Systems.SaveSystem;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private IncomeSystem _incomeSystem;
    [SerializeField] private ImprovementSystem _improvementSystem;
    [SerializeField] private ConfigSystem _configSystem;
    [SerializeField] private BusinessSystem _businessSystem;
    
    private ISaveSystem _saveSystem;
    private BusinessModel[] _models;
    
    private void Start()
    {
        _saveSystem = new JSONSaveSystem();
        var saveData = _saveSystem.Load();
        _models = saveData.BusinessModels;
        var balance = saveData.Balance;

        if (_models == null)
        {
            _models = _configSystem.Initialize();
        }

        _businessSystem.Initialize(_models);
        _incomeSystem.Initialize(balance);
        _improvementSystem.Initialize();
    }

    private void OnDestroy()
    {
        OnGameQuit();
    }

    private void OnGameQuit()
    {
        var saveData = new SaveData(_incomeSystem.GetPlayerBalance(), _models);
        _saveSystem.Save(saveData);
    }
}