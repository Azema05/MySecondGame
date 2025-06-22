using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    #region PrivateVaribles
    private float topBounds = 30;
    private float lowerBounds = -15;
    private float leftBounds = -30;
    private float rightBounds = 30;
    #endregion

    #region UnityCallback
    void Update()
    {
        if (transform.position.z > topBounds || transform.position.z < lowerBounds || transform.position.x < leftBounds || transform.position.x > rightBounds )
        {
            Destroy(gameObject);
        }
      
    }
    #endregion
}
