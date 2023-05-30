using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitiesSkillTree : MonoBehaviour
{
    [Header("Display Changes On Button")]
    [SerializeField] private Text changesText;
    [SerializeField] private bool isChangesInPercent;
    [SerializeField] private bool isChangesNegative;
    [SerializeField] private bool isPerSecond;
    [SerializeField] private Text abilityPointsCostText;

    [Header("Logic Changes On Button")]
    public float reinforcement;
    public int abilityPointsCost;

    public void InitializeText()
    {
        abilityPointsCostText.text = abilityPointsCost.ToString();
        
        if (isChangesInPercent)
        {
            if (isChangesNegative)
            {
                if (isPerSecond)
                {
                    changesText.text = $"-{reinforcement}% / sec";
                }
                else
                {
                    changesText.text = $"-{reinforcement}%";
                }
            }
            else
            {
                if (isPerSecond)
                {
                    changesText.text = $"+{reinforcement}% / sec";
                }
                else
                {
                    changesText.text = $"+{reinforcement}%";
                }
            }
        }
        else
        {
            if (isChangesNegative)
            {
                if (isPerSecond)
                {
                    changesText.text = $"-{reinforcement} / sec";
                }
                else
                {
                    changesText.text = $"-{reinforcement}";
                }
            }
            else
            {
                if (isPerSecond)
                {
                    changesText.text = $"+{reinforcement} / sec";
                }
                else
                {
                    changesText.text = $"+{reinforcement}";
                }
            }
        }
    }
}
