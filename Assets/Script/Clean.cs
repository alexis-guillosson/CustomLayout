using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class Clean : MonoBehaviour
{  
    
    Queue m_Queue = new Queue();
    public CustomLayout m_customLayout;
    public RectTransform ContentRectTransform;
    public LayoutGroup LayoutGroup;


    //si childcount = 0 -> possède des enfants
    //déplace le content
    //destroy this (le gameObject actuel)
    public void clean()
    {
        if (transform.parent.childCount != 0 && transform.parent != null)
        {
            CustomLayout parentLayout = transform.parent.parent.GetComponent<CustomLayout>();
            ContentRectTransform.transform.SetParent(parentLayout.transform.GetChild(0));
            DestroyImmediate(m_customLayout.transform);
            
        }  
    }

    public void delete()
    {
        DestroyImmediate(m_customLayout);
    }
}

