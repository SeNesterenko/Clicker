using Models;
using SimpleEventBus.Events;

public class LevelPriceEvent : EventBase
{
    public BusinessModel BusinessModel { get; }

    public LevelPriceEvent(BusinessModel businessModel, PlayerBalanceModel playerBalanceModel)
    {
        BusinessModel = businessModel;
    }
}