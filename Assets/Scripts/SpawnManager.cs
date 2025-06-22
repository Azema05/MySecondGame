using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    #region PrivateVaribles
    [SerializeField]
    private GameObject[] animalPrefabs;
    [SerializeField]
    private Vector2 spawnRangeX = Vector2.zero;
    [SerializeField]
    private Vector2 spawnRangeY = Vector2.zero;
    [SerializeField]
    private Vector2 spawnRangeZ = Vector2.zero;
    [SerializeField]
    private float startDelay = 2;
    [SerializeField]
    private float spawnInterval = 1.5f;
    #endregion

    #region UnityCallback
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    #endregion

    #region PrivateMetods
    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(spawnRangeX.x, spawnRangeX.y),
         Random.Range(spawnRangeY.x, spawnRangeY.y),
         Random.Range(spawnRangeZ.x, spawnRangeZ.y));

        GameObject GO = Instantiate(animalPrefabs[animalIndex]);
        GO.transform.SetParent(transform);
        GO.transform.localEulerAngles = new Vector3(0,180,0);
        GO.transform.localPosition = spawnPos;
    }
    #endregion


    //На заметку - что то типо асинхронной функ

    // IEnumerator corutine()
    // {
    //     yield return new WaitForSeconds(startDelay);
    //     while (true)
    //     {
    //         SpawnRandomAnimal();
    //         yield return new WaitForSeconds(spawnInterval);
    //         Debug.Log("END Wave");
    //     }
    // }
}
