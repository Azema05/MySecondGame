using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    #region PrivateVaribles
    [SerializeField]
    private TMP_Text scoreNum;
    #endregion

    #region UnityCallBack
    void Awake()
    {
        scoreNum.text = "0";
    }
    #endregion

    #region PublicMetods
    public void SetScore(int score)
    {
        scoreNum.text = score.ToString();
    }
    #endregion
}
