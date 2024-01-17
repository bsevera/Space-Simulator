using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _ContinueButton;

    public void ShowContinueButton()
    {
        _ContinueButton.SetActive(true);
    }

    public void HideContinueButton()
    {
        _ContinueButton.SetActive(false);

        var eventSystem = EventSystem.current;
        if (!eventSystem.alreadySelecting) eventSystem.SetSelectedGameObject(null);
    }
}
