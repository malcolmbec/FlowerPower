using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeVase : MonoBehaviour, IPointerClickHandler
{
    public List<Sprite> vaseSprites;
    private Image img;
    private int idx = 0;

    private void Awake()
    {
        img = GetComponent<Image>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.selectedObject == gameObject)
        {
            return;
        }

        idx += 1;
        if (idx > vaseSprites.Count - 1)
        {
            idx = 0;
        }
        img.sprite = vaseSprites[idx];
    }
}
