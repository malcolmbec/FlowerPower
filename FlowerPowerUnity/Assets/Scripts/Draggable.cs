using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IDragHandler
{

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    private bool overlap(RectTransform rect1, RectTransform rect2)
    {
        Rect r1 = new Rect(rect1.localPosition.x, rect1.localPosition.y, rect1.rect.width, rect1.rect.height);
        Rect r2 = new Rect(rect2.localPosition.x, rect2.localPosition.y, rect2.rect.width, rect2.rect.height);

        return r1.Overlaps(r2);
    }


}
