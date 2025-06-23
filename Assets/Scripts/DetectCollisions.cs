using System;
using System.Collections;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private bool canTriggerEnter = true;
    private AudioClip clipHit;
    public AudioClip ClipHit
    {
        get { return clipHit; }
        set { clipHit = value; }
    }
    private AudioSource audioSource;
    [SerializeField]
    private KindDetect _kindDetect = KindDetect.TriggerAnimal;
    public KindDetect KindDetectTrigger
    {
        get { return _kindDetect; }
        set { _kindDetect = value; }
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    #region PrivateMetods
    private void OnTriggerEnter(Collider other)
    {
        if (!canTriggerEnter) { return; }
        switch (KindDetectTrigger)
        {
            case KindDetect.TriggerAnimal:

                if (other.CompareTag("Animal"))
                {
                    other.GetComponent<AnimalController>().Hit();
                    audioSource.PlayOneShot(clipHit, audioSource.volume);
                    StartCoroutine(WaitSoundEnd());
                    canTriggerEnter = false;
                }
                break;
            case KindDetect.TriggerPlayer:

                if (other.CompareTag("Player"))
                {
                    PlayerController.Instanse.Damage(1);
                    Destroy(gameObject);
                    //StartCoroutine(WaitSoundEnd());
                    canTriggerEnter = false;
                }
                break;
        }

    }

    IEnumerator WaitSoundEnd()
    {
        transform.localScale = Vector3.zero;
        yield return new WaitForSeconds(clipHit.length + 0.5f);
        Destroy(gameObject);
    }
    #endregion

    public enum KindDetect
    {
        TriggerAnimal = 0,
        TriggerPlayer = 1,
    }
}
