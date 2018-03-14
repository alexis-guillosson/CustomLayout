using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class Drag2D : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    #region Properties
    public Transform target;
    private bool isMouseDown = false;
    private Vector3 startMousePosition;
    private Vector3 startPosition;
    public bool shouldReturn;
    public onRelease showedOnRelease;
    #endregion

    // Use this for initialization
    void Start()
    {
        GetComponent<Image>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        if (isMouseDown)
        {
            //récupération des coordonnées actuelles de la souris
            Vector3 currentPosition = Input.mousePosition;
            
            Vector3 diff = currentPosition - startMousePosition;

            Vector3 pos = startPosition + diff;

            target.position = pos;

        }
    }

    #region MéthodePublique 

    public void OnPointerDown(PointerEventData dt)
    {
        isMouseDown = true;

        Debug.Log("Draggable Mouse Down");

        startPosition = target.position;
        startMousePosition = Input.mousePosition;
    }

    public void OnPointerUp(PointerEventData dt)
    {
        Debug.Log("Draggable mouse up");

        isMouseDown = false;
        
        if (shouldReturn)
        {
            Debug.Log("Retour à position initiale");
            target.position = startPosition;
        }
        

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(dt, results);

        if (results.Count > 0)
        {
            foreach (RaycastResult hit in results)
            {
                onRelease onR = hit.gameObject.GetComponent<onRelease>();
                if (onR != null)
                {
                    CustomLayout customLayout = onR.transform.parent.parent.GetComponent<CustomLayout>();
                    customLayout.Add(onR.Side, transform as RectTransform, customLayout);
                    if (showedOnRelease != null)
                    {
                        showedOnRelease.Hide();
                        showedOnRelease = null;
                    }
                    break;
                }
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        if (results.Count > 0)
        {
            foreach (RaycastResult hit in results)
            {
                onRelease onR = hit.gameObject.GetComponent<onRelease>();
                if (onR != null)
                {
                    if(onR != showedOnRelease)
                    {
                        onR.Show();
                        showedOnRelease = onR;
                    }
                    break;
                }
                else
                {
                    if(showedOnRelease != null)
                    {
                        showedOnRelease.Hide();
                        showedOnRelease = null;
                    }
                }
            }
        }
    }
    #endregion


}