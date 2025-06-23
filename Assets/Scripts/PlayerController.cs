using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using static DetectCollisions;

public class PlayerController : MonoBehaviour
{
    #region PublicVaribles
    public static PlayerController Instanse;
    #endregion

    #region PrivateVaribles
    [SerializeField]
    private AudioClip clipHit;

    [Space]
    [SerializeField]
    private ScoreController scoreController;
    [SerializeField]
    private HealsController healsController;
    [SerializeField]
    private GameObject projectilePrefab;

    [Space]
    [SerializeField] private UnityEvent endGameEvent = new UnityEvent();
    [SerializeField] private string namePrefs = "BestScore";
    private bool endGame = false;

    private float horizontalInput;
    private float verticalInput;
    private float speed = 20.0f;
    private float xRange = 16.0f;
    private float zTop = 16.0f;
    private float zBottom = -2.0f;
    private int lifeCount = 3;
    private int score = 0;
    private int bestScore = 0;
    [SerializeField]
    private List<MainMenuController> mainMenus = new();
    private const int LIFE_COUNT_MAX = 3;
    #endregion


    #region PrivateMetods
    
    void LimitWall()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        //
        if (transform.position.z > zTop)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zTop);
        }
        if (transform.position.z < zBottom)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBottom);
        }
    }

    private void CheckBestScore(int score, ref int bestScore, string namePrefs)
    {
        if (bestScore >= score)
        {
            return;
        }

        PlayerPrefs.SetInt(namePrefs, score);
        bestScore = score;
    }

    void SetMenuPrefs()
    {
        foreach (var menuList in mainMenus)
        {
            menuList.SetPrefsName(namePrefs);
        }
    }
    #endregion


    #region UnityCallback
        void Awake()
    {
        if (Instanse != null)
        {
            Destroy(gameObject);
            return;
        }

        Instanse = this;
        bestScore = PlayerPrefs.GetInt(namePrefs, 0);
        Debug.Log(bestScore);
    }

    void Update()
    {
        LimitWall();

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject food = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);

            DestroyOutOfBounds destroyOutOfBounds = food.AddComponent<DestroyOutOfBounds>();
            DetectCollisions detectCollisions = food.AddComponent<DetectCollisions>();
            detectCollisions.KindDetectTrigger = KindDetect.TriggerAnimal;
            detectCollisions.ClipHit = clipHit;
            MoveForward moveForward = food.AddComponent<MoveForward>();
            moveForward.SetSpeed(20);
        }

    }
    #endregion


    #region PublicMetods
    public void Damage(int value)
    {
        if (lifeCount + value <= 0)
        {
            if (!endGame)
            {
                endGame = true;
                healsController.SetHearts(0);
                endGameEvent?.Invoke();
            }

            return;
        }

        lifeCount = Mathf.Clamp(lifeCount + value, 0, LIFE_COUNT_MAX);
        healsController.SetHearts(lifeCount);
        Debug.Log($"Life count now: {lifeCount}");
    }


    public void Hit(int value)
    {
        if (value < 0)
        {
            Debug.Log("Value in hit < 0!");
            return;
        }

        score += value;
        Debug.Log($"Score now: {score}");
        scoreController.SetScore(score);
        CheckBestScore(score, ref bestScore, namePrefs);
    }
    #endregion
}
