using UnityEngine;
using UnityEngine.UI;
public class DifficultyButton : MonoBehaviour
{
    [SerializeField] private Button difficultButton;

    [SerializeField] private int min;
    [SerializeField] private int max;
    private void Awake()
    {
        if (difficultButton == null)
        {
            difficultButton = GetComponent<Button>();
        }

        difficultButton.onClick.AddListener(OnSetDifficultyClicked);
    }

    private void OnSetDifficultyClicked()
    {
        GameModeManager.Instance.SetDifficulty(min, max);
        AudioManager.Instance.PlayButtonClickSound();
        UIManager.Instance.AddPanel.SetActive(false);

        SceneLoader.Instance.LoadScene("GameScene");
    }
}
