 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_BotonHover : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    private const float MIN_SCALE_ON_HOVER = 0.7f;  
    private const float ANIMATION_DURATION = 0.3f;  
    private const float MOVE_OFFSET = 10f; 
    private Vector3 originalPosition;

    protected void OnEnable()
    {
        transform.localScale = Vector3.one;
        originalPosition = transform.position;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StartCoroutine(MoveButton(originalPosition, originalPosition + Vector3.up * MOVE_OFFSET, ANIMATION_DURATION));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StartCoroutine(MoveButton(transform.position, originalPosition, ANIMATION_DURATION));
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        LerpTo(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        LerpTo(false);
    }

    private void LerpTo(bool down)
    {
        if (down)
        {
            StartCoroutine(InterpolateSize(1, MIN_SCALE_ON_HOVER, ANIMATION_DURATION, transform));
        }
        else
        {
            StartCoroutine(InterpolateSize(MIN_SCALE_ON_HOVER, 1, ANIMATION_DURATION, transform));
        }
    }

    private IEnumerator InterpolateSize(float from, float to, float duration, Transform transf)
    {
        float time = 0;

        while (time < 1)
        {
            time += Time.deltaTime / duration;
            float scaleValue = Mathf.SmoothStep(from, to, time);
            transf.localScale = Vector3.one * scaleValue;

            yield return null;
        }

        transf.localScale = Vector3.one * to;
    }

    private IEnumerator MoveButton(Vector3 start, Vector3 end, float duration)
    {
        float time = 0;

        while (time < 1)
        {
            time += Time.deltaTime / duration;
            transform.position = Vector3.Lerp(start, end, Mathf.SmoothStep(0, 1, time));

            yield return null;
        }

        transform.position = end; 
    }
}
