using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float playerSpeed;
    public float maxYPosition;
    public float minYPosition;

    public string axisName;

    void Update()
    {
        Vector2 newPosition = transform.position;
        newPosition.y += playerSpeed * Input.GetAxis(axisName) * Time.deltaTime;
        newPosition.y = Mathf.Clamp(newPosition.y, minYPosition, maxYPosition);
        transform.position = newPosition;
    }
}
