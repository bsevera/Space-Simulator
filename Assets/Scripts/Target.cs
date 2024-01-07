using UnityEngine;
using UnityEngine.Playables;

public class Target : MonoBehaviour
{    
    [SerializeField]
    private PlayableDirector _Director;

    private void OnTriggerEnter(Collider other)
    {        

        if (other.tag == "Player")
        {
            _Director.Play();
        }
    }

}
