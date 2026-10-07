using UnityEngine;

public class NetSalesStrategy : IWinConditionStrategy
{
    private float targetSales;

    public NetSalesStrategy(float target)
    {
        targetSales = target;
    }

    public bool Evaluate(DailyStats stats)
    {
        return stats.totalRevenue >= targetSales;
    }

    public string GetGoalDescription()
    {
        return $"Goal: Earn ${targetSales} in net sales today.";
    }
}

public class QuotaStrategy : IWinConditionStrategy
{
    private int targetShapes;

    public QuotaStrategy(int target)
    {
        targetShapes = target;
    }

    public bool Evaluate(DailyStats stats)
    {
        return stats.shapesSold >= targetShapes;
    }

    public string GetGoalDescription()
    {
        return $"Goal: Sell {targetShapes} shapes today.";
    }
}