﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotator : MonoBehaviour
{
    public float turnSpeed;
    // Start is called before the first frame update

    void Update()
    {
        transform.Rotate(0, Time.deltaTime * turnSpeed, 0);
    }
}
