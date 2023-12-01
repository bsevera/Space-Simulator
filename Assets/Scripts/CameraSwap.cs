using UnityEngine;


public class CameraSwap : MonoBehaviour
{
    [SerializeField]
    GameObject _cockPit;
    [SerializeField]
    GameObject _spaceFighter;
    [SerializeField]
    GameObject _cinematicCameras;

    // Update is called once per frame
    void Update()
    {
        if (_cinematicCameras.activeSelf == false)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SwapCameras();
            }                
        }      
    }

    private void SwapCameras()
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
