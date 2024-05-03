using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ZoomImages : MonoBehaviour, IScrollHandler
{
    private Vector3 initialScale;
    private Vector3 defaultScale;

    [SerializeField]
    private float zoomSpeed = 1.0f;
    [SerializeField]
    private float maxZoom = 10f;

    private void Awake()
    {
        initialScale = transform.localScale;
        defaultScale = initialScale;
    }

    private void OnEnable()
    {
        transform.localScale = defaultScale;
    }

    public void OnScroll(PointerEventData eventData)
    {
        var delta = Vector3.one * (eventData.scrollDelta.y * zoomSpeed);
        var desiredScale = transform.localScale + delta;

        desiredScale = ClampDesiredScale(desiredScale);

        transform.localScale = desiredScale;
    }

    private Vector3 ClampDesiredScale(Vector3 desiredScale)
    {
        desiredScale = Vector3.Max(initialScale, desiredScale);
        desiredScale = Vector3.Min(initialScale * maxZoom, desiredScale);
        return desiredScale;
    }
}
