using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerScore;
    public int enemyScore;
    public int goalScore;

    public TMP_Text playerScoreText;
    public TMP_Text enemyScoreText;

    public GameObject gameOverParent;
    public TMP_Text gameOverText;
    public bool isGameOver;

    [Header("Pause menu")]
    public GameObject pauseMenuParent;
    [Header("Multi-ball")]
    public GameObject ballPrefab;
    public float spawnTimer;
    Coroutine ballSpawner;
    void Start()
    {
        ResetGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!isGameOver)
            {
                pauseMenuParent.SetActive(!pauseMenuParent.activeSelf);

                if (pauseMenuParent.activeSelf)
                {
                    Time.timeScale = 0.0f;
                } else
                {
                    Time.timeScale = 1.0f;
                }
            }

        
        }

        if (playerScore >= goalScore)
        {
            Time.timeScale = 0.0f;
            gameOverParent.SetActive(true);
            gameOverText.text = "YOU WIN!";
            isGameOver = true;

        }
        if (enemyScore >= goalScore) {
            isGameOver = true;
            Time.timeScale = 0.0f;
            gameOverParent.SetActive(true);
            gameOverText.text = "YOU LOST!";
        }
    }
    public void ResetGame()
    {
        isGameOver = false;
        pauseMenuParent.SetActive(false);
        enemyScore = 0;
        playerScore = 0;
        gameOverParent.SetActive(false);
        UpdateText();
        Time.timeScale = 1.0f;

        foreach (BallMove ball in FindObjectsByType<BallMove>(FindObjectsSortMode.None))
        {
            Destroy(ball.gameObject);
        }

        if (ballSpawner != null) 
            StopCoroutine(ballSpawner);
        ballSpawner = StartCoroutine(SpawnBalls());
    }
    public void UpdateText()
    {
        playerScoreText.text = playerScore.ToString();
        enemyScoreText.text = enemyScore.ToString();
    }
    private IEnumerator SpawnBalls()
    {
        while (true)
        {
            GameObject newBall = Instantiate(ballPrefab);
            newBall.GetComponent<BallMove>().gameManager = this;
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
