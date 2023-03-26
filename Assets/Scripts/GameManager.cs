using Interfaces;
using Systems;
using Models;
using SimpleEventBus.Disposables;
using Systems.FileSystems;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private IncomeSystem _incomeSystem;
    [SerializeField] private ImprovementSystem _improvementSystem;
    [SerializeField] private ConfigSystem _configSystem;
    [SerializeField] private BusinessSystem _businessSystem;
    [SerializeField] private CanvasGroupSystem _canvasGroupSystem;
    
    private ISaveFileSystem _saveFileSystem;
    private ILoadFileSystem _loadFileSystem;
    private IDeleteFileSystem _deleteFileSystem;

    private CompositeDisposable _subscribes;

    private void Start()
    {
        InitializeSystems();

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
        _improvementSystem.Initialize();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _canvasGroupSystem.MenuGame();
        }
    }

    private void InitializeSystems()
    {
        _saveFileSystem = new JsonFileFileSystem();
        _loadFileSystem = new JsonFileFileSystem();
        _deleteFileSystem = new JsonFileFileSystem();
    }
    
    private void CollectSaveData()
    {
        var businessModels = _configSystem.GetBusinessModels();
        var playerBalance = _incomeSystem.GetPlayerBalance();
        var saveData = new SaveData(playerBalance, businessModels);
    }
}