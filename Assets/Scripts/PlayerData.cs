using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level;
    public int coin;

    public PlayerData(int sceneIndex, int coinn)
    {
        level = sceneIndex;
        coin = coinn;
    }

}