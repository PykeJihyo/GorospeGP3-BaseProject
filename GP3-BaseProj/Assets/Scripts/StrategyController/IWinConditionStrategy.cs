using UnityEngine;
public interface IWinConditionStrategy
{
    bool Evaluate(DailyStats stats);
    string GetGoalDescription();
}
