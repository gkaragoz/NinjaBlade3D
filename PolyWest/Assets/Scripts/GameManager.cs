using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemies;
    int killedEnemyCount;


    public void KillEnemy()
    {
        if (killedEnemyCount == enemies.Length)
        {
            Debug.Log("Level Passed");
            return;
        }
        else
        {
            killedEnemyCount += 1;

        }
    }
}
