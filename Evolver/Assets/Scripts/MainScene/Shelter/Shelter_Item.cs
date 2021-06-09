using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shelter_Item : MonoBehaviour
{
    public Canvas DisplayLab;
    public Canvas DisplayPhysical_Lab;
    Canvas DisplaySkill;                //구현 보류
    public Canvas DisplayMap;
    Canvas Displaysurvive;              //구현 보류
    public Canvas DisplayKitchen;
    private void OnCollisionEnter2D(Collision2D other)
    {
        //Lab 오브젝트가 플레이어와 충돌했다면
        if (other.gameObject.tag == "Player" && this.gameObject.layer == LayerMask.NameToLayer("Lab"))
        {
            DisplayLab.gameObject.SetActive(true);                   //비활성화 되어있으면 못찾는 것 같은데.....?
        }
        //Kitchen 오브젝트가 플레이어와 충돌했다면
        if (other.gameObject.tag == "Player" && this.gameObject.layer == LayerMask.NameToLayer("Kitchen"))
        {
            DisplayKitchen.gameObject.SetActive(true);
        }
        if (other.gameObject.tag == "Player" && this.gameObject.layer == LayerMask.NameToLayer("Map"))
        {
            DisplayMap.gameObject.SetActive(true);
        }
        if(other.gameObject.tag == "Player" && this.gameObject.layer == LayerMask.NameToLayer("Physical_Lab"))
        {
            DisplayPhysical_Lab.gameObject.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        //Lab 오브젝트가 플레이어와의 충돌이 끝났다면
        if (other.gameObject.tag == "Player" && this.gameObject.layer == LayerMask.NameToLayer("Lab"))
        {
            DisplayLab.gameObject.SetActive(false);
        }
        //Kitchen 오브젝트가 플레이어와의 충돌이 끝났다면
        if (other.gameObject.tag == "Player" && this.gameObject.layer == LayerMask.NameToLayer("Kitchen"))
        {
            DisplayKitchen.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Player" && this.gameObject.layer == LayerMask.NameToLayer("Map"))
        {
            DisplayMap.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Player" && this.gameObject.layer == LayerMask.NameToLayer("Physical_Lab"))
        {
            DisplayPhysical_Lab.gameObject.SetActive(false);
        }
    }
}
