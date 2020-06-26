using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerJump : MonoBehaviour
{
    public bool explosionType;

    public float playerSpeed;
    public Transform targetPos;
    Transform target;
    public Transform targetPos2;
    public ExplosiveBarrel explosive;

    public float power, upforce, radius;

    bool canMove = false;
    private void Start()
    {
        target = targetPos;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            canMove = true;
        }

        if (canMove)
        {

            transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * playerSpeed);
            if (Vector3.Distance(transform.position, target.position) < 0.1f)
            {
                transform.position = target.position;
                ChangeTarget();
                canMove = false;
                if (explosionType)
                {
                    Detonate();

                }
                else
                {

                    explosive.Explode();
                }
                StartCoroutine(RestartScene());
            }
        }
    }

    public void Detonate()
    {
        Vector3 explosionPosition = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(power, explosionPosition, radius, upforce, ForceMode.Impulse);

            }
        }
    }


    IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }
    public void ChangeTarget()
    {
        if (target == targetPos)
        {
            target = targetPos2;
        }
        else
        {
            target = targetPos;
        }
    }
}
