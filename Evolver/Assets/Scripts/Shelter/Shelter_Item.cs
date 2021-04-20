using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelter_Item : MonoBehaviour
{
    Canvas DisplayLab;
    Canvas DisplaySkill;
    Canvas DisplayMap;
    Canvas Displaysurvive;
    private void OnCollisionEnter2D(Collision2D other)
    {
        //Lab 오브젝트가 플레이어와 충돌했다면
        if (other.gameObject.tag == "Player" && this.gameObject.layer == LayerMask.NameToLayer("Lab"))
        {
            DisplayLab.gameObject.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        //Lab 오브젝트가 플레이어와의 충돌이 끝났다면
        if (other.gameObject.tag == "Player" && this.gameObject.layer == LayerMask.NameToLayer("Lab"))
        {
            DisplayLab.gameObject.SetActive(false);
        }
    }
}
