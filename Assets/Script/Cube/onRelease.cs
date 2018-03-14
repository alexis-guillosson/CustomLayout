using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class onRelease : MonoBehaviour
{

    //permet d'attribuer un side manuellement à un bouton
    //On compare ce side avec le side de la méthode add de CustomLayout
    public CustomLayout.Side Side;
    public void Show()
    {
        GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
    }
    public void Hide()
    {
        GetComponent<Image>().color = new Color(1, 1, 1, 0);
    }


    //Code transféré sur Drag2d.cs
    //private void OnMouseUp()
    //{


    //    PointerEventData pointerData = new PointerEventData(EventSystem.current);

    //    pointerData.position = Input.mousePosition;

    //    List<RaycastResult> results = new List<RaycastResult>();
    //    EventSystem.current.RaycastAll(pointerData, results);

    //    if (results.Count > 0)
    //    {
    //        foreach (RaycastResult hit in results)
    //        {
    //            Debug.Log(hit.gameObject.name);
    //            if (hit.gameObject.name.Equals(CustomLayout.Side.Top))
    //            {
    //                Debug.Log("Condition If top");
    //                cl.GetComponent<CustomLayout>();
    //                cl.Add(CustomLayout.Side.Top, myPrefab);
    //            }
    //            else if (hit.gameObject.name.Equals(CustomLayout.Side.Bottom))
    //            {

    //            }
    //            else if (hit.gameObject.name.Equals(CustomLayout.Side.Right) || (hit.gameObject.name.Equals(CustomLayout.Side.Left)))
    //            {
    //                cl.GetComponent<CustomLayout>();
    //            }
    //        }
    //    }
    //}

}
