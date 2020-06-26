using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject parentMesh;
    public GameObject destructableMesh;


    public void KillEnemy()
    {
        parentMesh.SetActive(false);
        destructableMesh.SetActive(true);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            KillEnemy();
        }
    }
}
