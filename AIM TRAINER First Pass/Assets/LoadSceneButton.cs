using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        FindObjectsByType<LevelLoader>(FindObjectsSortMode.None)[0].LoadScene(sceneName);
    }
}
