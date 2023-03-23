using System.Collections.Generic;
using Models;
using ScriptableObjects;
using UnityEngine;

namespace Systems
{
    //Система Конфига: определение формул для расчета и цены повышения уровня бизнеса на основе конфига. Загрузка файлов конфига,
    //их хранение и предоставление доступа для других систем.
    public class ConfigSystem : MonoBehaviour
    {
        [SerializeField] private BusinessConfig _businessConfig;

        private BusinessModel[] _businessModels;

        private void Awake()
        {
            _businessModels = new BusinessModel[_businessConfig.BusinessModels.Length];
            
            for (var i = 0; i < _businessConfig.BusinessModels.Length; i++)
            {
                _businessModels[i] = _businessConfig.BusinessModels[i];
            }
        }
        
        public BusinessModel[] GetBusinesses(int key)
        {
            return _businessModels;
        }
    }
}
