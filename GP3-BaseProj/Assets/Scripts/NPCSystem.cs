using UnityEngine;

// abstract NPC Product
public abstract class NPC : MonoBehaviour
{
    public abstract void Initialize(Difficulty diff);
}

// Customer
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

// Thief
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

// Factory Interface
public interface INPCFactory
{
    NPC CreateNPC(Transform spawnPoint, Difficulty diff);
}

// Factories
public class CustomerFactory : INPCFactory
{
    public NPC CreateNPC(Transform spawnPoint, Difficulty diff)
    {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        go.transform.position = spawnPoint.position;
        Customer customer = go.AddComponent<Customer>();
        customer.Initialize(diff);
        return customer;
    }
}

public class ThiefFactory : INPCFactory
{
    public NPC CreateNPC(Transform spawnPoint, Difficulty diff)
    {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        go.transform.position = spawnPoint.position;
        Thief thief = go.AddComponent<Thief>();
        thief.Initialize(diff);
        return thief;
    }
}