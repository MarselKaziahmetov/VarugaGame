using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewLevelAccess : MonoBehaviour
{
    [SerializeField] private int levelID;
    [SerializeField] private GameObject text;

    private int level;
    private Button btn;

    void Start()
    {
        btn = GetComponent<Button>();
        level = PlayerPrefs.GetInt("LevelID", 1);
        
        GetAccessToLevel();
    }

    private void GetAccessToLevel()
    {
        if (level>=levelID)
        {
            btn.interactable = true;
            text.SetActive(false);
        }
        else
        {
            text.SetActive(true);
            btn.interactable = false;
        }
    }
}
