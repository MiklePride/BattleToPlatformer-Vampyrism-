using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] protected Slider UIBar;
    [SerializeField, Min(0.01f)] protected float DurationDrow = 0.1f;

    protected Coroutine DrawCoroutine;

    protected virtual IEnumerator Draw(float targetValue)
    {
        while (UIBar.value != targetValue)
        {
            UIBar.value = Mathf.MoveTowards(UIBar.value, targetValue, DurationDrow * Time.deltaTime);

            yield return null;
        }
    }

    protected virtual void OnChenge(float value, float maxValue)
    {
        float valueAsPercentage = Mathf.Clamp01(value / maxValue);

        if (DrawCoroutine != null)
            StopCoroutine(DrawCoroutine);

        DrawCoroutine = StartCoroutine(Draw(valueAsPercentage));
    }
}
