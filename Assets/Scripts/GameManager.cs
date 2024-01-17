using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private UIManager _UIManager;
    [SerializeField]
    private AudioSource _backgroundAudioSource;
    [SerializeField]
    private GameObject _RestartMenu;

    private bool _restartBackgroundAudioOnResume = false;
    

    private void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();            
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        if (_backgroundAudioSource.isPlaying) 
        {
            _backgroundAudioSource.Pause();
            _restartBackgroundAudioOnResume = true;
        }

        _UIManager = _RestartMenu.GetComponent<UIManager>();
        if (_UIManager != null)
        {
            _UIManager.gameObject.SetActive(true);
            _UIManager.ShowContinueButton();
        }

    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        _UIManager.gameObject.SetActive(false);
        _UIManager.HideContinueButton();

        if (_restartBackgroundAudioOnResume)
        {
            _backgroundAudioSource.Play();
        }
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    public void QuitToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }


}
