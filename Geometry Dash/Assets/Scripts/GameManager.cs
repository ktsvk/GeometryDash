using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public void GameOver()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("Restart", 0.1f);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Invoke("Restart", 0.1f);
        }
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * - 0.8f);
    }
}
