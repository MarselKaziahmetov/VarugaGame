using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float stoppingDistance;
    [SerializeField] private float destroyIfNotVisibleDelay;

    private GameObject player;
    private Vector2 direction;
    private Vector3 initialScale;
    private float lastUpdateTime;

    private void Start()
    {
        initialScale = transform.localScale;
        player = GameObject.FindWithTag("Player");

        lastUpdateTime = Time.time;
    }

    private void Update()
    {
        if (player != null)
        { 
            direction = player.transform.position - transform.position;

            if (Mathf.Abs(direction.x) > stoppingDistance || Mathf.Abs(direction.y) > stoppingDistance)
            {
                // Move towards the player
                transform.Translate(direction.normalized * speed * Time.deltaTime);

                // Flip the sprite based on direction
                if (direction.x > 0)
                {
                    transform.localScale = new Vector3(initialScale.x, initialScale.y, initialScale.z);
                }
                else
                {
                    transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
                }
            }
        }

        DestoyIfNotVisible();
    }

    private void DestoyIfNotVisible()
    {
        if (IsVisible())
        {
            lastUpdateTime = Time.time;
        }
        else if (Time.time - lastUpdateTime > destroyIfNotVisibleDelay)
        {
            Destroy(gameObject);
        }
    }

    private bool IsVisible()
    {
        Vector3 viewportPoint = Camera.main.WorldToViewportPoint(transform.position);
        return (viewportPoint.x >= 0 && viewportPoint.x <= 1 && viewportPoint.y >= 0 && viewportPoint.y <= 1);
    }
}
