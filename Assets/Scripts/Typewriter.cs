using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Typewriter : MonoBehaviour
{
    //Text _text;
    TMP_Text _tmpProText;
    string writer;

    [SerializeField] float delayBeforeStart = 0f;
    [SerializeField] float timeBtwChars = 0.1f;
    [SerializeField] string leadingChar = "";
    [SerializeField] bool leadingCharBeforeDelay = false;

    private AudioSource _AudioSource;

    private void Awake()
    {
        _tmpProText = GetComponent<TMP_Text>()!;

        if (_tmpProText != null)
        {            
            writer = _tmpProText.text;
            _tmpProText.text = "";            
        }

        GetAudioSourceReference();
    }

    private void OnEnable()
    {
        StartCoroutine("TypeWriterTMP");
    }

    private void GetAudioSourceReference()
    {
        //get the audio component of the player and assign the audio clip for the fire laser sound
        _AudioSource = GetComponent<AudioSource>();
        if (_AudioSource == null)
        {
            Debug.LogError("Audio Source of the Player is Null");
        }
    }

    IEnumerator TypeWriterTMP()
    {
        _tmpProText.text = leadingCharBeforeDelay ? leadingChar : "";

        yield return new WaitForSeconds(delayBeforeStart);

        foreach (char c in writer)
        {
            if (_tmpProText.text.Length > 0)
            {
                _tmpProText.text = _tmpProText.text.Substring(0, _tmpProText.text.Length - leadingChar.Length);
                _AudioSource.Play();
                
            }
            _tmpProText.text += c;
            _tmpProText.text += leadingChar;
            yield return new WaitForSeconds(timeBtwChars);
        }

        if (leadingChar != "")
        {
            _tmpProText.text = _tmpProText.text.Substring(0, _tmpProText.text.Length - leadingChar.Length);
        }
    }


}
