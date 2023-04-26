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
    [SerializeField] private Text abilityPointsCostText;

    [Header("Logic Changes On Button")]
    public int reinforcement;
    public int abilityPointsCost;

    public void InitializeText()
    {
        abilityPointsCostText.text = abilityPointsCost.ToString();
        
        if (isChangesInPercent)
        {
            if (isChangesNegative)
            {
                changesText.text = $"-{reinforcement}%";
            }
            else
            {
                changesText.text = $"+{reinforcement}%";
            }
        }
        else
        {
            if (isChangesNegative)
            {
                changesText.text = $"-{reinforcement}";
            }
            else
            {
                changesText.text = $"+{reinforcement}";
            }
        }
    }
}
