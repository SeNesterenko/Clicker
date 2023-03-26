using System;
using Interfaces;
using Systems;
using Models;
using Systems.FileSystems;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private IncomeSystem _incomeSystem;
    [SerializeField] private ImprovementSystem _improvementSystem;
    [SerializeField] private ConfigSystem _configSystem;
    [SerializeField] private BusinessSystem _businessSystem;
    [SerializeField] private CanvasGroupSystem _canvasGroupSystem;
    
    private ISaveSystem _saveSystem;
    private ILoadFileSystem _loadFileSystem;
    private IDeleteFileSystem _deleteSystem;
    
    private BusinessModel[] _models;

    private void Start()
    {
        InitializeSystems();

        var saveData = _loadFileSystem.Load();

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

    private void InitializeSystems()
    {
        _saveSystem = new JsonFileSystem();
        _loadFileSystem = new JsonFileSystem();
        _deleteSystem = new JsonFileSystem();
    }
    
    private void OnGameQuit()
    {
        var saveData = new SaveData(_incomeSystem.GetPlayerBalance(), _models);
        _saveSystem.Save(saveData);
    }
}