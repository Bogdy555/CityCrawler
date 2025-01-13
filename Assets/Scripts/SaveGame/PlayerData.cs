using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int health;
    public float xPos, yPos;

    public PlayerData (Character player)
    {
        health = player?.health ?? 0;
        xPos = player?.transform.position.x ?? 0;
        yPos = player?.transform.position.y ?? 0;
    }
}
