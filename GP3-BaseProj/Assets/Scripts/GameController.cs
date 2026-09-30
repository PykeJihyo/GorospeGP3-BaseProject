using UnityEngine;

public class GameController : MonoBehaviour
{
    public LevelManager levelManager;
    public Transform npcSpawnPoint;
    public Transform tableSpawnPoint;

    // Factory Pattern Execution
    public void SpawnRandomNPC()
    {
        INPCFactory factory;

        // Randomly choose to spawn a thief or customer
        if (Random.value > 0.7f)
            factory = new ThiefFactory();
        else
            factory = new CustomerFactory();

        factory.CreateNPC(npcSpawnPoint, levelManager.currentDifficulty);
    }

    // Builder Pattern Execution
    public void BuildPerfectShape()
    {
        IShapeBuilder builder = new ProceduralShapeBuilder(tableSpawnPoint);
        builder.SetBaseShape(ShapeType.Cube);
        builder.SetPerfectness(100f); // 100% perfect
        builder.ApplyDistortion();
        builder.CalculateBaseValue(levelManager.currentDifficulty);

        ShapeItem finalShape = builder.GetShape();
        // Shift spawn point slightly so they don't stack perfectly on top of each other
        tableSpawnPoint.position += new Vector3(1.5f, 0, 0);
    }

    public void BuildFlawedShape()
    {
        IShapeBuilder builder = new ProceduralShapeBuilder(tableSpawnPoint);
        builder.SetBaseShape(ShapeType.Cube);
        builder.SetPerfectness(Random.Range(10f, 60f)); // Random flawed percentage
        builder.ApplyDistortion();
        builder.CalculateBaseValue(levelManager.currentDifficulty);

        ShapeItem finalShape = builder.GetShape();
        tableSpawnPoint.position += new Vector3(1.5f, 0, 0);
    }
}