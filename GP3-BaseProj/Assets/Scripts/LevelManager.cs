using UnityEngine;

public enum Difficulty { Easy, Medium, Hard }

public class LevelManager : MonoBehaviour
{
    public Difficulty currentDifficulty = Difficulty.Medium;
}