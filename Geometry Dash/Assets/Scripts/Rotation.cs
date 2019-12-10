using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private Vector3 direction = new Vector3(0f, 1f, 0f);

    void Update()
    {
        transform.Rotate(direction * speed * Time.deltaTime);
    }
}
