using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    public static Bank instance;

    public string coinsAmountKey = "coinsAmount";

    private int coinsAmount;
    public int CoinsAmount 
    {
        get { return coinsAmount; }
        set { coinsAmount = value;  PlayerPrefs.SetInt(coinsAmountKey, value); }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        coinsAmount = PlayerPrefs.GetInt(coinsAmountKey, 0);
    }

    
}
