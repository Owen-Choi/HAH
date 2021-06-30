using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Iron_Woong_Button : MonoBehaviour
{
    Color OriginalColor;    Color EnterColor; 
    private void Awake()
    {
        EnterColor.r = 255; EnterColor.g = 0; EnterColor.b = 0; EnterColor.a = 1f;
        OriginalColor.r = 255; OriginalColor.g = 255; OriginalColor.b = 255; OriginalColor.a = 1f;
    }
    public void OnMouseEnter()
    {
        this.transform.GetChild(0).GetComponent<Text>().color = EnterColor;
    }
    public void OnMouseExit()
    {
        this.transform.GetChild(0).GetComponent<Text>().color = OriginalColor;
    }
}
