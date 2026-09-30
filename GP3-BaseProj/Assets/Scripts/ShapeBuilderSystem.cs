using UnityEngine;

public enum ShapeType { Cube, Sphere }

//  final Product
public class ShapeItem : MonoBehaviour
{
    public ShapeType type;
    public float perfectness;
    public float marketValue;
}

//  Builder Interface
public interface IShapeBuilder
{
    void SetBaseShape(ShapeType type);
    void SetPerfectness(float percentage);
    void ApplyDistortion();
    void CalculateBaseValue(Difficulty diff);
    ShapeItem GetShape();
}

// Builder
public class ProceduralShapeBuilder : IShapeBuilder
{
    private GameObject shapeGO;
    private ShapeItem shapeItem;

    public ProceduralShapeBuilder(Transform spawnPoint)
    {
        shapeGO = new GameObject("BuildingShape...");
        shapeGO.transform.position = spawnPoint.position;
        shapeItem = shapeGO.AddComponent<ShapeItem>();
    }

    public void SetBaseShape(ShapeType type)
    {
        shapeItem.type = type;
        GameObject visual = type == ShapeType.Cube ? GameObject.CreatePrimitive(PrimitiveType.Cube) : GameObject.CreatePrimitive(PrimitiveType.Sphere);
        visual.transform.SetParent(shapeGO.transform);
        visual.transform.localPosition = Vector3.zero;
    }

    public void SetPerfectness(float percentage)
    {
        shapeItem.perfectness = Mathf.Clamp(percentage, 0f, 100f);
    }

    public void ApplyDistortion()
    {
        // Visual distortion: 100% perfect means 0 distortion.
        float distortionLevel = (100f - shapeItem.perfectness) / 100f;
        Transform visual = shapeGO.transform.GetChild(0);

        // Randomly scale axes to look deformed if imperfect
        float scaleX = 1f + Random.Range(-distortionLevel, distortionLevel);
        float scaleY = 1f + Random.Range(-distortionLevel, distortionLevel);
        float scaleZ = 1f + Random.Range(-distortionLevel, distortionLevel);
        visual.localScale = new Vector3(scaleX, scaleY, scaleZ);

        // Discolor the shape based on distortion
        visual.GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.gray, distortionLevel);
    }

    public void CalculateBaseValue(Difficulty diff)
    {
        float baseVal = shapeItem.perfectness * 10f;
        float diffMultiplier = diff == Difficulty.Easy ? 1.5f : (diff == Difficulty.Medium ? 1.0f : 0.5f);
        shapeItem.marketValue = Mathf.Round(baseVal * diffMultiplier);

        shapeGO.name = $"{Mathf.Round(shapeItem.perfectness)}% Perfect {shapeItem.type} (${shapeItem.marketValue})";
    }

    public ShapeItem GetShape()
    {
        return shapeItem;
    }
}