using UnityEngine;

public interface INPCFactory
{
    NPC CreateNPC(Transform spawnPoint, Difficulty diff);
}

