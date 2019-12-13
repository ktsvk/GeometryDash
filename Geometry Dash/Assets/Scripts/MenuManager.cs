using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static int attempt = 1;
    public void PlayButton()
    {
        SceneManager.LoadScene("Level01");
    }

    public void ExitButton()
    { 
        Application.Quit();  
    }

    public void ChangeLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
