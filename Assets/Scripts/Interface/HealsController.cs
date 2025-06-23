using UnityEngine;
using UnityEngine.UI;

public class HealsController : MonoBehaviour
{
    #region PrivateVaribles
    [SerializeField]
    private Image[] heart = new Image[3];
    #endregion

    #region PublicMetods
    public void SetHearts(int countHeart)
    {
        countHeart = Mathf.Clamp(countHeart, 0, heart.Length);
        for (int i = 0; i < heart.Length; i++)
        {
            if (i < countHeart)
            {
                heart[i].gameObject.SetActive(true);
            }
            else
            {
                heart[i].gameObject.SetActive(false);
            }
        }
    }
    #endregion
}


