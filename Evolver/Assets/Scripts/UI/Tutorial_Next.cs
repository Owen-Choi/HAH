using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Tutorial_Next : MonoBehaviour
{
    Color Oncolor;  Color ExitColor;
    public GameObject NextPage;
    void Start()
    {
        Oncolor.r = 255; ExitColor.r = 255;
        Oncolor.g = 255; ExitColor.g = 255;
        Oncolor.b = 255; ExitColor.b = 255;
        Oncolor.a = 1f; ExitColor.a = 0.4f;
    }

    public void OnMouseEnter()
    {
        this.gameObject.GetComponent<Image>().color = Oncolor;
    }

    public void OnMouseExit()
    {
        this.gameObject.GetComponent<Image>().color = ExitColor;
    }

    public void OnClick()
    {

        NextPage.gameObject.SetActive(true);
        Destroy(this.transform.parent.transform.parent.gameObject);

    }
}
