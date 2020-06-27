using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uiManager;
    public GameObject[] enemies;
    int killedEnemyCount;


    public void KillEnemy()
    {
        killedEnemyCount += 1;
        if (killedEnemyCount == enemies.Length)
        {
            Debug.Log("Level Passed");
            uiManager.OpenSuccesPanel();
            return;
        }

    }
}
