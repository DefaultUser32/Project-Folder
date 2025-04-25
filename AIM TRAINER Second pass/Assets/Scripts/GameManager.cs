using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static float lastTime;
    public static Dictionary<int, float> highScores = new Dictionary<int, float>();

    public static int numberOfTargets = 10;
    int targetsDestroyed = 0;

    public Vector2 topRightPosition;
    public Vector2 bottomLeftPosition;
    public GameObject targetPrefab;

    public TMP_Text timerText;
    public TMP_Text targetsText;

    void Start()
    {
        targetsText.text = targetsDestroyed + "/" + numberOfTargets;
        for (int i = 0; i < numberOfTargets; i++)
        {
            Vector2 spawnPosition = new Vector2(0, 0);
            spawnPosition.x = Random.Range(bottomLeftPosition.x, topRightPosition.x);
            spawnPosition.y = Random.Range(bottomLeftPosition.y, topRightPosition.y);

            GameObject newTarget = Instantiate(targetPrefab);
            newTarget.transform.position = spawnPosition;
        }
    }
    private void Update()
    {
        timerText.text = Time.timeSinceLevelLoad.ToString("F2");
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null)
            {

                Animator targetAnimator = hit.collider.GetComponent<Animator>();
                targetAnimator.SetTrigger("Popping");

                targetsDestroyed++;

                targetsText.text = targetsDestroyed + "/" + numberOfTargets;

                if (targetsDestroyed == numberOfTargets)
                {
                    lastTime = Time.timeSinceLevelLoad;
                    SetHighScore();
                    SceneManager.LoadScene("GameOverScene");
                }
            }
        }

    }
    public void SetHighScore()
    {
        if (!highScores.TryAdd(numberOfTargets, lastTime))
        {
            if (highScores[numberOfTargets] > lastTime)
            {
                highScores[numberOfTargets] = lastTime;
            }
        }
    }
}
