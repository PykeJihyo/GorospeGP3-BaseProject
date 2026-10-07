using UnityEngine;

public class Customer : NPC
{
    public float budget;
    public override void Initialize(Difficulty diff)
    {
        budget = diff == Difficulty.Easy ? 500f : (diff == Difficulty.Medium ? 250f : 50f);
        GetComponent<Renderer>().material.color = Color.blue; // Visual proof for video
        gameObject.name = $"Customer (Budget: ${budget})";
    }
}