using UnityEngine;
public class ButtonManager : MonoBehaviour
{
    public static ButtonManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        Debug.Log(Screen.orientation);
    }

    public void PlayButtonClick()
    {
        SceneLoader.Instance.LoadScene("GameScene");
    }
}
