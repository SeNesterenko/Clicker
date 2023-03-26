using System;
using Events;
using Interfaces;
using Systems;
using Models;
using SimpleEventBus.Disposables;
using Systems.FileSystems;
using UnityEngine;

public class GameManager : MonoBehaviour, IDisposable
{
    [SerializeField] private IncomeSystem _incomeSystem;
    [SerializeField] private ConfigSystem _configSystem;
    [SerializeField] private BusinessSystem _businessSystem;
    [SerializeField] private CanvasGroupSystem _canvasGroupSystem;
    
    private ISaveFileSystem _saveFileSystem;
    private ILoadFileSystem _loadFileSystem;
    private IDeleteFileSystem _deleteFileSystem;

    private CompositeDisposable _subscriptions;

    public void Dispose()
    {
        _subscriptions?.Dispose();
    }
    
    private void Awake()
    {
        InitializeFileSystems();

        _subscriptions = new CompositeDisposable
        {
            EventStreams.Game.Subscribe<SaveGameEvent>(InitializeSaveGame),
            EventStreams.Game.Subscribe<NewGameEvent>(InitializeNewGame)
        };

        StartGame();
    }

    private void StartGame()
    {
        var saveData = _loadFileSystem.Load();
        BusinessModel[] models;

        if (saveData == null)
        {
            _incomeSystem.Initialize(0);
            _configSystem.Initialize();
            models = _configSystem.GetBusinessModels();
        }
        else
        {
            models = saveData.BusinessModels;
            _incomeSystem.Initialize(saveData.Balance);
        }

        _businessSystem.Initialize(models);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _canvasGroupSystem.ChangeStateScreen();
        }
    }

    private void InitializeFileSystems()
    {
        _saveFileSystem = new JsonFileFileSystem();
        _loadFileSystem = new JsonFileFileSystem();
        _deleteFileSystem = new JsonFileFileSystem();
    }
    
    private void InitializeSaveGame(SaveGameEvent eventData)
    {
        var businessModels = _configSystem.GetBusinessModels();
        var playerBalance = _incomeSystem.GetPlayerBalance();
        var saveData = new SaveData(playerBalance, businessModels);
        _saveFileSystem.Save(saveData);
    }

    private void InitializeNewGame(NewGameEvent eventData)
    {
        _deleteFileSystem.Delete();
        _businessSystem.ResetControllers();
        StartGame();
    }
}