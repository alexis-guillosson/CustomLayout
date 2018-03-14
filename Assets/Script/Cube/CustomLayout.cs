using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CustomLayout : MonoBehaviour
{
    #region Properties
    public int Padding;
    GameObject m_Prefab;
    GameObject m_Button;
    public LayoutGroup LayoutGroup;
    public RectTransform ContentRectTransform;
    public RectTransform DropZoneRectTransform;
    public CustomLayout m_customLayout;
    public enum Layout { Vertical, Horizontal}
    public enum Side { Left, Right, Top, Bottom}
    
    #endregion

    #region Public Methods
    public void Set(Layout layout)
    {
        GameObject layoutGroupGameObject = LayoutGroup.gameObject;
        switch (layout)
        {
            case Layout.Vertical:
                if(LayoutGroup is HorizontalLayoutGroup)
                {
                    DestroyImmediate(LayoutGroup);
                    LayoutGroup = layoutGroupGameObject.AddComponent<VerticalLayoutGroup>();
                }
                LayoutGroup.padding = new RectOffset(Padding, Padding, 0, 0);
                ContentRectTransform.sizeDelta = new Vector2(ContentRectTransform.sizeDelta.x, 2 * Padding);
                break;
            case Layout.Horizontal:
                if (LayoutGroup is VerticalLayoutGroup)
                {
                    DestroyImmediate(LayoutGroup);
                    LayoutGroup = layoutGroupGameObject.AddComponent<HorizontalLayoutGroup>();
                }
                LayoutGroup.padding = new RectOffset(0, 0, Padding, Padding);
                ContentRectTransform.sizeDelta = new Vector2(2 * Padding, ContentRectTransform.sizeDelta.y);
                break;
        }
    }
    public void AddLayout(CustomLayout layout, int index)
    {
        layout.transform.SetParent(LayoutGroup.transform);
        layout.transform.SetSiblingIndex(index);
        foreach (Transform child in LayoutGroup.transform)
        {
            child.GetComponent<CustomLayout>().SetPaddingBySibling();
        }
    }
    public void SetPaddingBySibling()
    {
        int index = transform.GetSiblingIndex();
        if(index == 0)
        {
            if(LayoutGroup is HorizontalLayoutGroup)
            {
                ContentRectTransform.sizeDelta = new Vector2(ContentRectTransform.sizeDelta.x, Padding);
                ContentRectTransform.anchoredPosition = new Vector2(0, Padding / 2);
            }
            else
            {
                ContentRectTransform.sizeDelta = new Vector2(Padding, ContentRectTransform.sizeDelta.y);
                ContentRectTransform.anchoredPosition = new Vector2(Padding / 2, 0);
            }
        }
        else if(index == transform.parent.childCount - 1)
        {
            if (LayoutGroup is HorizontalLayoutGroup)
            {
                ContentRectTransform.sizeDelta = new Vector2(ContentRectTransform.sizeDelta.x, Padding);
                ContentRectTransform.anchoredPosition = new Vector2(0, - Padding / 2);
            }
            else
            {
                ContentRectTransform.sizeDelta = new Vector2(Padding, ContentRectTransform.sizeDelta.y);
                ContentRectTransform.anchoredPosition = new Vector2(- Padding / 2, 0);
            }
        }
        else
        {
            if (LayoutGroup is HorizontalLayoutGroup)
            {
                ContentRectTransform.sizeDelta = new Vector2(ContentRectTransform.sizeDelta.x, 0);
            }
            else
            {
                ContentRectTransform.sizeDelta = new Vector2(0,ContentRectTransform.sizeDelta.y);
            }
        }
    }
    public void Add(int index,  RectTransform content)
    {
        CustomLayout customLayout = Instantiate(m_Prefab, LayoutGroup.transform).GetComponent<CustomLayout>();
        customLayout.transform.SetSiblingIndex(index);
        if (LayoutGroup is HorizontalLayoutGroup) customLayout.Set(Layout.Vertical);
        else customLayout.Set(Layout.Horizontal);
        content.SetParent(customLayout.ContentRectTransform);
        DropZoneRectTransform.SetAsLastSibling();
    }
    public void Add(Side side, RectTransform content, CustomLayout caller = null)
    {
        if ((LayoutGroup is HorizontalLayoutGroup && (side == Side.Top || side == Side.Bottom)) || (LayoutGroup is VerticalLayoutGroup && (side == Side.Left || side == Side.Right)))
        {
            CustomLayout parentLayout = CheckParent();
            parentLayout.AddLayout(this, transform.GetSiblingIndex());
            int index;
            if (side == Side.Left || side == Side.Top)
            {
                index = transform.GetSiblingIndex();
            }
            else
            {
                index = transform.GetSiblingIndex() + 1;
            }
            parentLayout.Add(index, content);
        }
        else
        {
            if (ContentRectTransform.childCount > 0) // Content CustomLayout.
            {
                int index1, index2;
                if(side == Side.Left || side == Side.Top)
                {
                    index1 = 1;
                    index2 = 0;
                }
                else
                {
                    index1 = 0;
                    index2 = 1;
                }
                Add(index1, ContentRectTransform.GetChild(0).GetComponent<RectTransform>());
                Add(index2, content);
            }
            else // Intermediate CustomLayout.
            {
                int index = caller.transform.GetSiblingIndex();
                if (side == Side.Left || side == Side.Top)
                {
                }
                else
                {
                    index++;
                }
                Add(index, content);
            }
        }      
    }
    public bool HasContent()
    {
        if (ContentRectTransform.childCount == 0) return true;
        else return false;

    }

    #endregion

    #region Private Methods
    private void Awake()
    {
        m_Prefab  = Resources.Load("CustomLayout 1") as GameObject;
       
    }
    private CustomLayout CheckParent()
    {
        CustomLayout parentLayout = transform.parent.GetComponent<CustomLayout>();
        if(parentLayout == null)
        {
            parentLayout = Instantiate(m_Prefab, transform.parent).GetComponent<CustomLayout>();
            parentLayout.transform.SetSiblingIndex(transform.GetSiblingIndex());
            if (LayoutGroup is HorizontalLayoutGroup) parentLayout.Set(Layout.Vertical);
            else parentLayout.Set(Layout.Horizontal);

            transform.SetParent(parentLayout.LayoutGroup.transform);
        }
        return parentLayout;
    }
    #endregion


}
