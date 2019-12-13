using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private float speedMove;
    [SerializeField]
    private float jumpPower;

    [SerializeField]
    private TextMeshProUGUI score;
    [SerializeField]
    private TextMeshProUGUI attempt;
    [SerializeField]
    private Transform finish;

    [SerializeField]
    private float rotationSpeed = 3f;

    private Vector3 moveVector;
    private Vector3 rotation;
    private float gravityForce;
    private float posX = -1;
    private bool isGround;
    private void Start()
    {
        Time.timeScale = 1;
        rotation = Vector3.zero;
        isGround = false;
        posX = -1;
    }
    void Movement()
    {
        moveVector = Vector3.zero;
        moveVector.x = speedMove;
        moveVector.y = gravityForce;

        rb.velocity = moveVector;
    }
    void FixedUpdate()
    {
        GameGravity();
        Movement();
        if (posX == rb.position.x)
        {
            Debug.Log(posX);
            FindObjectOfType<GameManager>().GameOver();
        }
        posX = rb.position.x;
        score.text = "PROGRESS " + Mathf.Round(transform.position.x / finish.position.x * 100) + "%";
        attempt.text = "ATTEMPT " + MenuManager.attempt;
    }
    private void GameGravity()
    {
        if (!isGround)
        {
            gravityForce -= 50f * Time.deltaTime;
        }
        else gravityForce = -1f;
        if (Input.GetKey(KeyCode.Space) && isGround)
        {
            gravityForce = jumpPower;
            int dir = Random.Range(1, 3);
            if (dir == 1)
            {
                rotation = Vector3.up;
            }
            else
            {
                rotation = Vector3.up * -1;
            }
        }
        if (!isGround)
        {
            transform.Rotate(rotation, rotationSpeed);
        }
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
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Finish"))
        {
            MenuManager.attempt = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
