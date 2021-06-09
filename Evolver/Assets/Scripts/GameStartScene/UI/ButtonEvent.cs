using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ButtonEvent : MonoBehaviour
{
    Color EnterColor;
    Color OriginaColor;

    public void Awake()
    {
        EnterColor.r = 255; EnterColor.g = 0;   EnterColor.b = 0;   EnterColor.a = 1f;
        OriginaColor.r = 255;   OriginaColor.g = 255;   OriginaColor.b = 255;   OriginaColor.a = 1f;
    }
    public void OnMouseEnter()
    {
        this.transform.GetChild(0).GetComponent<Text>().color = EnterColor;
    }

    public void OnMouseExit()
    {
        this.transform.GetChild(0).GetComponent<Text>().color = OriginaColor;
    }
}
