using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwap : MonoBehaviour
{
    [SerializeField]
    GameObject _cockPit;
    [SerializeField]
    GameObject _spaceFighter;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (_spaceFighter.activeSelf == true)
            {
                _spaceFighter.SetActive(false);
                _cockPit.SetActive(true);
            }
            else
            {
                _spaceFighter.SetActive(true);
                _cockPit.SetActive(false);
            }
        }
    }
}
