using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector3 offset;
    void Start()
    {

    }

    void FixedUpdate()
    {
        transform.position = target.position + offset;
    }
}
