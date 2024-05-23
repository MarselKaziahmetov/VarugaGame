using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevelBar : MonoBehaviour
{
    [SerializeField] private Slider levelBar;
    [SerializeField] private Text levelText;
    [SerializeField] private Text killsText;
    [SerializeField] private Text coinsText;

    private PlayerLevel playerLevel;
    
    void Start()
    {
        playerLevel = PlayerLevel.instance;
    }

    void Update()
    {
        levelBar.value = playerLevel.CurrentExperience / (playerLevel.NextLevelExperience / levelBar.maxValue);
        levelText.text = $"{playerLevel.CurrentLevel}";
        killsText.text = $"{playerLevel.KillsCount}";
        coinsText.text = $"{Bank.instance.CoinsAmount}";
    }
}
