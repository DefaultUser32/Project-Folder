using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float enemySpeed;
    public float maxYPosition;
    public float minYPosition;

    public float enemySpeedMultiplier;
    public float maxTrackingDistance;
    public GameObject ball;
    public GameManager gameManager;

    private void Update()
    {
        Vector2 closestBall = GetClosestBall();
        if (transform.position.x - closestBall.x > maxTrackingDistance)
        {
            return;
        }
        float multiplier = 1 + (gameManager.playerScore * enemySpeedMultiplier);
        Vector2 nextPosition = transform.position;
        if (closestBall.y > nextPosition.y )
        {
            nextPosition.y += enemySpeed * Time.deltaTime * multiplier;
        } else
        {
            nextPosition.y -= enemySpeed * Time.deltaTime * multiplier;
        }
        nextPosition.y = Mathf.Clamp(nextPosition.y, minYPosition, maxYPosition);
        transform.position = nextPosition;
    }
    private Vector2 GetClosestBall()
    {
        BallMove[] balls = FindObjectsByType<BallMove>(FindObjectsSortMode.None);
        Vector2 closestBallPosition = balls[0].transform.position;

        foreach (BallMove ball in balls)
        {
            float currentClosestDistance = Vector2.Distance(transform.position, closestBallPosition);
            float nextClosestDistance = Vector2.Distance(transform.position, ball.transform.position);
            if (nextClosestDistance < currentClosestDistance)
            {
                closestBallPosition = ball.transform.position;
            }
        }
        return closestBallPosition;
    }
    /*  NO TARGETING
    bool isGoingUp;
    void Update()
    {
        Vector2 nextPosition = transform.position;
        if (isGoingUp) {
            nextPosition.y += enemySpeed * Time.deltaTime;
        } else {
            nextPosition.y -= enemySpeed * Time.deltaTime;
        }

        if (isGoingUp && nextPosition.y > maxYPosition)
        {
            isGoingUp = false;
        }

        if (!isGoingUp && nextPosition.y < minYPosition)
        {
            isGoingUp = true;
        }

        transform.position = nextPosition;
    }
    */
}
