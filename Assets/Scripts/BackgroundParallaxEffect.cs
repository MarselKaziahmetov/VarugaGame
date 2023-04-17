using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallaxEffect : MonoBehaviour
{
    [Range(1, 12)][SerializeField] private int parallaxSpeed;
    
    private const float speed = 0.3f;

    private RectTransform parallaxTransform;
    private Vector3 parallaxPosition;
    void Start()
    {
        parallaxTransform = GetComponent<RectTransform>();
        parallaxPosition = new Vector3(parallaxTransform.position.x, parallaxTransform.position.y, 0);
    }

    void FixedUpdate()
    {
        parallaxPosition = new Vector3(parallaxTransform.position.x - parallaxSpeed, parallaxTransform.position.y, 0);

        parallaxTransform.position = Vector3.Lerp(parallaxTransform.position, parallaxPosition, speed); 
    }
}
