using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private float staticSpeed = 2f;
    [SerializeField]
    private float jumpForce = 4f;
    [SerializeField]
    private TextMeshProUGUI speed;
    [SerializeField]
    private TextMeshProUGUI score;
    private bool isGround = false;

    [SerializeField]
    private float rotationSpeed = 3f;
    private Vector3 rotation = Vector3.zero;
    void FixedUpdate()
    {
        rb.AddForce(Vector3.right * staticSpeed);
        if(Input.GetKey(KeyCode.Space) && isGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            int dir = Random.Range(1, 3);
            if(dir == 1)
            {
                rotation = Vector3.up;
            }
            else
            {
                rotation = Vector3.up * -1;
            }
        }
        if(!isGround)
        {
            transform.Rotate(rotation, rotationSpeed);
        }
        speed.text = "SPEED " + Mathf.Round(rb.velocity.x);
        score.text = "SCORE " + Mathf.Round(transform.position.x);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
}
