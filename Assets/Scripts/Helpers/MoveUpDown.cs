using System.Collections;
using UnityEngine;

public class MoveUpDown : MonoBehaviour
{
    [SerializeField, Range(0, 8)]
    private float timeUp = 3;
    [SerializeField]
    private AnimationCurve animationCurve;
    [SerializeField]
    private Vector3 offSet;
    private Vector3 original;
    private Vector3 endPos;
    private Coroutine changePosIE;

    IEnumerator ChangePosIE()
    {
        while (true)
        {
            yield return null;

            float time = 0;
            while (time < timeUp)
            {
                time += Time.deltaTime;
                transform.localPosition = Vector3.Lerp(original, endPos, animationCurve.Evaluate(time / timeUp));
                yield return null;
            }
            transform.localPosition = endPos;

            time = 0;
            while (time < timeUp)
            {
                time += Time.deltaTime;
                transform.localPosition = Vector3.Lerp(endPos, original, animationCurve.Evaluate(time / timeUp));
                yield return null;
            }
        }
    }



    IEnumerator Start()
    {
        yield return null;
        original = transform.localPosition;
        endPos = original + offSet;
        changePosIE = StartCoroutine(ChangePosIE());
    }

    void OnDestroy()
    {
        if (changePosIE != null)
        {
            StopCoroutine(changePosIE);
        }

    }
}
