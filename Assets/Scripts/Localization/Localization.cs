using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class Localization : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern string GetLang();

     public string currentLanguage;
    public static Localization instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            currentLanguage = GetLang();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
