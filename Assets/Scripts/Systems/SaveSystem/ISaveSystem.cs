using UnityEngine;
using Systems;
using Models;

public interface ISaveSystem
{
    void Save(BusinessModel[] saveDatas);

    BusinessModel[] Load();
}