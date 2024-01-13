using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _playButtonText;

    [SerializeField]
    private GameObject _quitButton;

    [SerializeField]
    private PlayableDirector _PlayDirector;
    [SerializeField]
    private PlayableDirector _ControlsOpenDirector;
    [SerializeField]
    private PlayableDirector _ControlsCloseDirector;

    public void Start()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            _quitButton.SetActive(false);
        }

    }
    public void LoadGameAnimation()
    {
        _playButtonText.color = Color.white;
        _PlayDirector.Play();
    }

    public void LoadGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    public void LoadCredits()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Credits");
    }

    public void ShowControls()
    {
        var eventSystem = EventSystem.current;
        if (!eventSystem.alreadySelecting) eventSystem.SetSelectedGameObject(null);
        
        _ControlsOpenDirector.Play();        
    }

    public void CloseControls()
    {
        var eventSystem = EventSystem.current;
        if (!eventSystem.alreadySelecting) eventSystem.SetSelectedGameObject(null);

        _ControlsCloseDirector.Play();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
