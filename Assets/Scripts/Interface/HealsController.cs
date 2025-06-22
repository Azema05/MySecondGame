using UnityEngine;
using UnityEngine.UI;

public class HealsController : MonoBehaviour
{
    #region PrivateVaribles
    [SerializeField]
    private Image[] heart = new Image[3];
    private int heartCountNow = 3;
    #endregion

    #region UnityCallBack
    void Awake()
    {
        heartCountNow = heart.Length;
    }
    #endregion

    #region PublicMetods
    public void Damage()
    {
        if (heartCountNow - 1 < 0)
        {
            return;
        }
        heartCountNow--;
        heart[heartCountNow].gameObject.SetActive(false);
    }
    #endregion
}
