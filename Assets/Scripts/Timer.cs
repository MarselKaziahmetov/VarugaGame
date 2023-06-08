using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private int newLevelID;
    [SerializeField] private float timeToUnlockNewLevel;
    public bool timerIsActivated;

    private Text timerText;
    private float timer = 0;

    private void Start()
    {
        timerText = GetComponent<Text>();    
    }

    void Update()
    {
        if (timerIsActivated)
        {
            ActivateTimer();
            UpdateTimeText();
        }

        NewLevelAccess();
    }

    private void ActivateTimer()
    {
        timer += Time.deltaTime;
    }

    private void UpdateTimeText()
    {
        float minutes = Mathf.FloorToInt(timer / 60);
        float seconds = Mathf.FloorToInt(timer % 60);
        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    private void NewLevelAccess()
    {
        if (timer>timeToUnlockNewLevel)
        {
            PlayerPrefs.SetInt("LevelID", newLevelID);
        }
    }
}
