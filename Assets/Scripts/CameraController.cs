using UnityEngine;
using Cinemachine;
using System.Threading;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    GameObject _CockPit;
    [SerializeField]
    CinemachineVirtualCamera _CockpitVC;

    [SerializeField]
    GameObject _SpaceFighter;
    [SerializeField]
    CinemachineVirtualCamera _SpaceFighterVC;

    [SerializeField]
    CinemachineBlendListCamera _CinematicCameraVC;

    private bool _CinematicCameraActive = false;
    private float _WaitTime = 15.0f;
    private float _Timer = 0.0f;

    private void Start()
    {
        SetCameraDefaultPriorities();
    }

    // Update is called once per frame
    void Update()
    {
        SetCameras();
    }

    private void SetCameras()
    {
        if (_CinematicCameraActive)
        {
            if ((Input.anyKey) || (Input.GetAxis("Mouse X") != 0) || (Input.GetAxis("Mouse Y") != 0))
            {
                //deactivate cinematic camera and show spaceship vc
                DeactivateCinematicCamera();
                ResetTimer();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SwapCameras();
                ResetTimer();
            }
            else
            {
                if ((_CockpitVC.isActiveAndEnabled) && (Input.GetAxis("Mouse X") != 0) && (Input.GetAxis("Mouse Y") != 0))
                {
                    ResetTimer();
                }
                else
                {
                    _Timer += Time.deltaTime;

                    //check to see if specified seconds has passed.  If it has, activate the cinematic camera
                    if (_Timer > _WaitTime)
                    {
                        ActivateCinematicCamera();
                        ResetTimer();
                    }
                }
            }
        }
    }

    private void ResetTimer()
    {
        _Timer = 0.0f;
    }

    private void SetCameraDefaultPriorities()
    {
        _CinematicCameraActive = false;

        _SpaceFighterVC.Priority = 40;
        _CockpitVC.Priority = 0;
    }

    private void SwapCameras()
    {
        if (_SpaceFighter.activeSelf)
        {
            _SpaceFighter.SetActive(false);
            _SpaceFighterVC.Priority = 0;

            _CockPit.SetActive(true);
            _CockpitVC.Priority = 40;
        }
        else
        {
            _CockPit.SetActive(false);
            _CockpitVC.Priority = 0;

            _SpaceFighter.SetActive(true);
            _SpaceFighterVC.Priority = 40;
        }        
    }

    private void ActivateCinematicCamera()
    {
        _CockpitVC.Priority = 0;
        _CockPit.SetActive(false);

        _SpaceFighterVC.Priority = 0;
        _SpaceFighter.SetActive(true);

        _CinematicCameraVC.Priority = 40;

        _CinematicCameraActive = true;
    }

    private void DeactivateCinematicCamera()
    {
        _CinematicCameraVC.Priority = 0;
        _SpaceFighterVC.Priority = 40;

        _CinematicCameraActive = false;
    }

    public void OnMouseDown()
    {        
        DeactivateCinematicCamera();
        _Timer = 0.0f;
    }

}
