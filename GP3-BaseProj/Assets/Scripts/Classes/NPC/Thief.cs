using UnityEngine;

public class Thief : NPC
{
    public float stealSpeed;
    public override void Initialize(Difficulty diff)
    {
        stealSpeed = diff == Difficulty.Easy ? 2f : (diff == Difficulty.Medium ? 5f : 10f);
        GetComponent<Renderer>().material.color = Color.red; // Visual proof for video
        gameObject.name = $"Thief (Speed: {stealSpeed})";
    }
}