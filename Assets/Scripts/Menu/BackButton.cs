using UnityEngine;
using UnityEngine.UI;
public class BackButton : MonoBehaviour
{
    [SerializeField] private Button backButton;
    private void Awake()
    {
        if (backButton == null)
        {
            backButton = GetComponent<Button>();
        }
        backButton.onClick.AddListener(OnBackButtonClicked);
    }

    public void OnBackButtonClicked()
    {
        AudioManager.Instance.PlayButtonClickSound();
        UIManager.Instance.MenuPanel.SetActive(true);
        UIManager.Instance.SettingsPanel.SetActive(false);
    }
}
