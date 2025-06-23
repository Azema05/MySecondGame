using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    #region PrivateVaribles
    [SerializeField]
    private List<GameObject> panels = new();
    [SerializeField]
    private TMP_Text bestScoreNum;
    private string namePrefs = ("BestScore");

    bool canLoadScene = true;
    #endregion

    #region UnityCallback
    void Awake()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        ActivedPanels(false);
    }
    #endregion

    #region PrivatMetods
    void ActivedPanels(bool active)
    {
        foreach (var panel in panels)
        {
            panel.SetActive(active);
        }
    }

    void SetBestScore()
    {
        bestScoreNum.text = PlayerPrefs.GetInt(namePrefs, 0).ToString();
    }
    #endregion

    #region PublicMetods
    public void PauseGame(bool active)
    {
        if (active)
        {
            Time.timeScale = 0;
            SetBestScore();
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void RestrtGame()
    {
        if (!canLoadScene) return;

        canLoadScene = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Debug.Log("Game Over!");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        return;
#endif
        Application.Quit();
        return;
    }

    public void SetPrefsName(string name)
    {
        namePrefs = name;
        SetBestScore();
    }
    #endregion
}
