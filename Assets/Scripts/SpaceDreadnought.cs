using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SpaceDreadnought : MonoBehaviour
{
    [SerializeField]
    private PlayableDirector _Director;

    private void OnTriggerEnter(Collider other)
    {        
        if (other.tag == "Player")
        {
            Debug.Log("Position of Dreadnought = " + this.gameObject.transform.position);
            _Director.Play();
        }
    }
}
