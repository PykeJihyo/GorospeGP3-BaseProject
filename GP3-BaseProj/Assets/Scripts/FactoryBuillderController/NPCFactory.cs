using UnityEngine;


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