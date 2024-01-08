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

    private void Awake()
    {
        _tmpProText = GetComponent<TMP_Text>()!;

        if (_tmpProText != null)
        {
            Debug.Log("TypeWriter :: Objective text = " + _tmpProText.text);

            writer = _tmpProText.text;
            _tmpProText.text = "";

            StartCoroutine("TypeWriterTMP");
        }        
    }

    IEnumerator TypeWriterTMP()
    {
        Debug.Log("TypeWriter :: IEnumerator TypewriterTMP - Before Delay of: " + delayBeforeStart);

        _tmpProText.text = leadingCharBeforeDelay ? leadingChar : "";

        yield return new WaitForSeconds(delayBeforeStart);

        Debug.Log("TypeWriter :: IEnumerator TypewriterTMP - After Delay of: " + delayBeforeStart);
        Debug.Log("TypeWriter :: Writer Value = " + writer);

        foreach (char c in writer)
        {
            Debug.Log("TypeWriter :: C = " + c);

            if (_tmpProText.text.Length > 0)
            {
                _tmpProText.text = _tmpProText.text.Substring(0, _tmpProText.text.Length - leadingChar.Length);
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
