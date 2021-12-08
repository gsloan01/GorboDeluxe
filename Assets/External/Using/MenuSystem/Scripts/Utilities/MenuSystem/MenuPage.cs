using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPage : MonoBehaviour
{
    public GameObject backgroundPanel;

    [Serializable]
    public class UIElement
    {
        public string name;
        public GameObject element;
    }

    public List<UIElement> elements;

    public GameObject GetUIElementByName(string name)
    {
        
        foreach(UIElement element in elements)
        {
            if (element.name == name)
            {
                return element.element;
            }
        }

        List<GameObject> children = new List<GameObject>(GetComponentsInChildren<GameObject>());

        foreach (GameObject child in children)
        {
            if (child.name == name)
            {
                return child;
            }
        }

        return null;
    }
}
