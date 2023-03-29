using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    public GameObject objectToFollowing;
    public Vector3 offset;
    public float cameraSpeed;

    void FixedUpdate()
    {
        if (objectToFollowing != null)
        {
            Vector3 newCameraPosition = new Vector3(objectToFollowing.transform.position.x, objectToFollowing.transform.position.y, objectToFollowing.transform.position.z) + offset;
            transform.position = Vector3.Lerp(transform.position, newCameraPosition, cameraSpeed * Time.deltaTime);
        }
    }
}
