using System;
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
    [SerializeField] private CanvasGroupSystem _canvasGroupSystem;
    
    private ISaveSystem _saveSystem;
    private BusinessModel[] _models;
    
    private void Start()
    {
        _saveSystem = new JSONSaveSystem();
        var saveData = _saveSystem.Load();
        
        if (saveData == null)
        {
            _incomeSystem.Initialize(0);
            _models = _configSystem.Initialize();
        }
        else
        {
            _models = saveData.BusinessModels;
            _incomeSystem.Initialize(saveData.Balance);
        }
       
        _businessSystem.Initialize(_models);
        _improvementSystem.Initialize();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _canvasGroupSystem.MenuGame();
        }
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