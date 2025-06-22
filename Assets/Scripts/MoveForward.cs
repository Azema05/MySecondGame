using UnityEngine;

public class MoveForward : MonoBehaviour
{
    #region PrivateVaribles
    [SerializeField]
    private float speed = 5.0f;
    #endregion

    public void SetSpeed(float speedVar = 5){
        speed = speedVar;
    }

    #region UnityCallback
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
    #endregion
}
