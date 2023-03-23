using Systems;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private IncomeSystem _incomeSystem;
    [SerializeField] private ImprovementSystem _improvementSystem;
    [SerializeField] private SaveSystem _saveSystem;
    [SerializeField] private ConfigSystem _configSystem;
    [SerializeField] private BusinessSystem _businessSystem;
    
    private void Start()
    {
        var models = _configSystem.Initialize();
        _businessSystem.Initialize(models);
        
        _incomeSystem.Initialize(100);
        _improvementSystem.Initialize();
    }
}