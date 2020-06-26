using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    public PlayerMove playerMove;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Vurdum");
        if (other.tag == "Enemy")
        {
            playerMove.KillEnemy(other.gameObject);
        }
        if (other.tag == "EnemyDeathPosition")
        {
            other.GetComponentInParent<Animator>().SetTrigger("Attack");
            playerMove.Die();
        }
    }

}
