using UnityEngine;
using UnityEngine.UI;

public class AnimalController : MonoBehaviour
{
    #region PublicVaribles
    public Image healsBarGreen;

     public int Damage
    {
        get { return _damage; }
        private set { _damage = value; }
    }
    public int Score
    {
        get { return _score; }
        private set { _score = value; }
    }
    public int Life
    {
        get { return _life; }
        private set { _life = value; }
    }
    #endregion

    #region PrivateVaribles
    [SerializeField]
    private int _damage = 1;
    [SerializeField]
    private int _score = 3;
    [SerializeField]
    private int _life = 3;

    private int lifeDefault;
    private PlayerController playerController;
    #endregion
    
    #region PublicMetods
    public void Hit()
    {
        if (Life - 1 <= 0)
        {
            playerController.Hit(Score);
            Destroy(gameObject);
            return;
        }

        Life--;
        healsBarGreen.fillAmount = (float)Life / (float)lifeDefault;
    }
    #endregion

    // [SerializeField]
    // private int privateSer;

    // protected int _protected;
    // private int _private;
    // public int Public;


    // [SerializeField]
    // private int _score = 3;
    // public int Score
    // {
    //     get { return _score; }
    //     private set { _score = value; }
    // }



    #region  UnityCallback
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerController.Damage(-Damage);
            Destroy(gameObject);
        }
    }

    void Awake()
    {
        lifeDefault = Life;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = PlayerController.Instanse;
    }
    #endregion
}
