using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static int attempt = 1;
    [SerializeField]
    private GameObject Panel;
    public void PlayButton()
    {
        SceneManager.LoadScene("Level01");
        Time.timeScale = 1;
    }

    public void ExitButton()
    { 
        Application.Quit();  
    }

    public void ChangeLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void Resume()
    {
        Panel.SetActive(false);
        Time.timeScale = 1;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
