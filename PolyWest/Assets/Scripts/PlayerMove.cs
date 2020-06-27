using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Vector3 myTargetPos;
    bool isClose = false;
    public Animator playerAnim;
    public SwipeInput swipeInput;
    public GameManager gameManager;

    public VFXSplatterOnCollision vfx;
    public float playerSpeed;
    public void MoveToPos(Vector3 targetPos)
    {
        isClose = true;
        myTargetPos = targetPos;
        playerAnim.SetBool("Run", true);
        transform.LookAt(targetPos);
        //LeanTween.move(transform.gameObject, targetPos, .6f);
        StartCoroutine(PlayerMovement(targetPos));
    }


    IEnumerator PlayerMovement(Vector3 targetPos)
    {
        playerAnim.SetBool("Run", true);
        swipeInput.canInput = false;

        while (isClose)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * playerSpeed);
            if (Vector3.Distance(transform.position, myTargetPos) < .3f)
            {
                transform.position = targetPos;
                playerAnim.SetBool("Run", false);
                isClose = false;
                swipeInput.canInput = true;

            }
            yield return null;
        }
    }


    public void StopMovement()
    {
        isClose = false;

    }

    public void KillEnemy(GameObject enemy)
    {
        enemy.GetComponent<Enemy>().KillEnemy();
        playerAnim.SetTrigger("Attack");
        gameManager.KillEnemy();
    }


    public void Die()
    {
        StopMovement();
        playerAnim.SetTrigger("Die");
    }

    public void PlayVFX(Vector3 pos)
    {
        vfx.transform.position = pos + Vector3.up;
        vfx.Play(Vector3.forward, 10, 15);
    }
}
