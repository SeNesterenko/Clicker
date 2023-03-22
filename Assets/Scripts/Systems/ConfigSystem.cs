using System;
using Models;
using ScriptableObject;
using UnityEngine;

namespace Systems
{
    //Система Конфига: определение формул для расчета и цены повышения уровня бизнеса на основе конфига. Загрузка файлов конфига,
    //их хранение и предоставление доступа для других систем.
    public class ConfigSystem : MonoBehaviour
    {

        [SerializeField] private BusinessConfig _businessConfig;

        [SerializeField] private BusinessModel[] _businessModels;

       // private void Awake()
       // {
       //     _businessModels = (BusinessModel[])_businessConfig.BusinessModels;
       // }
//
       // public int GetLevelImprovement()
       // {
       //     foreach (var businessModel in _businessModels)
       //     {
       //        return businessModel.Level;
       //     }
//
       //     return -1;
       // }
//
       // public int GetIncomeImprovement()
       // {
       //     foreach (var businessModel in _businessModels)
       //     {
       //         return (int)businessModel.Income;
       //     }
       //     
       //     foreach (var businessModel in _businessModels)
       //     {
       //         foreach (var businessImprovementModel in businessModel.TypesImprovement)
       //         {
       //             businessImprovementModel
       //         }
       //     }
//
       //     return -1;
       // }
    }
}
