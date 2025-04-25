using TMPro;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    public float ballSpeed;
    public GameManager gameManager;
    Rigidbody2D ballRigidbody;
    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody2D>();
        ResetPosition();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetPosition()
    {
        transform.position = Vector2.zero;
        ballRigidbody.linearVelocity = Vector2.zero;

        bool isGoingRight = Random.Range(0, 2) == 0;
        bool isGoingUp = Random.Range(0, 2) == 0;

        if (isGoingRight)
        {
            ballRigidbody.AddForce(Vector2.right * ballSpeed, 0);
        } else
        {
            ballRigidbody.AddForce(Vector2.left * ballSpeed, 0);
        }

        if (isGoingUp)
        {
            ballRigidbody.AddForce(Vector2.up * ballSpeed, 0);
        } else
        {
            ballRigidbody.AddForce(Vector2.down * ballSpeed, 0);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerScore"))
        {
            gameManager.enemyScore++;
        } else if (collision.CompareTag("EnemyScore"))
        {
            gameManager.playerScore++;
        }
        gameManager.UpdateText();
        ResetPosition();
    }
}
