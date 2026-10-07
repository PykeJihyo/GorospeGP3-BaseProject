using UnityEngine;

public class DayController : MonoBehaviour
{
    public DayManager dayManager;

    public void EquipSalesStrategy()
    {
        dayManager.SetStrategy(new NetSalesStrategy(200f));
    }

    public void EquipQuotaStrategy()
    {
        dayManager.SetStrategy(new QuotaStrategy(2));
    }
    public void SellShapeAction()
    {
        dayManager.AddSale();
    }

    public void TriggerEndDay()
    {
        dayManager.SimulateEndOfDay();
    }

}