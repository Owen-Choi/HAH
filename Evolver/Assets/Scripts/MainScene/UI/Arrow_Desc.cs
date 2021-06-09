using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Arrow_Desc : MonoBehaviour
{
    public void OnMouseEnter()
    {
        this.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void OnMouseExit()
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
    }
}
