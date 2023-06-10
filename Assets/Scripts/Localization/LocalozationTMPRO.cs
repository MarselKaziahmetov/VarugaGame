using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class LocalozationTMPRO : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern string GetLang();

    [SerializeField] private TextMeshProUGUI languageText;

    public string currentLanguage;
    public static LocalozationTMPRO instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            currentLanguage = GetLang();
            languageText.text = currentLanguage;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
