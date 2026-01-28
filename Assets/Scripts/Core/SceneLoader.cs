using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance { get; private set; }
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            SceneManager.sceneLoaded += OnSceneLoadedComplete;// SceneManager.sceneLoaded is an event that is triggered when loading a scene is complete
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OnSceneLoadedComplete(Scene scene, LoadSceneMode mode)
    {
        GameEvent.TriggerChangeScene();
    }    

    public string CurrentScence()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        return currentScene.name;
    }
}
