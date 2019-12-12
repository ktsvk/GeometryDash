using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement player;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            var obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
            var bigObstacle = GameObject.FindGameObjectsWithTag("BigObstacle");
            var superBigObstacle = GameObject.FindGameObjectsWithTag("SupreBigObstacle");
            for (int i = 0; i < obstacles.Length; i++)
            {
                obstacles[i].GetComponent<Rigidbody>().useGravity = true;
            }
            for (int i = 0; i < bigObstacle.Length; i++)
            {
                bigObstacle[i].GetComponent<Rigidbody>().useGravity = true;
            }
            for (int i = 0; i < superBigObstacle.Length; i++)
            {
                superBigObstacle[i].GetComponent<Rigidbody>().useGravity = true;
            }
            player.enabled = false;
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
