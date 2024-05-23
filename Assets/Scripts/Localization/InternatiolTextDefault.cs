using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InternatiolTextDefault : MonoBehaviour
{
    [SerializeField] private string en;
    [SerializeField] private string ru;

    private void Start()
    {
        switch (Localization.instance.currentLanguage)
        {
            case "en":
                GetComponent<Text>().text = en;
                break;
            case "ru":
                GetComponent<Text>().text = ru;
                break;
            default:
                GetComponent<Text>().text = en;
                break;
        }
    }
}
