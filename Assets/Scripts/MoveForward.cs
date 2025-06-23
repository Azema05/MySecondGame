using UnityEngine;

public class MoveForward : MonoBehaviour
{
    #region PrivateVaribles
    [SerializeField]
    private float speed = 5.0f;
    #endregion
    
    #region PublicMetods
    public void SetSpeed(float speedVar = 5)
    {
        speed = speedVar;
    }
    #endregion

    #region UnityCallback
    
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
    #endregion
}
