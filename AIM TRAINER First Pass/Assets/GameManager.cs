using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static float[] highScores = new float[15];
    public static float lastScore;
    public static int numberOfTargets;

    [Header("Target Information")]
    public Vector2 bottomLeft;
    public Vector2 topRight;
    public GameObject target;


    [Header("UI Information")]
    public TMP_Text timerText;
    public TMP_Text targetText;

    private int numberDestroyed = 0;
    private float startTime;
    private bool triggeredEnd = false;
    void Start()
    {
        startTime = Time.timeSinceLevelLoad;
        for (int i = 0; i < numberOfTargets; i++)
        {
            Vector2 spawnPosition = new Vector2();
            spawnPosition.x = UnityEngine.Random.Range(bottomLeft.x, topRight.x);
            spawnPosition.y = UnityEngine.Random.Range(bottomLeft.y, topRight.y);
            Instantiate(target, spawnPosition, target.transform.rotation);
        }
    }

    void Update()
    {
        if (triggeredEnd) { return; }
        float timeSinceStart = Time.timeSinceLevelLoad - startTime;

        timeSinceStart = Mathf.Round(timeSinceStart * 100);

        timerText.text = (timeSinceStart/100f).ToString();
        targetText.text = numberDestroyed + "/" + numberOfTargets;

        if (numberDestroyed == numberOfTargets)
        {
            lastScore = timeSinceStart/100f;
            FindObjectsByType<LevelLoader>(FindObjectsSortMode.None)[0].LoadScene("GameOver");
            triggeredEnd = true;
        }

        if (Input.GetMouseButtonDown(0)) {

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            Debug.DrawRay(mousePos, Vector2.zero, Color.yellow, 100f);

            if (hit.collider != null && hit.collider.gameObject.CompareTag("Target")) {
                hit.collider.gameObject.GetComponent<Animator>().SetTrigger("Destroy");
                numberDestroyed++;
            }

        }

    }
}
