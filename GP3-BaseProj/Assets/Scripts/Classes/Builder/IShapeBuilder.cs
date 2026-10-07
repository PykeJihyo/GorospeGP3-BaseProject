using UnityEngine;

public interface IShapeBuilder
{
    void SetBaseShape(ShapeType type);
    void SetPerfectness(float percentage);
    void ApplyDistortion();
    void CalculateBaseValue(Difficulty diff);
    ShapeItem GetShape();
}