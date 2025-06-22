using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    #region PrivateMetods
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {
            other.GetComponent<AnimalController>().Hit();
            Destroy(gameObject);
        }
    }
    #endregion
}
