using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawnerRotation : MonoBehaviour
{
    private float angle;

    void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;
    }    
}