using UnityEngine;
using UnityEngine.UI;
public class ButtonManager : MonoBehaviour
{
    public static ButtonManager Instance { get; private set; }
    [SerializeField] private Button playButton;

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

        if(playButton == null)
        {
            playButton = GetComponent<Button>();
        }
        playButton.onClick.AddListener(OnPlayClick);
    }

    public void OnPlayClick()
    {
        AudioManager.Instance.PlayButtonClickSound();
        SceneLoader.Instance.LoadScene("GameScene");
    }            
}
