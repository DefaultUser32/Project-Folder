using UnityEngine;

public class BallMove : MonoBehaviour
{
    public float ballSpeed;
    Rigidbody2D ballRigidbody;
    GameManager manager;

    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody2D>();

        GameManager[] managers = FindObjectsByType<GameManager>(FindObjectsSortMode.None);

        if (managers.Length > 0)
        {
            manager = managers[0];
        }

        ResetBall();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.position = new Vector2(0, 0);
        ballRigidbody.linearVelocity = new Vector2(0, 0);

        ResetBall();

        if (manager == null)
        {
            return;
        }

        if (collision.CompareTag("PlayerWall"))
        {
            manager.enemyScore++;
        }
        else if (collision.CompareTag("EnemyWall"))
        {
            manager.playerScore++;
        }

        manager.UpdateText();
    }

    public void ResetBall()
    {
        Vector2 ballForce = new Vector2(ballSpeed, ballSpeed);

        int verticalRandom = Random.Range(0, 2);
        int horizontalRandom = Random.Range(0, 2);

        if (verticalRandom == 0)
        {
            ballForce.y = -ballForce.y;
        }
        if (horizontalRandom == 0)
        {
            ballForce.x = -ballForce.x;
        }

        ballRigidbody.AddForce(ballForce);
    }
}
