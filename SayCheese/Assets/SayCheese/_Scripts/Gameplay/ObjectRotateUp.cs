﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectRotate : MonoBehaviour
{

}
public class ObjectRotateUp : ObjectRotate
{
    public float speed;
    void Update()
    {
        transform.Rotate(Vector3.up * speed *Time.deltaTime,Space.Self);
    }
}
