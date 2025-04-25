using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float maxYPosition;
    public float minYPosition;

    public float playerSpeed;

    public string axisName;
    void Update()
    {
        Vector2 newPosition = transform.position;
        newPosition.y += Input.GetAxis(axisName) * playerSpeed * Time.deltaTime;
        newPosition.y = Mathf.Clamp(newPosition.y, minYPosition, maxYPosition);
        transform.position = newPosition;
    }
}
