using UnityEngine;
using UnityEngine.UI;
public class PlayButton : MonoBehaviour
{
    [SerializeField] private Button playButton;
    private void Awake()
    {
        if (playButton == null)
        {
            playButton = GetComponent<Button>();
        }
        playButton.onClick.AddListener(OnPlayButtonClicked);
    }

    public void OnPlayButtonClicked()
    {
        AudioManager.Instance.PlayButtonClickSound();
        UIManager.Instance.GameModePanel.SetActive(true);
    }
}
