using Systems;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private IncomeSystem _incomeSystem;
    [SerializeField] private ImprovementSystem _improvementSystem;
    private void Awake()
    {
        _incomeSystem.Initialize(100);
        _improvementSystem.Initialize();
    }
}