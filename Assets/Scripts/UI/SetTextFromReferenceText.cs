using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTextFromReferenceText : MonoBehaviour
{
    private Text killsCount;
    [SerializeField] private Text referenceText;

    void Start()
    {
        killsCount = GetComponent<Text>();    
    }

    void Update()
    {
        killsCount.text = referenceText.text;       
    }
}
