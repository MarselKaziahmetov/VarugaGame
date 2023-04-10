using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceBubble : MonoBehaviour
{
    [SerializeField] private int earnedExperience;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerLevel.instance.CurrentExperience += earnedExperience;
            Destroy(gameObject);
        }
    }
}
