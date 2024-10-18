using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float currentTime;
    [SerializeField] private float maxTime;
    private bool isHolding;

    public void OnPointerDown(PointerEventData eventData)
    {
        isHolding = true;
        StartCoroutine(Hold());
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHolding = false;
        if (currentTime >= maxTime) { GetComponent<ButtonClick>().isHolding = true; }
        currentTime = 0;
    }

    public IEnumerator Hold()
    {
        while (currentTime <= maxTime && isHolding)
        {
            currentTime += Time.deltaTime;
            yield return null;
        }
    }
}
