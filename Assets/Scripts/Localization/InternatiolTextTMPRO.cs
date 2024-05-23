using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InternatiolTextTMPRO : MonoBehaviour
{
    [SerializeField] private string en;
    [SerializeField] private string ru;

    private void Start()
    {
        switch (Localization.instance.currentLanguage)
        {
            case "en":
                GetComponent<TextMeshProUGUI>().text = en;
                break;
            case "ru":
                GetComponent<TextMeshProUGUI>().text = ru;
                break;
            default:
                GetComponent<TextMeshProUGUI>().text = en;
                break;
        }
    }
}
