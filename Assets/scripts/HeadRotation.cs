using UnityEngine;

public class HeadRotation : MonoBehaviour
{
    [SerializeField]
    public Transform player; // Reference to the player transform
    public float maxRotationAngle = 5f; // Maximum rotation angle on the z-axis

    void Update()
    {
        // Get the mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the vertical distance between the mouse and the player
        float verticalDistance = mousePosition.y - player.position.y;

        // Clamp the vertical distance to the range of -1 to 1
        verticalDistance = Mathf.Clamp(verticalDistance, -1f, 1f);

        // Calculate the rotation angle based on the vertical distance
        float rotationAngle = verticalDistance * maxRotationAngle;

        // Access the facingRight variable from the PlayerMovement script
        bool facingRight = PlayerMovement.facingRight;

        // Reverse the rotation angle if facing left
        if (!facingRight)
        {
            rotationAngle = -rotationAngle;
        }

        // Apply the rotation to the head
        transform.localRotation = Quaternion.Euler(0, 0, rotationAngle);
    }
}
