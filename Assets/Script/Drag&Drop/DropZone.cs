using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        // Debug.Log("OnDrop" + gameObject.name);
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            d.parentToReturnTo = this.transform;
        }
    }
      

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("OnPointerEnter");
        if (eventData.pointerDrag == null)
        {
            return;
        }

            Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
            if (d != null)
            {
                d.placeHolderParent = this.transform;
            }
        
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnPointerExit");
        if (eventData.pointerDrag == null)
        {
            return;
        }
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null && d.placeHolderParent==this.transform)
        {
            d.placeHolderParent = d.parentToReturnTo;
        }
    }
}
