using System.Collections;
using UnityEngine;

public class MoveScale : MonoBehaviour
{
     [SerializeField, Range(0, 8)]
    private float timeUp = 3;
    [SerializeField]
    private AnimationCurve animationCurve;
    [SerializeField]
    private Vector3 offSet;
    private Vector3 original;
    private Vector3 endScale;
    private Coroutine changeScaleIE;

       void Awake()
    {
        original = transform.localScale;
        endScale = original + offSet;
    }
    IEnumerator ChangeScaleIE()
    {
        while (true)
        {
            yield return null;

            float time = 0;
            while (time < timeUp)
            {
                time += Time.deltaTime;
                transform.localScale = Vector3.Lerp(original, endScale, animationCurve.Evaluate(time / timeUp));
                yield return null;
            }
            transform.localScale = endScale;

            time = 0;
            while (time < timeUp)
            {
                time += Time.deltaTime;
                transform.localScale = Vector3.Lerp(endScale, original, animationCurve.Evaluate(time / timeUp));
                yield return null;
            }
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Start()
    {
        changeScaleIE = StartCoroutine(ChangeScaleIE());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
