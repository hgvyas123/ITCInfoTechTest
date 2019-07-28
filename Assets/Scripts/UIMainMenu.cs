using UnityEngine.SceneManagement;
using UnityEngine;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] GameObject mPanelButtons;

    /// <summary>
    /// Should be called from editor only
    /// </summary>
    public void OnBtnMainMenuClicked()
    {
        mPanelButtons.SetActive(!mPanelButtons.activeSelf);
    }

    /// <summary>
    /// Should be called from editor only
    /// </summary>
    public void OnBtnSceneClicked(string newSceneName)
    {
        mPanelButtons.SetActive(false);
        SceneManager.LoadScene(newSceneName);
    }
}
