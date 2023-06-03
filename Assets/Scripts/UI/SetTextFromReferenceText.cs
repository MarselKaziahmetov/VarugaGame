using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTextFromReferenceText : MonoBehaviour
{
    private Text currentText;
    [SerializeField] private Text referenceText;

    void Start()
    {
        currentText = GetComponent<Text>();    
    }

    void Update()
    {
        currentText.text = referenceText.text;       
    }
}
