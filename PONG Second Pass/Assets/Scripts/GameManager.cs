using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool didPlayerWin = false;

    bool isPaused;
    public GameObject pauseMenuParent;

    public float timeBetweenSpawns;
    public GameObject ball;

    public float playerScore;
    public TMP_Text playerText;

    public float enemyScore;
    public TMP_Text enemyText;

    public int winScore;
    void Start()
    {
        isPaused = false;
        pauseMenuParent.SetActive(false);

        Time.timeScale = 1.0f;

        StartCoroutine(BallSpawner());
        UpdateText();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            pauseMenuParent.SetActive(isPaused);
            if (isPaused)
            {
                Time.timeScale = 0.0f;
            } else
            {
                Time.timeScale = 1.0f;
            }
        }

        if (playerScore >= winScore)
        {
            didPlayerWin = true;
            SceneManager.LoadScene("GameOverScene");
        }
        if (enemyScore >= winScore)
        {
            didPlayerWin = false;
            SceneManager.LoadScene("GameOverScene");
        }
    }
    public IEnumerator BallSpawner()
    {
        while (true)
        {
            Instantiate(ball);
            yield return new WaitForSeconds(timeBetweenSpawns);
        }

    }
    public void UpdateText()
    {
        playerText.text = playerScore.ToString();
        enemyText.text = enemyScore.ToString();
    }
}
