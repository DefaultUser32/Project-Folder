using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float maxYPosition;
    public float minYPosition;
    public float enemySpeed;
    public float maxTrackingDistance;
    
    void Update()
    {
        Vector2 nextPosition = transform.position;
        Vector2 ballPosition = GetClosestBall();

        if (Mathf.Abs(transform.position.x - ballPosition.x) > maxTrackingDistance)
        {
            return;
        }

        if (ballPosition.y > nextPosition.y)
        {
            nextPosition.y += enemySpeed * Time.deltaTime;
        }
        else
        {
            nextPosition.y -= enemySpeed * Time.deltaTime;
        }

        nextPosition.y = Mathf.Clamp(nextPosition.y, minYPosition, maxYPosition);
        transform.position = nextPosition;
    }

    public Vector2 GetClosestBall()
    {
        BallMove[] targets = FindObjectsByType<BallMove>(FindObjectsSortMode.None);

        if (targets.Length == 0 )
        {
            return new Vector2 (0, 0);
        }

        Vector2 closestBallPosition = targets[0].transform.position;

        foreach (BallMove nextBall in targets) {
            float lastClosestDistance = Vector2.Distance(transform.position, closestBallPosition);
            float nextBallDistance = Vector2.Distance(transform.position, nextBall.transform.position);
            if (nextBallDistance < lastClosestDistance)
            {
                closestBallPosition = nextBall.transform.position;
            }
        }
        return closestBallPosition;
    }





    /*
    public bool isGoingUp;
    void Update()
    {
        Vector2 nextPosition = transform.position;
        if (isGoingUp)
        {
            nextPosition.y += enemySpeed * Time.deltaTime;
        }
        else
        {
            nextPosition.y -= enemySpeed * Time.deltaTime;
        }

        transform.position = nextPosition;


        if (isGoingUp && nextPosition.y > maxYPosition)
        {
            isGoingUp = false;
        }

        if (!isGoingUp && nextPosition.y < minYPosition)
        {
            isGoingUp = true;
        }
    }
    */
}
