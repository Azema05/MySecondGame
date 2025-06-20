using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject[] animalPrefabs;
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

    Coroutine coroutine;
    void Start()
    {
        // coroutine = StartCoroutine(corutine());
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(spawnRangeX.x, spawnRangeX.y),
         Random.Range(spawnRangeY.x, spawnRangeY.y),
         Random.Range(spawnRangeZ.x, spawnRangeZ.y));
        //Vector3 spawnPos2 = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);




        GameObject GO = Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.identity, transform);
        GO.transform.localEulerAngles = Vector3.zero;
        GO.transform.localPosition = spawnPos;
    }

    //что то типо асинхронной функ

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
