using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityPointsView : MonoBehaviour
{
    [SerializeField] private Text pointsText;

    void Start()
    {
        pointsText.text = PlayerLevel.instance.AbilityPoints.ToString();
    }

    public void UpdatePointsText()
    {
        pointsText.text = PlayerLevel.instance.AbilityPoints.ToString();
    }
}
