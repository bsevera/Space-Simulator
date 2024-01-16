using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{

    public void ReloadScene()
    {        
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    public void QuitToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
