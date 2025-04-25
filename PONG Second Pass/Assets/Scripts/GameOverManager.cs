using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject playerWon;
    public GameObject enemyWon;
    void Start()
    {
        playerWon.SetActive(GameManager.didPlayerWin);
        enemyWon.SetActive(!GameManager.didPlayerWin);
    }
}
