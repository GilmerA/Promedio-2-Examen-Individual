using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 0.5f;

    void Update()
    {
        
        transform.position += new Vector3(0, 0, speed * Time.deltaTime);
    }
}
