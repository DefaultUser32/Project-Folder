using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    string nextScene;
    Animator anim;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (FindObjectsByType<LevelLoader>(FindObjectsSortMode.None).Length != 1)
        {
            Destroy(gameObject);
        }

        anim = GetComponent<Animator>();
    }

    public void LoadScene(string levelName)
    {
        nextScene = levelName;
        anim.SetTrigger("LoadScene");
    }

    public void TriggerLoad()
    {
        SceneManager.LoadScene(nextScene);

    }
}
