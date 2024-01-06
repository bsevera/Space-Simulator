using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Target : MonoBehaviour
{
    [SerializeField]
    private GameObject _Target;
    [SerializeField]
    private PlayableDirector _Director;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Target")
        {
            _Director.Play();
        }
    }
}
