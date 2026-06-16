using UnityEngine;
using UnityEngine.UI;
public class HomeButton : MonoBehaviour
{
    [SerializeField] private Button homeButton;
    private void Awake()
    {
        if(homeButton == null)
        {
            homeButton = GetComponent<Button>();
        }
        homeButton.onClick.AddListener(OnClicked);
    }
    
    private void OnClicked()
    {
        AudioManager.Instance.PlayButtonClickSound();
        Time.timeScale = 1f;
        SceneLoader.Instance.LoadScene("MenuScene");
    }
}
