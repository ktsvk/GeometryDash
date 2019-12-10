using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRotationScript : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float rotationSpeed;
    void Update()
    {
        transform.RotateAround(target.position, Vector3.right, rotationSpeed * Time.deltaTime);
    }
}
