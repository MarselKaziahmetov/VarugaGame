using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    public static PlayerLevel instance;

    private int currentLevel;
    public int CurrentLevel
    {
        get { return currentLevel; }
    }

    private int maxLevel = 50;

    private float currentExperience;
    public float CurrentExperience
    {
        get { return currentExperience; }
        set { currentExperience = value; }
    }

    private float nextLevelExperience;
    public float NextLevelExperience
    {
        get { return nextLevelExperience; }
        set { nextLevelExperience = value; }
    }

    private int killsCount;
    public int KillsCount
    {
        get { return killsCount; }
        set { killsCount = value; }
    }
    private void Awake()
    {
        if (instance == null)
        { 
            instance = this; 
        }
        else if (instance == this)
        { 
            Destroy(gameObject); 
        }

        DontDestroyOnLoad(gameObject);

        currentLevel = 0;
        nextLevelExperience = 10;
    }

    private void Update()
    {
        LevelIncrease();
    }

    private void LevelIncrease()
    {
        if (currentExperience >= nextLevelExperience && currentLevel < maxLevel)
        {
            currentLevel++;
            currentExperience -= nextLevelExperience;
            nextLevelExperience *= 1.2f;
        }
    }

    private void NewAbilityPick()
    {
        Time.timeScale = 0;

    }
}
