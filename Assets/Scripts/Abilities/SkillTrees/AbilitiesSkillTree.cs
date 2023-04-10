using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitiesSkillTree : MonoBehaviour
{
    public Text changesText;
    public Text abilityPointsCostText;

    public int reinforcement;
    public int abilityPointsCost;

    public void InitializeText()
    {
        abilityPointsCostText.text = abilityPointsCost.ToString();
        changesText.text = $"+{reinforcement}%";
    }
}
