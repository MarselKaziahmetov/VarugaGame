using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevelBar : MonoBehaviour
{
    [SerializeField] private Slider levelBar;
    [SerializeField] private Text levelText;
    [SerializeField] private Text killsText;

    private PlayerLevel playerLevel;
    
    void Start()
    {
        playerLevel = PlayerLevel.instance;
    }

    void Update()
    {
        levelBar.value = playerLevel.CurrentExperience / (playerLevel.NextLevelExperience / levelBar.maxValue);
        levelText.text = $"LVL: {playerLevel.CurrentLevel}";
        killsText.text = $"KILLS: {playerLevel.KillsCount}";
    }
}
