using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 7f;

    public float leftLimit = -7f;
    public float rightLimit = 7f;

    void Update()
    {
        float horizontalInput = 0f;

        if (Keyboard.current.leftArrowKey.isPressed ||
            Keyboard.current.aKey.isPressed)
        {
            horizontalInput = -1f;
        }

        if (Keyboard.current.rightArrowKey.isPressed ||
            Keyboard.current.dKey.isPressed)
        {
            horizontalInput = 1f;
        }

        Vector3 movement = new Vector3(horizontalInput, 0f, 0f);

        transform.position += movement * moveSpeed * Time.deltaTime;

        float clampedX = Mathf.Clamp(
            transform.position.x,
            leftLimit,
            rightLimit
        );

        transform.position = new Vector3(
            clampedX,
            transform.position.y,
            transform.position.z
        );
    }
}