using UnityEngine;
using TMPro;

public class DayManager : MonoBehaviour
{
    private IWinConditionStrategy currentWinStrategy;
    public TextMeshProUGUI goalText;
    public TextMeshProUGUI statsText;


    private DailyStats todayStats = new DailyStats { totalRevenue = 0f, shapesSold = 0, thievesCaught = 0 };

    private void Start()
    {
        UpdateStatsUI(); // Set the text to 0 when the game starts
    }

    public void SetStrategy(IWinConditionStrategy newStrategy)
    {
        currentWinStrategy = newStrategy;
        goalText.text = currentWinStrategy.GetGoalDescription();
    }

    public void AddSale()
    {
        todayStats.shapesSold += 1;
        todayStats.totalRevenue += 100f;
        Debug.Log($"Sale! Revenue: ${todayStats.totalRevenue}, Shapes: {todayStats.shapesSold}");

        UpdateStatsUI();
    }

    private void UpdateStatsUI()
    {
        if (statsText != null)
        {
            statsText.text = $"Current Sales: ${todayStats.totalRevenue} | Shapes Sold: {todayStats.shapesSold}";
        }
    }

    public void SimulateEndOfDay()
    {
        if (currentWinStrategy != null && currentWinStrategy.Evaluate(todayStats))
        {
            Debug.Log("End of Day: You win!");
        }
        else
        {
            Debug.Log("End of Day: You lose!");
        }
    }
}