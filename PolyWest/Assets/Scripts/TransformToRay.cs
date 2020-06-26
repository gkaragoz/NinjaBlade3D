using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformToRay : MonoBehaviour
{
    public LayerMask layerToRay;

    public Vector3 GetTargetPosition(Vector3 direction)
    {

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position + Vector3.up * .5f, direction, out hit, Mathf.Infinity, layerToRay))
        {
            if (hit.transform.tag == "Enemy")
            {
                Debug.DrawRay(transform.position + Vector3.up * .5f, direction * hit.distance, Color.yellow);

                Vector3 target = hit.transform.position;// - Vector3.up * .5f;
                return target;
            }
            else
            {
                Debug.DrawRay(transform.position + Vector3.up * .5f, direction * hit.distance, Color.yellow);

                Vector3 target = (hit.point - direction * .5f) - Vector3.up * .5f;
                return target;
            }

        }
        else
        {
            Debug.DrawRay(transform.position + Vector3.up * .5f, direction * 1000, Color.white);
            Debug.Log("Did not Hit");
            return transform.position;
        }

    }
}
