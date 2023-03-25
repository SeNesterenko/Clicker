using System.Threading;
using System.Threading.Tasks;
using Systems;
using Models;
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
        var models = _saveSystem.Load();

        if(models == null || models.Length == 0)
            models = _configSystem.Initialize();

        _models = models;
        
        _businessSystem.Initialize(models);
        
        _incomeSystem.Initialize(0);
        _improvementSystem.Initialize();
    }

    private void OnGameQuit()
    {
        _saveSystem.Save(_models);
    }
}